﻿using Bloom.Application.AppServicesInterfaces;
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
    public class AvaliacaoAppService : IAvaliacaoAppService
    {
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IFilmeService _filmeService;
        private readonly ISerieService _serieService;
        private readonly ILivroService _livroService;
        private readonly ICurtidaService _curtidaService;

        public AvaliacaoAppService(IAvaliacaoService avaliacaoService, IFilmeService filmeService, ISerieService serieService, ILivroService livroService, ICurtidaService curtidaService)
        {
            _avaliacaoService = avaliacaoService;
            _filmeService = filmeService;
            _serieService = serieService;
            _livroService = livroService;
            _curtidaService = curtidaService;
        }

        public ResponseUtil NovaAvaliacao(NovaAvaliacaoModel avaliacao)
        {
            var resposta = new ResponseUtil();
            try
            {
                if (avaliacao.LivroId != null) //avaliação de livro
                {
                    Livro livro = _livroService.GetById((Guid)avaliacao.LivroId);
                    if(livro == null)
                    {
                        resposta.Resultado = "Este livro não existe";
                        resposta.Sucesso = false;
                        return resposta;
                    }

                    Avaliacao novaAvaliacao = new Avaliacao
                    {
                        Id = Guid.NewGuid(),
                        Texto = avaliacao.Texto,
                        Classificacao = avaliacao.Classificacao,
                        UsuarioId = avaliacao.UsuarioId,
                        LivroId = avaliacao.LivroId,
                        TipoAvaliacao = BLL.Enums.TipoAvaliacao.Livro
                    };
                    _avaliacaoService.Add(novaAvaliacao);


                    List<Avaliacao> notas = _avaliacaoService.GetAvaliacaoLivroId(livro.Id);
                    if(notas.Count > 1)
                    {
                        AtualizarClassificacao((Guid)novaAvaliacao.Id);
                    };

                    resposta.Resultado = "Sua avaliação de livro foi adicionada";
                    resposta.Sucesso = true;
                }
                if (avaliacao.FilmeId != null) //avaliação de filme
                {
                    Filme filme = _filmeService.GetById((Guid)avaliacao.FilmeId);
                    if (filme == null)
                    {
                        resposta.Resultado = "Este livro não existe";
                        resposta.Sucesso = false;
                        return resposta;
                    }
                    Avaliacao novaAvaliacao = new Avaliacao
                    {
                        Id = Guid.NewGuid(),
                        Texto = avaliacao.Texto,
                        Classificacao = avaliacao.Classificacao,
                        UsuarioId = avaliacao.UsuarioId,
                        FilmeId = avaliacao.FilmeId,
                        TipoAvaliacao = BLL.Enums.TipoAvaliacao.Filme
                    };
                    _avaliacaoService.Add(novaAvaliacao);

                    List<Avaliacao> notas = _avaliacaoService.GetAvaliacaoFilmesId(filme.Id);
                    if (notas.Count > 1)
                    {
                        AtualizarClassificacao((Guid)novaAvaliacao.Id);
                    };

                    resposta.Resultado = "Sua avaliação de filme foi adicionada";
                    resposta.Sucesso = true;
                }
                if (avaliacao.SerieId != null) //avaliação de serie
                {
                    Serie serie = _serieService.GetById((Guid)avaliacao.SerieId);
                    if (serie == null)
                    {
                        resposta.Resultado = "Esta serie não existe";
                        resposta.Sucesso = false;
                        return resposta;
                    }
                    Avaliacao novaAvaliacao = new Avaliacao
                    {
                        Id = Guid.NewGuid(),
                        Texto = avaliacao.Texto,
                        Classificacao = avaliacao.Classificacao,
                        UsuarioId = avaliacao.UsuarioId,
                        SerieId = avaliacao.SerieId,
                        TipoAvaliacao = BLL.Enums.TipoAvaliacao.Serie
                    };
                    _avaliacaoService.Add(novaAvaliacao);

                    List<Avaliacao> notas = _avaliacaoService.GetAvaliacaoFilmesId(serie.Id);
                    if (notas.Count > 1)
                    {
                        AtualizarClassificacao((Guid)novaAvaliacao.Id);
                    };
                    resposta.Resultado = "Sua avaliação de serie foi adicionada";
                    resposta.Sucesso = true;
                }
            }
            catch(Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Sucesso = false;
            }
            return resposta;
        }
        public ResponseUtil EditarAvaliacao(EditarAvaliacaoModel model)
        {
            var resposta = new ResponseUtil();
            try
            {
                Avaliacao avaliacao = _avaliacaoService.GetById(model.AvaliacaoId);
                if(avaliacao == null)
                {
                    resposta.Resultado = "Esta avaliação não existe";
                    resposta.Sucesso = false;
                    return resposta;
                }
                if(avaliacao.UsuarioId != model.UsuarioId)
                {
                    resposta.Resultado = "Você não tem permissão para editar esta avaliação";
                    resposta.Sucesso = false;
                    return resposta;
                }
                if(model.Classificacao != null)
                {
                    avaliacao.Classificacao = (double)model.Classificacao;
                }
                if (model.Texto != null)
                {
                    avaliacao.Texto = model.Texto;
                }
                _avaliacaoService.Edit(avaliacao);
                AtualizarClassificacao(avaliacao.Id);
                resposta.Resultado = "Avaliação editada";
                resposta.Sucesso = true;
            }
            catch (Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Sucesso = false;
            }
            return resposta;
        }
        public ResponseUtil DeletarAvaliacao(DeletarAvaliacaoModel model)
        {
            var resposta = new ResponseUtil();
            try
            {
                Avaliacao avaliacao = _avaliacaoService.GetById(model.AvaliacaoId);
                if (avaliacao == null)
                {
                    resposta.Resultado = "Esta avaliação não existe";
                    resposta.Sucesso = false;
                    return resposta;
                }
                if (avaliacao.UsuarioId != model.UsuarioId)
                {
                    resposta.Resultado = "Você não tem permissão para deletar esta avaliação";
                    resposta.Sucesso = false;
                    return resposta;
                }
                _avaliacaoService.Remove(avaliacao);
                AtualizarClassificacao(model.AvaliacaoId);
                resposta.Resultado = "Avaliação deletada";
                resposta.Sucesso = true;
            }
            catch (Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Sucesso = false;
            }
            return resposta;
        }
        public ResponseUtil GetTodasAvaliacoesMediaId(GetTodasAvaliacoesMidiaModel model)
        {
            var resposta = new ResponseUtil();
            try
            { 
                if(model.LivroId != null)
                {
                    Livro livro = _livroService.GetById((Guid)model.LivroId);
                    if (livro == null)
                    {
                        resposta.Resultado = "Este livro não existe";
                        resposta.Sucesso = false;
                        return resposta;
                    }
                    List<Avaliacao> avaliacoes = _avaliacaoService.GetAvaliacaoLivroId((Guid)model.LivroId);
                    List<AvaliacaoResponse> listAvaliacao = new List<AvaliacaoResponse>();
                    avaliacoes.ForEach(x =>
                    {
                        AvaliacaoResponse avaliacaoResponse = new AvaliacaoResponse
                        {
                            AvaliacaoId = x.Id,
                            UsuarioId = x.UsuarioId,
                            Classificacao = x.Classificacao,
                            Comentario = x.Texto
                        };
                        listAvaliacao.Add(avaliacaoResponse);
                    });
                    resposta.Resultado = listAvaliacao;
                    resposta.Sucesso = true;
                }
                if (model.FilmeId != null)
                {
                    Filme filme = _filmeService.GetById((Guid)model.FilmeId);
                    if (filme == null)
                    {
                        resposta.Resultado = "Este filme não existe";
                        resposta.Sucesso = false;
                        return resposta;
                    }
                    List<Avaliacao> avaliacoes = _avaliacaoService.GetAvaliacaoFilmesId((Guid)model.FilmeId);
                    List<AvaliacaoResponse> listAvaliacao = new List<AvaliacaoResponse>();
                    avaliacoes.ForEach(x =>
                    {
                        AvaliacaoResponse avaliacaoResponse = new AvaliacaoResponse
                        {
                            AvaliacaoId = x.Id,
                            UsuarioId = x.UsuarioId,
                            Classificacao = x.Classificacao,
                            Comentario = x.Texto
                        };
                        listAvaliacao.Add(avaliacaoResponse);
                    });
                    resposta.Resultado = listAvaliacao;
                    resposta.Sucesso = true;
                }
                if (model.SerieId != null)
                {
                    Serie serie = _serieService.GetById((Guid)model.SerieId);
                    if (serie == null)
                    {
                        resposta.Resultado = "Esta serie não existe";
                        resposta.Sucesso = false;
                        return resposta;
                    }
                    List<Avaliacao> avaliacoes = _avaliacaoService.GetAvaliacaoSerieId((Guid)model.SerieId);
                    List<AvaliacaoResponse> listAvaliacao = new List<AvaliacaoResponse>();
                    avaliacoes.ForEach(x =>
                    {
                        AvaliacaoResponse avaliacaoResponse = new AvaliacaoResponse
                        {
                            AvaliacaoId = x.Id,
                            UsuarioId = x.UsuarioId,
                            Classificacao = x.Classificacao,
                            Comentario = x.Texto
                        };
                        listAvaliacao.Add(avaliacaoResponse);
                    });
                    resposta.Resultado = listAvaliacao;
                    resposta.Sucesso = true;
                }
            }
            catch (Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Sucesso = false;
            }
            return resposta;
        }
        public ResponseUtil GetAvaliacoesMidiaByUsuarioId(Guid UsuarioId, TipoAvaliacao tipo)
        {
            var resposta = new ResponseUtil();
            try
            {
                List<Avaliacao> avaliacoes = _avaliacaoService.GetAvaliacaoMidia(UsuarioId, tipo);
                List<AvaliacaoResponse> listAvaliacao = new List<AvaliacaoResponse>();
                avaliacoes.ForEach(x =>
                {
                    
                    AvaliacaoResponse avaliacaoResponse = new AvaliacaoResponse
                    {
                        AvaliacaoId = x.Id,
                        UsuarioId = x.UsuarioId,
                        Classificacao = x.Classificacao,
                        Comentario = x.Texto
                    };

                    if(tipo == TipoAvaliacao.Filme)
                    {
                        var id  = Guid.Parse(x.FilmeId.ToString());
                        var filme = _filmeService.GetById(id);
                        avaliacaoResponse.Filme = filme;
                    }
                    if (tipo == TipoAvaliacao.Livro)
                    {
                        var id = Guid.Parse(x.LivroId.ToString());
                        var livro = _livroService.GetById(id);
                        avaliacaoResponse.Livro = livro;

                    }
                    if (tipo == TipoAvaliacao.Serie)
                    {
                        var id = Guid.Parse(x.SerieId.ToString());
                        var serie = _serieService.GetById(id);
                        avaliacaoResponse.Serie = serie;
                    }

                    var curtidas = _curtidaService.GetCurtidasAvaliacaoId(x.Id);
                    avaliacaoResponse.Curtidas = curtidas.Count;
                    listAvaliacao.Add(avaliacaoResponse);
                });
                resposta.Resultado = listAvaliacao;
                resposta.Sucesso = true;
            }
            catch (Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Sucesso = false;
            }
            return resposta;
        }
        public void AtualizarClassificacao(Guid AvaliacaoId)
        {
            try
            {
                Avaliacao avaliacao = _avaliacaoService.GetById(AvaliacaoId);
                if(avaliacao.FilmeId != null)
                {
                    List<Avaliacao> avaliacoes = _avaliacaoService.GetAvaliacaoFilmesId((Guid)avaliacao.FilmeId);
                    double media = 0;
                    avaliacoes.ForEach(x =>
                   {
                       media += x.Classificacao;
                   });
                    double mediaFinal = media / avaliacoes.Count;
                    
                    Filme filme = _filmeService.GetById((Guid)avaliacao.FilmeId);
                    filme.Classificacao = mediaFinal;
                    _filmeService.Edit(filme);
                }
                if(avaliacao.SerieId != null)
                {
                    List<Avaliacao> avaliacoes = _avaliacaoService.GetAvaliacaoSerieId((Guid)avaliacao.SerieId);
                    double media = 0;
                    avaliacoes.ForEach(x =>
                    {
                        media += x.Classificacao;
                    });
                    double mediaFinal = media / avaliacoes.Count;

                    Serie serie = _serieService.GetById((Guid)avaliacao.SerieId);
                    serie.Classificacao = mediaFinal;
                    _serieService.Edit(serie);
                }
                if (avaliacao.LivroId != null)
                {
                    List<Avaliacao> avaliacoes = _avaliacaoService.GetAvaliacaoLivroId((Guid)avaliacao.LivroId);
                    double media = 0;
                    avaliacoes.ForEach(x =>
                    {
                        media += x.Classificacao;
                    });
                    double mediaFinal = media / avaliacoes.Count;

                    Livro livro = _livroService.GetById((Guid)avaliacao.LivroId);
                    livro.Classificacao = mediaFinal;
                    _livroService.Edit(livro);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
