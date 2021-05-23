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
    public class ComentarioAppService : IComentarioAppService
    {
        private readonly IComentarioService _comentarioService;
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IUsuarioService _usuarioService;
        private readonly IAmizadeService _amizadeService;
        public ComentarioAppService(IComentarioService comentarioService, IAvaliacaoService avaliacaoService, IUsuarioService usuarioService, IAmizadeService amizadeService)
        {
            _comentarioService = comentarioService;
            _avaliacaoService = avaliacaoService;
            _usuarioService = usuarioService;
            _amizadeService = amizadeService;
        }
        public ResponseUtil ComentarioAvaliacao(NovoComentarioModel model)
        {
            var resposta = new ResponseUtil();
            try
            {
                Avaliacao avaliacao = _avaliacaoService.GetById(model.AvaliacaoId);
                Amizade amizade = _amizadeService.GetAmizadeByAmigosId(model.UsuarioId, avaliacao.UsuarioId);
                if(amizade == null)
                {
                    resposta.Resultado = "Não é possivel comentar, pois usuários não são amigos";
                    resposta.Sucesso = false;
                    return resposta;
                }
                if (avaliacao != null)
                {
                    Comentario comentario = new Comentario
                    {
                        Id = Guid.NewGuid(),
                        Texto = model.Texto,
                        UsuarioId = model.UsuarioId,
                        LivroId = avaliacao.LivroId,
                        FilmeId = avaliacao.FilmeId,
                        SerieId = avaliacao.SerieId,
                        AvaliacaoId = avaliacao.Id,
                        TipoAvaliacao = avaliacao.TipoAvaliacao
                    };
                    _comentarioService.Add(comentario);
                    resposta.Resultado = "Avaliação comentada";
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
        public ResponseUtil EditarComentario(EditarComentarioModel model)
        {
            var resposta = new ResponseUtil();
            try
            {
                Comentario comentario = _comentarioService.GetById(model.ComentarioId);
                if (model.UsuarioId != comentario.UsuarioId)
                {
                    resposta.Resultado = "Este usuário não tem permissão para editar o comentario";
                    resposta.Sucesso = false;
                    return resposta;
                }
                if (comentario != null)
                {
                    Usuario usuario = _usuarioService.GetById(model.UsuarioId);
                    
                    comentario.Texto = model.Texto;
                    _comentarioService.Edit(comentario);
                    resposta.Resultado = "Comentario editado";
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
        public ResponseUtil DeletarComentario(string model)
        {
            var resposta = new ResponseUtil();
            try
            {
                Comentario comentario = _comentarioService.GetById(Guid.Parse(model));

                if (comentario != null)
                {
                    _comentarioService.Remove(comentario);
                    resposta.Resultado = "Comentario excluido";
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
        public ResponseUtil GetComentariosByAvaliacaoId(Guid AvaliacaoId)
        {
            var resposta = new ResponseUtil();
            try
            {
                List<Comentario> comentarios = _comentarioService.GetComentariosByAvaliacaoId(AvaliacaoId);
                List<ComentarioResponse> listComentarios = new List<ComentarioResponse>();
                comentarios.ForEach(x =>
               {
                   ComentarioResponse comentario = new ComentarioResponse
                   {
                       Texto = x.Texto,
                       Username = x.Usuario.Username,
                       id = x.Id.ToString()
                   };
                   listComentarios.Add(comentario);
               });
                resposta.Resultado = listComentarios;
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
