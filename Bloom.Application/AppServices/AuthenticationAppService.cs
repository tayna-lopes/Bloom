using Bloom.Application.AppServicesInterfaces;
using Bloom.Application.Models;
using Bloom.BLL.Entities;
using Bloom.BLL.ServicesInterfaces;
using Bloom.BLL.Utils;
using Cryptography;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Bloom.Application.AppServices
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly IUsuarioService _usuarioService;

        public AuthenticationAppService(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;

        }

        //Novo Usuário
        public ResponseUtil ValidarNovoUsuario(NovoUsuarioModel model)
        {
            ResponseUtil resposta = new ResponseUtil
            {
                Sucesso = true
            };
            if (!_usuarioService.ValidarUsername(model.Username))
            {
                resposta.Resultado = "Username já existe";
                resposta.Sucesso = false;
            }
            if (model.Email == null || model.Nome == null || model.Senha == null ||
                model.Email == string.Empty || model.Nome == string.Empty || model.Senha == string.Empty)
            {
                resposta.Sucesso = false;
                resposta.Resultado = "Algum atributo vazio";
            }

            if (_usuarioService.GetByEmail(model.Email) != null)
            {
                resposta.Sucesso = false;
                resposta.Resultado = "Email já cadastrado.";
            }

            return resposta;
        }
        public bool NovoUsuario(NovoUsuarioModel model)
        {
            try
            {
                var userId = Guid.NewGuid();

                Usuario user = new Usuario
                {
                    UsuarioId = userId,
                    Criado = DateTimeUtil.UtcToBrasilia(),
                    Alterado = DateTimeUtil.UtcToBrasilia(),
                    Nome = model.Nome,
                    Email = model.Email.ToLower(),
                    Senha = SHA2.GenerateHash(model.Senha, userId.ToString()),
                    Username = model.Username,
                    Cidade = model.Cidade,
                    Estado = model.Estado,
                    DataDeNascimento = model.DataDeNascimento,
                    IsAdmin = model.IsAdmin
                };

                _usuarioService.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Login
        private bool ValidarSenha(string senha, Usuario usuario)
        {
            var senhaHash = SHA2.GenerateHash(senha, usuario.UsuarioId.ToString());

            return senhaHash == usuario.Senha ? true : false;
        }
        public ResponseUtil ValidarUsuario(LoginModel model)
        {
            var resposta = new ResponseUtil();

            model.Email = model.Email.Trim();
            Usuario user = _usuarioService.GetByEmail(model.Email);

            if (user != null && ValidarSenha(model.Password, user))
            {
                var returnModel = new AuthenticationModel
                {
                    UserId = user.UsuarioId.ToString(),
                    Nome = user.Nome
                };

                resposta.Sucesso = true;
                resposta.Resultado = returnModel;
                return resposta;
            }

            if (user == null)
            {
                resposta.Resultado = "Email não cadastrado. Por favor, verifique se já se cadastrou no Bloom e tente novamente, pois sei que você vai querer ser uma de nós";
                return resposta;
            }
            resposta.Resultado = "Login não autorizado";
            return resposta;
        }
        public ResponseUtil Login(LoginModel model)
        {
            ResponseUtil resposta = new ResponseUtil();
            var loginResponse = ValidarUsuario(model);
            if (!loginResponse.Sucesso)
            {
                return loginResponse;
            }
            AuthenticationModel authenticationModel = (AuthenticationModel)loginResponse.Resultado;
            resposta.Sucesso = true;
            resposta.Resultado = authenticationModel;
            return resposta;
        }

        //Perfil
        public ResponseUtil GetInformacoesUser(string userEmail)
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                Usuario user = _usuarioService.GetByEmail(userEmail);
                if(user == null)
                {
                    resposta.Resultado = "Este usuário não existe";
                    resposta.Sucesso = false;
                    return resposta;
                }

                resposta.Resultado = user;
                resposta.Sucesso = true;
                return resposta;
            }
            catch(Exception e)
            {
                resposta.Resultado = e;
                return resposta;
            }
        }
        public ResponseUtil AtualizarUsuario(UpdateUserModel model)
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                Usuario user = _usuarioService.GetByEmail(model.userEmail);
                if (user == null)
                {
                    resposta.Resultado = "Este usuário não existe";
                    resposta.Sucesso = false;
                    return resposta;
                }

                if(model.Foto != null)
                {
                    ResponseUtil resultImg = DownloadImage(model.Foto, user.UsuarioId.ToString()).Result;
                    if (resultImg.Sucesso)
                    {
                       user.Foto = resultImg.Resultado.ToString();
                    }
                }

                if(model.Nome != null)
                {
                    user.Nome = model.Nome;
                }
                if (model.Username != null)
                {
                    if (!_usuarioService.ValidarUsername(model.Username))
                    {
                        resposta.Resultado = "Este username já está sendo usado";
                        resposta.Sucesso = false;
                        return resposta;
                    }
                    else
                    {
                        user.Username = model.Username;
                    }
                }
                if(model.Estado != null)
                {
                    user.Estado = model.Estado;
                }
                if (model.Cidade != null)
                {
                    user.Cidade = model.Cidade;
                }
                if(model.DataDeNascimento != null)
                {
                    user.DataDeNascimento = model.DataDeNascimento;
                }
                _usuarioService.Edit(user);

                resposta.Resultado = user;
                resposta.Sucesso = true;
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Resultado = e;
                return resposta;
            }
        }
        public async Task<ResponseUtil> DownloadImage(IFormFile file, string userId)
        {
            var response = new ResponseUtil();

            try
            {
                string dir = Directory.GetCurrentDirectory();
                dir += ".BLL";
                //dir = dir.Replace("Bloom", "Bloom.BLL");
                string insideDir = "/Assets/UserImages/";
                string path = dir + insideDir;


                string[] subs = file.FileName.Split('.');
                var fileName = $"{userId}.{subs[1]}";

                string filePath = Path.Combine(path, fileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                response.Sucesso = true;
                response.Resultado = "Bloom/Bloom.BLL" + insideDir + fileName;
            }
            catch (Exception e)
            {
                response.Resultado = "Erro ao adicionar a imagem";
                response.Sucesso = false;
            }

            return response;
        }
    }
}