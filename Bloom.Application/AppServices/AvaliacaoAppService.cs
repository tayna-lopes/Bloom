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
    public class AvaliacaoAppService : IAvaliacaoAppService
    {
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IFilmeService _filmeService;
        private readonly ISerieService _serieService;
        private readonly ILivroService _livroService;

        public AvaliacaoAppService(IAvaliacaoService avaliacaoService, IFilmeService filmeService, ISerieService serieService, ILivroService livroService)
        {
            _avaliacaoService = avaliacaoService;
            _filmeService = filmeService;
            _serieService = serieService;
            _livroService = livroService;
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
                        double media = 0;
                        notas.ForEach(x =>
                        {
                            media += x.Classificacao;
                        });
                        double mediaFinal = media / notas.Count;
                        novaAvaliacao.Classificacao = mediaFinal;
                        _avaliacaoService.Edit(novaAvaliacao);
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
                        double media = 0;
                        notas.ForEach(x =>
                        {
                            media += x.Classificacao;
                        });
                        double mediaFinal = media / notas.Count;
                        novaAvaliacao.Classificacao = mediaFinal;
                        _avaliacaoService.Edit(novaAvaliacao);
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
                        double media = 0;
                        notas.ForEach(x =>
                        {
                            media += x.Classificacao;
                        });
                        double mediaFinal = media / notas.Count;
                        novaAvaliacao.Classificacao = mediaFinal;
                        _avaliacaoService.Edit(novaAvaliacao);
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
        public ResponseUtil GetAvaliacoesFilmeByUsuarioId(Guid UsuarioId)
        {
            var resposta = new ResponseUtil();
            try
            {
                List<Avaliacao> avaliacoes = _avaliacaoService.GetAvaliacoesFilmeByUsuarioId(UsuarioId);
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
            catch (Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Sucesso = false;
            }
            return resposta;
        }
        public ResponseUtil GetAvaliacoesSerieByUsuarioId(Guid UsuarioId)
        {
            var resposta = new ResponseUtil();
            try
            {
                List<Avaliacao> avaliacoes = _avaliacaoService.GetAvaliacoesSeriesByUsuarioId(UsuarioId);
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
            catch (Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Sucesso = false;
            }
            return resposta;
        }
        public ResponseUtil GetAvaliacoesLivroByUsuarioId(Guid UsuarioId)
        {
            var resposta = new ResponseUtil();
            try
            {
                List<Avaliacao> avaliacoes = _avaliacaoService.GetAvaliacoesLivrosByUsuarioId(UsuarioId);
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
                    avaliacao.Classificacao = mediaFinal;
                    _avaliacaoService.Edit(avaliacao);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
