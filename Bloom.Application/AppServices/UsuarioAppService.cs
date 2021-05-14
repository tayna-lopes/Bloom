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
using System.Linq;
namespace Bloom.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IAmizadeService _amizadeService;
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IAmizadeService amizadeService, IUsuarioService usuarioService)
        {
            _amizadeService = amizadeService;
            _usuarioService = usuarioService;
        }
        //Perfil
        public ResponseUtil GetInformacoesUser(string userEmail)
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                Usuario user = _usuarioService.GetByEmail(userEmail);
                if (user == null)
                {
                    resposta.Resultado = "Este usuário não existe";
                    resposta.Sucesso = false;
                    return resposta;
                }

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

                if (model.Foto != null)
                {
                    ResponseUtil resultImg = DownloadImage(model.Foto, user.UsuarioId.ToString()).Result;
                    if (resultImg.Sucesso)
                    {
                        user.Foto = resultImg.Resultado.ToString();
                    }
                }

                if (model.Nome != null)
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
                if (model.Estado != null)
                {
                    user.Estado = model.Estado;
                }
                if (model.Cidade != null)
                {
                    user.Cidade = model.Cidade;
                }
                if (model.DataDeNascimento != null)
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

        //Admin
        public ResponseUtil GraficoUsuariosByEstado()
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                List<Usuario> usersList = _usuarioService.GetAllUsuarios();
                if (usersList == null)
                {
                    resposta.Resultado = "Este usuário não existe";
                    resposta.Sucesso = false;
                    return resposta;
                }

                List<GraficoResponse> responseList = new List<GraficoResponse>();
                var usersByState = usersList.GroupBy(x => x.Estado);
                
                foreach( var x in usersByState)
                {
                    GraficoResponse grafico = new GraficoResponse
                    {
                        Numero = x.Count(),
                        Estado = x.FirstOrDefault().Estado
                    };
                    responseList.Add(grafico);
                }
                resposta.Resultado = responseList;
                resposta.Sucesso = true;
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Resultado = e;
                return resposta;
            }
        }
        public ResponseUtil GetMaisConectados(int Take)
        {
            ResponseUtil resposta = new ResponseUtil();
            try
            {
                List<Usuario> usersList = _usuarioService.GetAllUsuarios();
                if (usersList == null)
                {
                    resposta.Resultado = "Este usuário não existe";
                    resposta.Sucesso = false;
                    return resposta;
                }

                List<MaisConectadosResponse> maisConectadosResponses = new List<MaisConectadosResponse>();
                usersList.ForEach(x =>
               {
                   List<Amizade> amizadesList = _amizadeService.GetMeusAmigos(x.UsuarioId);
                   MaisConectadosResponse maisConectadoResponse = new MaisConectadosResponse
                   {
                       NumeroDeAmigos = amizadesList.Count,
                       Username = x.Username
                   };

                   maisConectadosResponses.Add(maisConectadoResponse);
               });

                resposta.Resultado = maisConectadosResponses.OrderByDescending(x => x.NumeroDeAmigos).Take(Take);
                resposta.Sucesso = true;
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Resultado = e;
                return resposta;
            }
        }
    }
}
