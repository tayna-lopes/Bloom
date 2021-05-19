using Bloom.Application.AppServicesInterfaces;
using Bloom.Application.Models;
using Bloom.BLL.Enums;
using Bloom.BLL.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloom.Controllers
{
    [Route("api/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoAppService _avaliacaoAppService;

        public AvaliacaoController(IAvaliacaoAppService avaliacaoAppService)
        {
            _avaliacaoAppService = avaliacaoAppService;
        }
        /// <summary>
        /// Avaliação de midia
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("NovaAvaliacao")]
        public IActionResult Convidar([FromBody] NovaAvaliacaoModel model)
        {
            var resposta = _avaliacaoAppService.NovaAvaliacao(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Editar avaliação
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("EditarAvaliacao")]
        public IActionResult EditarAvaliacao([FromBody] EditarAvaliacaoModel model)
        {
            var resposta = _avaliacaoAppService.EditarAvaliacao(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Excluir avaliação
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpDelete]
        [Route("DeletarAvaliacao")]
        public IActionResult DeletarAvaliacao([FromBody] DeletarAvaliacaoModel model)
        {
            var resposta = _avaliacaoAppService.DeletarAvaliacao(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar avaliaçõess de uma midia especifica
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetTodasAvaliacoesMidiaId")]
        public IActionResult GetTodasAvaliacoesMediaId(Guid MidiaId, TipoAvaliacao TipoAvaliacao)
        {
            GetTodasAvaliacoesMidiaModel model = new GetTodasAvaliacoesMidiaModel();
            if (TipoAvaliacao == TipoAvaliacao.Filme)
            {    
                model.FilmeId = MidiaId;
            }
            if (TipoAvaliacao == TipoAvaliacao.Serie)
            {
                model.SerieId = MidiaId;
            }
            if (TipoAvaliacao == TipoAvaliacao.Livro)
            {
                model.LivroId = MidiaId;
            }
            var resposta = _avaliacaoAppService.GetTodasAvaliacoesMediaId(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar todas as avaliações de filme do usuário
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetAvaliacoesMidiaByUsuarioId")]
        public IActionResult GetAvaliacoesMidiaByUsuarioId(Guid UsuarioId, TipoAvaliacao tipo)
        {
            var resposta = _avaliacaoAppService.GetAvaliacoesMidiaByUsuarioId(UsuarioId,tipo);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }



    }
}
