using Bloom.Application.AppServicesInterfaces;
using Bloom.Application.Models;
using Bloom.BLL.Entities;
using Bloom.BLL.Enums;
using Bloom.BLL.ServicesInterfaces;
using Bloom.BLL.Utils;
using Cryptography;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.AppServices
{
    public class FilmeAppService : IFilmeAppService
    {
        private readonly IFilmeService _filmeService;
        private readonly IUsuarioService _usuarioService;

        public FilmeAppService(IFilmeService filmeService, IUsuarioService usuarioService)
        {
            _filmeService = filmeService;
            _usuarioService = usuarioService;
        }

        public ResponseUtil CriarFilme(CriarFilmeModel model)
        {
            var resposta = new ResponseUtil();
            try
            {
                var filmes = _filmeService.GetByName(model.Titulo);
                if (filmes != null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Este filme já está cadastrado";
                    return resposta;
                };
                var elenco = String.Join(", ", model.Elenco);
                Filme filme = new Filme
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = model.UsuarioId,
                    Titulo = model.Titulo,
                    Diretor = model.Diretor,
                    Elenco = elenco,
                    Pais = model.Pais,
                    Ano = model.Ano,
                    Classificacao = model.Classificacao,
                    Genero = model.Genero,
                    Status = StatusAvaliacao.Pendente,
                    Adicionado = DateTimeUtil.UtcToBrasilia()
                };
                _filmeService.Add(filme);

                resposta.Sucesso = true;
                resposta.Resultado = filme.Id;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil AtualizarFilme(AtualizarFilmeModel model)
        {
            var resposta = new ResponseUtil();
            try
            {
                var filme = _filmeService.GetById(model.FilmeId);
                if (filme == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Este filme não está está cadastrado";
                    return resposta;
                };


                if (model.Titulo != null)
                {
                    filme.Titulo = model.Titulo;
                }
                if (model.Elenco != null)
                {
                    var elenco = String.Join(", ", model.Elenco);
                    filme.Elenco = elenco;
                }
                if (model.Pais != null)
                {
                    filme.Pais = model.Pais;
                }
                if (model.Ano != filme.Ano)
                {
                    filme.Ano = model.Ano;
                }
                if (model.Diretor != null)
                {
                    filme.Diretor = model.Diretor;
                }
                if (model.Genero != filme.Genero)
                {
                    filme.Genero = model.Genero;
                }

                _filmeService.Edit(filme);

                resposta.Sucesso = true;
                resposta.Resultado = filme.Id;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil GetById(Guid FilmeId)
        {
            var resposta = new ResponseUtil();
            try
            {
                var filme = _filmeService.GetById(FilmeId);
                if (filme == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Este filme não está cadastrado";
                    return resposta;
                };

                Usuario usuario = _usuarioService.GetById(filme.UsuarioId);
                FilmeResponse filmeResponse = new FilmeResponse
                {
                    Diretor = filme.Diretor,
                    Ano = filme.Ano,
                    Elenco = filme.Elenco,
                    Titulo = filme.Titulo,
                    Genero = filme.Genero,
                    Pais = filme.Pais,
                    Username = usuario.Username,
                    FilmeId = filme.Id
                };

                resposta.Sucesso = true;
                resposta.Resultado = filmeResponse;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil GetAllFilmes()
        {
            var resposta = new ResponseUtil();
            try
            {
                var filmes = _filmeService.GetAll();
                if (filmes == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Nenhum filme cadastrado";
                    return resposta;
                };

                List<FilmeResponse> filmesResponse = new List<FilmeResponse>();
                foreach( var x in filmes)
                {
                    if(x.Status == StatusAvaliacao.Aprovado)
                    {
                        Usuario usuario = _usuarioService.GetById(x.UsuarioId);
                        FilmeResponse filmeResponse = new FilmeResponse
                        {
                            Diretor = x.Diretor,
                            Ano = x.Ano,
                            Elenco = x.Elenco,
                            Titulo = x.Titulo,
                            Genero = x.Genero,
                            Pais = x.Pais,
                            Username = usuario.Username,
                            FilmeId = x.Id
                        };
                        filmesResponse.Add(filmeResponse);
                    }
                    
                }
                resposta.Sucesso = true;
                resposta.Resultado = filmesResponse;
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
                var filmes = _filmeService.GetAdicionadosRecentemente();
                if (filmes == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Nenhum filme cadastrado";
                    return resposta;
                };

                List<FilmeResponse> filmesResponse = new List<FilmeResponse>();
                foreach (var x in filmes)
                {
                    if(x.Status == StatusAvaliacao.Aprovado)
                    {
                        Usuario usuario = _usuarioService.GetById(x.UsuarioId);
                        FilmeResponse filmeResponse = new FilmeResponse
                        {
                            Diretor = x.Diretor,
                            Ano = x.Ano,
                            Elenco = x.Elenco,
                            Titulo = x.Titulo,
                            Genero = x.Genero,
                            Pais = x.Pais,
                            Username = usuario.Username,
                            FilmeId = x.Id
                        };
                        filmesResponse.Add(filmeResponse);
                    }
                    
                }
                resposta.Sucesso = true;
                resposta.Resultado = filmesResponse;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil GetAllFilmesByUser(Guid UsuarioId)
        {
            var resposta = new ResponseUtil();
            try
            {
                var filmes = _filmeService.GetAllFilmesByUsuarioId(UsuarioId);
                if (filmes == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Nenhum filme cadastrado";
                    return resposta;
                };

                List<FilmeResponse> filmesResponse = new List<FilmeResponse>();
                foreach (var x in filmes)
                {
                    if (x.Status == StatusAvaliacao.Aprovado)
                    {
                        Usuario usuario = _usuarioService.GetById(x.UsuarioId);
                        FilmeResponse filmeResponse = new FilmeResponse
                        {
                            Diretor = x.Diretor,
                            Ano = x.Ano,
                            Elenco = x.Elenco,
                            Titulo = x.Titulo,
                            Genero = x.Genero,
                            Pais = x.Pais,
                            Username = usuario.Username,
                            FilmeId = x.Id
                        };
                        filmesResponse.Add(filmeResponse);
                    }
                }
                resposta.Sucesso = true;
                resposta.Resultado = filmesResponse;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil DeletarFilme(Guid FilmeId)
        {
            var resposta = new ResponseUtil();
            try
            {
                var filme = _filmeService.GetById(FilmeId);
                if (filme == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Este filme já está cadastrado";
                    return resposta;
                };

                _filmeService.Remove(filme);

                resposta.Sucesso = true;
                resposta.Resultado = "Filme excluido";
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
    }
}