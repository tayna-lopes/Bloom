﻿using Bloom.Application.AppServicesInterfaces;
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
    public class LivroAppService: ILivroAppService
    {
        private readonly ILivroService _livroService;
        private readonly IUsuarioService _usuarioService;

        public LivroAppService(ILivroService livroService, IUsuarioService usuarioService)
        {
            _livroService = livroService;
            _usuarioService = usuarioService;

        }
        public ResponseUtil CriarLivro(CriarLivroModel model)
        {
            var resposta = new ResponseUtil();
            try
            {
                var book = _livroService.GetByName(model.Titulo);
                if (book != null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Este livro já está cadastrado";
                    return resposta;
                };
                var autores = String.Join(", ", model.Autores);

                Livro livro = new Livro
                {
                    Id = Guid.NewGuid(),
                    Foto = model.Foto,
                    UsuarioId = model.UsuarioId,
                    Titulo = model.Titulo,
                    Autores = autores,
                    Editora = model.Editora,
                    Pais = model.Pais,
                    Ano = model.Ano,
                    Classificacao = model.Classificacao,
                    Genero = model.Genero,
                    Status = StatusAvaliacao.Pendente,
                    Adicionado = DateTimeUtil.UtcToBrasilia()
                };
                _livroService.Add(livro);

                resposta.Sucesso = true;
                resposta.Resultado = livro.Id;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil AtualizarLivro(AtualizarLivroModel model)
        {
            var resposta = new ResponseUtil();
            try
            {
                var livro = _livroService.GetById(model.LivroId);
                if (livro == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Este livro não está está cadastrado";
                    return resposta;
                };

                if (model.Foto != null)
                {
                    livro.Foto = model.Foto;
                }
                if (model.Titulo != null)
                {
                    livro.Titulo = model.Titulo;
                }
                if (model.Autores != null)
                {
                    var autores = String.Join(", ", model.Autores);
                    livro.Autores = autores;
                }
                if (model.Pais != null)
                {
                    livro.Pais = model.Pais;
                }
                if (model.Ano != livro.Ano)
                {
                    livro.Ano = model.Ano;
                }
                if (model.Editora != null)
                {
                    livro.Editora = model.Editora;
                }
                if (model.Genero != livro.Genero)
                {
                    livro.Genero = model.Genero;
                }

                _livroService.Edit(livro);

                resposta.Sucesso = true;
                resposta.Resultado = livro.Id;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil GetById(Guid LivroId)
        {
            var resposta = new ResponseUtil();
            try
            {
                var livro = _livroService.GetById(LivroId);
                if (livro == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Este livro não está cadastrado";
                    return resposta;
                };

                Usuario usuario = _usuarioService.GetById(livro.UsuarioId);
                LivroResponse livroResponse = new LivroResponse
                {
                    Autores = livro.Autores,
                    Ano = livro.Ano,
                    Editora = livro.Editora,
                    Titulo = livro.Titulo,
                    Genero = livro.Genero,
                    Pais = livro.Pais,
                    Username = usuario.Username,
                    Id = livro.Id,
                    Classificacao = livro.Classificacao,
                    Foto = livro.Foto
                };

                resposta.Sucesso = true;
                resposta.Resultado = livroResponse;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil GetAllLivros()
        {
            var resposta = new ResponseUtil();
            try
            {
                var livros = _livroService.GetAll();
                if (livros == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Nenhum livro cadastrado";
                    return resposta;
                };

                List<LivroResponse> livrosResponse = new List<LivroResponse>();
                foreach (var livro in livros)
                {
                    if (livro.Status == StatusAvaliacao.Aprovado)
                    {
                        Usuario usuario = _usuarioService.GetById(livro.UsuarioId);
                        LivroResponse livroResponse = new LivroResponse
                        {
                            Autores = livro.Autores,
                            Ano = livro.Ano,
                            Editora = livro.Editora,
                            Titulo = livro.Titulo,
                            Genero = livro.Genero,
                            Pais = livro.Pais,
                            Username = usuario.Username,
                            Id = livro.Id,
                            Classificacao = livro.Classificacao,
                            Foto = livro.Foto
                        };
                        livrosResponse.Add(livroResponse);
                    }

                }
                resposta.Sucesso = true;
                resposta.Resultado = livrosResponse;
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
                var livros = _livroService.GetAdicionadosRecentemente();
                if (livros == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Nenhum livro cadastrado";
                    return resposta;
                };

                List<LivroResponse> livrosResponse = new List<LivroResponse>();
                foreach (var livro in livros)
                {
                    if (livro.Status == StatusAvaliacao.Aprovado)
                    {
                        Usuario usuario = _usuarioService.GetById(livro.UsuarioId);
                        LivroResponse livroResponse = new LivroResponse
                        {
                            Autores = livro.Autores,
                            Ano = livro.Ano,
                            Editora = livro.Editora,
                            Titulo = livro.Titulo,
                            Genero = livro.Genero,
                            Pais = livro.Pais,
                            Username = usuario.Username,
                            Id = livro.Id,
                            Classificacao = livro.Classificacao,
                            Foto = livro.Foto
                        };
                        livrosResponse.Add(livroResponse);
                    }

                }
                resposta.Sucesso = true;
                resposta.Resultado = livrosResponse;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil GetAllLivrosByUser(Guid UsuarioId)
        {
            var resposta = new ResponseUtil();
            try
            {
                var livros = _livroService.GetAllLivrosByUsuarioId(UsuarioId);
                if (livros == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Nenhum livro cadastrado";
                    return resposta;
                };

                List<LivroResponse> livrosResponse = new List<LivroResponse>();
                foreach (var livro in livros)
                {
                    if (livro.Status == StatusAvaliacao.Aprovado)
                    {
                        Usuario usuario = _usuarioService.GetById(livro.UsuarioId);
                        LivroResponse livroResponse = new LivroResponse
                        {
                            Autores = livro.Autores,
                            Ano = livro.Ano,
                            Editora = livro.Editora,
                            Titulo = livro.Titulo,
                            Genero = livro.Genero,
                            Pais = livro.Pais,
                            Username = usuario.Username,
                            Id = livro.Id,
                            Classificacao = livro.Classificacao,
                            Foto = livro.Foto
                        };
                        livrosResponse.Add(livroResponse);
                    }

                }
                resposta.Sucesso = true;
                resposta.Resultado = livrosResponse;
            }
            catch (Exception e)
            {
                resposta.Sucesso = false;
                resposta.Resultado = e.Message;
            }
            return resposta;
        }
        public ResponseUtil DeletarFilme(Guid LivroId)
        {
            var resposta = new ResponseUtil();
            try
            {
                var livro = _livroService.GetById(LivroId);
                if (livro == null)
                {
                    resposta.Sucesso = false;
                    resposta.Resultado = "Este livro já está cadastrado";
                    return resposta;
                };

                _livroService.Remove(livro);

                resposta.Sucesso = true;
                resposta.Resultado = "livro excluido";
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
