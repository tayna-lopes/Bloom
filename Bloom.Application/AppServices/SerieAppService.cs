using Bloom.Application.AppServicesInterfaces;
using Bloom.Application.Models;
using Bloom.BLL.Entities;
using Bloom.BLL.Enums;
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
    public class SerieAppService: ISerieAppService
    {
        private readonly ISerieService _serieService;
        private readonly IUsuarioService _usuarioService;

        public SerieAppService(ISerieService serieService, IUsuarioService usuarioService)
        {
            _serieService = serieService;
            _usuarioService = usuarioService;

        }
        public ResponseUtil CriarSerie(CriarSerieModel model)
        {
            var resposta = new ResponseUtil();
            try
            {
                var show = _serieService.GetByName(model.Titulo);
                if (show != null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Esta serie já está cadastrado";
                    return resposta;
                };
                var elenco = String.Join(", ", model.Elenco);

                Guid SerieId = Guid.NewGuid();
                string Foto = string.Empty;

                ResponseUtil resultImg = DownloadImage(model.Foto, SerieId.ToString()).Result;
                if (resultImg.Sucesso)
                {
                    Foto = resultImg.Resultado.ToString();
                }
                Serie serie = new Serie
                {
                    Id = SerieId,
                    Foto = Foto,
                    UsuarioId = model.UsuarioId,
                    Titulo = model.Titulo,
                    Diretor = model.Diretor,
                    Elenco = elenco,
                    Pais = model.Pais,
                    Ano = model.Ano,
                    NumeroDeTemporadas = model.NumeroDeTemporadas,
                    Classificacao = model.Classificacao,
                    Genero = model.Genero,
                    Status = StatusAvaliacao.Pendente,
                    Adicionado = DateTimeUtil.UtcToBrasilia()
                };
                _serieService.Add(serie);

                resposta.Sucesso = true;
                resposta.Resultado = serie.Id;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil AtualizarSerie(AtualizarSerieModel model)
        {
            var resposta = new ResponseUtil();
            try
            {
                var serie = _serieService.GetById(model.SerieId);
                if (serie == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Esta serie não está cadastrado";
                    return resposta;
                };

                if(model.Foto != null)
                {
                    ResponseUtil resultImg = DownloadImage(model.Foto, serie.Id.ToString()).Result;
                    if (resultImg.Sucesso)
                    {
                        serie.Foto = resultImg.Resultado.ToString();
                    }
                }
                if (model.Titulo != null)
                {
                    serie.Titulo = model.Titulo;
                }
                if (model.Elenco != null)
                {
                    var elenco = String.Join(", ", model.Elenco);
                    serie.Elenco = elenco;
                }
                if (model.Pais != null)
                {
                    serie.Pais = model.Pais;
                }
                if (model.Ano != serie.Ano)
                {
                    serie.Ano = model.Ano;
                }
                if (model.Diretor != null)
                {
                    serie.Diretor = model.Diretor;
                }
                if (model.Genero != serie.Genero)
                {
                    serie.Genero = model.Genero;
                }
                if (model.NumeroDeTemporadas != serie.NumeroDeTemporadas)
                {
                    serie.NumeroDeTemporadas = model.NumeroDeTemporadas;
                }
                _serieService.Edit(serie);

                resposta.Sucesso = true;
                resposta.Resultado = serie.Id;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil GetById(Guid SerieId)
        {
            var resposta = new ResponseUtil();
            try
            {
                var serie = _serieService.GetById(SerieId);
                if (serie == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Esta serie não está cadastrado";
                    return resposta;
                };

                Usuario usuario = _usuarioService.GetById(serie.UsuarioId);

                SerieResponse serieResponse = new SerieResponse
                {
                    Diretor = serie.Diretor,
                    Ano = serie.Ano,
                    Elenco = serie.Elenco,
                    Titulo = serie.Titulo,
                    Genero = serie.Genero,
                    Pais = serie.Pais,
                    Username = usuario.Username,
                    NumeroDeTemporadas = serie.NumeroDeTemporadas,
                    Id = serie.Id,
                    Classificacao = serie.Classificacao,
                    Foto = serie.Foto
                };

                resposta.Sucesso = true;
                resposta.Resultado = serieResponse;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil GetAllSeriess()
        {
            var resposta = new ResponseUtil();
            try
            {
                var series = _serieService.GetAll();
                if (series == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Nenhuma serie cadastrado";
                    return resposta;
                };

                List<SerieResponse> seriesResponses = new List<SerieResponse>();
                foreach (var serie in series)
                {
                    if (serie.Status == StatusAvaliacao.Aprovado)
                    {
                        Usuario usuario = _usuarioService.GetById(serie.UsuarioId);
                        SerieResponse serieResponse = new SerieResponse
                        {
                            Diretor = serie.Diretor,
                            Ano = serie.Ano,
                            Elenco = serie.Elenco,
                            Titulo = serie.Titulo,
                            Genero = serie.Genero,
                            Pais = serie.Pais,
                            Username = usuario.Username,
                            NumeroDeTemporadas = serie.NumeroDeTemporadas,
                            Classificacao = serie.Classificacao,
                            Id = serie.Id,
                            Foto = serie.Foto
                        };
                        seriesResponses.Add(serieResponse);
                    }

                }
                resposta.Sucesso = true;
                resposta.Resultado = seriesResponses;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil GetAdicionadosRecentemente()
        {
            var resposta = new ResponseUtil();
            try
            {
                var series = _serieService.GetAdicionadosRecentemente();
                if (series == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Nenhuma serie cadastrado";
                    return resposta;
                };

                List<SerieResponse> seriesResponses = new List<SerieResponse>();
                foreach (var serie in series)
                {
                    if (serie.Status == StatusAvaliacao.Aprovado)
                    {
                        Usuario usuario = _usuarioService.GetById(serie.UsuarioId);
                        SerieResponse serieResponse = new SerieResponse
                        {
                            Diretor = serie.Diretor,
                            Ano = serie.Ano,
                            Elenco = serie.Elenco,
                            Titulo = serie.Titulo,
                            Genero = serie.Genero,
                            Pais = serie.Pais,
                            Username = usuario.Username,
                            NumeroDeTemporadas = serie.NumeroDeTemporadas,
                            Classificacao = serie.Classificacao,
                            Id = serie.Id,
                            Foto = serie.Foto
                        };
                        seriesResponses.Add(serieResponse);
                    }
                }
                resposta.Sucesso = true;
                resposta.Resultado = seriesResponses;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil GetAllSeriesByUser(Guid UsuarioId)
        {
            var resposta = new ResponseUtil();
            try
            {
                var series = _serieService.GetAllSeriesByUsuarioId(UsuarioId);
                if (series == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Nenhuma serie cadastrado";
                    return resposta;
                };

                List<SerieResponse> seriesResponses = new List<SerieResponse>();
                foreach (var serie in series)
                {
                    if (serie.Status == StatusAvaliacao.Aprovado)
                    {
                        Usuario usuario = _usuarioService.GetById(serie.UsuarioId);
                        SerieResponse serieResponse = new SerieResponse
                        {
                            Diretor = serie.Diretor,
                            Ano = serie.Ano,
                            Elenco = serie.Elenco,
                            Titulo = serie.Titulo,
                            Genero = serie.Genero,
                            Pais = serie.Pais,
                            Username = usuario.Username,
                            NumeroDeTemporadas = serie.NumeroDeTemporadas,
                            Classificacao = serie.Classificacao,
                            Id = serie.Id,
                            Foto = serie.Foto
                        };
                        seriesResponses.Add(serieResponse);
                    }
                }
                resposta.Sucesso = true;
                resposta.Resultado = seriesResponses;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil DeletarSerie(Guid SerieId)
        {
            var resposta = new ResponseUtil();
            try
            {
                var serie = _serieService.GetById(SerieId);
                if (serie == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Este esta serie não está cadastrado";
                    return resposta;
                };

                _serieService.Remove(serie);

                resposta.Sucesso = true;
                resposta.Resultado = "Serie excluida";
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public async Task<ResponseUtil> DownloadImage(IFormFile file, string SeriesId)
        {
            var response = new ResponseUtil();

            try
            {
                string dir = Directory.GetCurrentDirectory();
                dir += ".BLL";
                string insideDir = "/Assets/SeriesImages/";
                string path = dir + insideDir;


                string[] subs = file.FileName.Split('.');
                var fileName = $"{SeriesId}.{subs[1]}";

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
