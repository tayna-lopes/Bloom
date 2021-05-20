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
    public class AmizadeAppService: IAmizadeAppService
    {
        private readonly IAmizadeService _amizadeService;
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioAppService _usuarioAppService;

        public AmizadeAppService(IAmizadeService amizadeService, IUsuarioService usuarioService,
            IUsuarioAppService usuarioAppService)
        {
            _amizadeService = amizadeService;
            _usuarioService = usuarioService;
            _usuarioAppService = usuarioAppService;
        }

        public ResponseUtil Convite(ConviteModel model)
        {
            var resposta = new ResponseUtil();
            try
            {
                var convidante = _usuarioAppService.GetUserByUsernameConvite(model.ConvidanteUsername);
                if(convidante == null)
                {
                    resposta.Resultado = "Usuario não encontrado";
                    resposta.Resultado = false;
                    return resposta;
                }

                Usuario convidado = _usuarioAppService.GetUserByUsernameConvite(model.ConvidadoUsername);
                if (convidado == null)
                {
                    resposta.Resultado = "Usuario não encontrado";
                    resposta.Resultado = false;
                    return resposta;
                }

                Amizade amizade = new Amizade
                {
                    Id = Guid.NewGuid(),
                    ConvidanteId = convidante.UsuarioId,
                    ConvidadoId = convidado.UsuarioId,
                    Status = StatusAmizade.Pendente
                };

                _amizadeService.Add(amizade);

                resposta.Resultado = amizade.Id;
                resposta.Sucesso = true;
            }
            catch(Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Resultado = false;
            }
            return resposta;
        }
        public ResponseUtil AceitarRecusarConvite(ConviteModel model, bool AceitarAmizade)
        {
            var resposta = new ResponseUtil();
            try
            {
                Usuario convidante = _usuarioService.GetByUsername(model.ConvidanteUsername);
                if (convidante == null)
                {
                    resposta.Resultado = "Usuario não encontrado";
                    resposta.Resultado = false;
                    return resposta;
                }

                Usuario convidado = _usuarioService.GetByUsername(model.ConvidadoUsername);
                if (convidado == null)
                {
                    resposta.Resultado = "Usuario não encontrado";
                    resposta.Resultado = false;
                    return resposta;
                }

                Amizade amizade = _amizadeService.GetAmizadeByAmigosId(convidado.UsuarioId, convidante.UsuarioId);
                if (amizade == null)
                {
                    resposta.Resultado = "Amizade não encontrada";
                    resposta.Resultado = false;
                    return resposta;
                }

                if (AceitarAmizade)
                {
                    amizade.Status = StatusAmizade.Aceita;
                }
                else
                {
                    amizade.Status = StatusAmizade.Recusada;
                }

                _amizadeService.Edit(amizade);

                resposta.Resultado = "Amizade " + amizade.Status;
                resposta.Sucesso = true;
            }
            catch (Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Resultado = false;
            }
            return resposta;
        }
        public ResponseUtil DesfazerAmizade(ConviteModel model)
        {
            var resposta = new ResponseUtil();
            try
            {
                Usuario convidante = _usuarioService.GetByUsername(model.ConvidanteUsername);
                if (convidante == null)
                {
                    resposta.Resultado = "Usuario não encontrado";
                    resposta.Resultado = false;
                    return resposta;
                }

                Usuario convidado = _usuarioService.GetByUsername(model.ConvidadoUsername);
                if (convidado == null)
                {
                    resposta.Resultado = "Usuario não encontrado";
                    resposta.Resultado = false;
                    return resposta;
                }

                Amizade amizade = _amizadeService.GetAmizadeByAmigosId(convidado.UsuarioId, convidante.UsuarioId);

                _amizadeService.Remove(amizade);

                resposta.Resultado = "Amizade desfeita";
                resposta.Sucesso = true;
            }
            catch (Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Resultado = false;
            }
            return resposta;
        }
        public ResponseUtil GetMeusAmigos(Guid UsuarioId)
        {
            var resposta = new ResponseUtil();
            try
            {
                List<Amizade> MeusAmigosList = _amizadeService.GetMeusAmigos(UsuarioId);
                if(MeusAmigosList.Count == 0)
                {
                    resposta.Resultado = "Você ainda não tem nenhum amigo";
                    resposta.Sucesso = false;
                    return resposta;
                }
                resposta.Resultado = MeusAmigosList;
                resposta.Sucesso = true;
            }
            catch (Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Resultado = false;
            }
            return resposta;
        }
        public ResponseUtil GetMinhasSolicitacoesDeAmizade(Guid UsuarioId)
        {
            var resposta = new ResponseUtil();
            try
            {
                List<Amizade> MinhasSolicitacoesList = _amizadeService.GetMeusConvitesDeAmizade(UsuarioId);
                if (MinhasSolicitacoesList.Count == 0)
                {
                    resposta.Resultado = "Você não tem nenhuma solicitação de amizade";
                    resposta.Sucesso = false;
                    return resposta;
                }
                resposta.Resultado = MinhasSolicitacoesList;
                resposta.Sucesso = true;
            }
            catch (Exception e)
            {
                resposta.Resultado = e.Message;
                resposta.Resultado = false;
            }
            return resposta;
        }
    }
}
