using Bloom.Application.AppServicesInterfaces;
using Bloom.Application.Models;
using Bloom.BLL.Entities;
using Bloom.BLL.ServicesInterfaces;
using Bloom.BLL.Utils;
using Cryptography;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.AppServicesInterfaces
{
    public class CurtidaAppService : ICurtidaAppService
    {
        private readonly ICurtidaService _curtidaService;
        private readonly IAvaliacaoService _avaliacaoService;
        public CurtidaAppService(ICurtidaService curtidaService,IAvaliacaoService avaliacaoService)
        {
            _curtidaService = curtidaService;
            _avaliacaoService = avaliacaoService;
        }
        public ResponseUtil CurtirAvaliacao(CurtirAvaliacaoModel model)
        {
            var resposta = new ResponseUtil();
            try
            {
                Avaliacao avaliacao = _avaliacaoService.GetById(model.AvaliacaoId);
                if(avaliacao == null)
                {
                    resposta.Resultado = "Avaliação não existe";
                    resposta.Sucesso = true;
                }
                if(avaliacao != null)
                {
                    Curtida novaCurtida = new Curtida
                    {
                        Id = Guid.NewGuid(),
                        UsuarioId = model.UsuarioId,
                        LivroId = avaliacao.LivroId,
                        FilmeId = avaliacao.FilmeId,
                        SerieId = avaliacao.SerieId,
                        AvaliacaoId = avaliacao.Id,
                        TipoAvaliacao = avaliacao.TipoAvaliacao
                    };
                    _curtidaService.Add(novaCurtida);
                }
                resposta.Resultado = "Avaliação curtida";
                resposta.Sucesso = true;
            }
            catch (Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Sucesso = false;
            }
            return resposta;
        }
        public ResponseUtil DescurtirAvaliacao(Guid CurtidaId)
        {
            var resposta = new ResponseUtil();
            try
            {
                Curtida curtida = _curtidaService.GetById(CurtidaId);
                if(curtida != null)
                {
                    _curtidaService.Remove(curtida);
                }
                resposta.Resultado = "Avaliação descurtida";
                resposta.Sucesso = true;
            }
            catch (Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Sucesso = false;
            }
            return resposta;
        }
        public ResponseUtil GetTodasCurtidasAvaliacaoIdId(Guid AvaliacaoId)
        {
            var resposta = new ResponseUtil();
            try
            {
                List<Curtida> curtidas = _curtidaService.GetCurtidasAvaliacaoId(AvaliacaoId);
                List<CurtidasResponse> listCurtidas = new List<CurtidasResponse>();
                curtidas.ForEach(x =>
                {
                    CurtidasResponse curtidasResponse = new CurtidasResponse
                    {
                        CurtidaId = x.Id,
                        UsuarioId = x.UsuarioId
                    };
                    listCurtidas.Add(curtidasResponse);
                });
                resposta.Resultado = listCurtidas;
                resposta.Sucesso = true;
            }
            catch (Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Sucesso = false;
            }
            return resposta;
        }
    }
}
