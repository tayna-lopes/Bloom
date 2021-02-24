using Bloom.Application.AppServicesInterfaces;
using Bloom.Application.Models;
using Bloom.BLL.Entities;
using Bloom.BLL.ServicesInterfaces;
using Bloom.BLL.Utils;
using Cryptography;
using System;
using System.Collections.Generic;
using System.Text;

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
                    Senha = SHA2.GenerateHash(model.Senha, userId.ToString())
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
                    Nome = user.Nome,
                    Email = user.Email
                };

                resposta.Sucesso = true;
                resposta.Resultado = returnModel;
                return resposta;
            }

            if (user == null)
            {
                resposta.Resultado = "Email nao cadastrado. Por favor, verifique se já se cadastrou no Goper e tente novamente.";
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
    }
}