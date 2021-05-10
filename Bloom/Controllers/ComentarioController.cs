using Bloom.Application.AppServicesInterfaces;
using Bloom.Application.Models;
using Bloom.BLL.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloom.Controllers
{
    [Route("api/[controller]")]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioAppService _comentarioAppService;

        public ComentarioController(IComentarioAppService comentarioAppService)
        {
            _comentarioAppService = comentarioAppService;
        }
        /// <summary>
        /// Comentar avaliação
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("NovoComentario")]
        public IActionResult NovoComentario([FromBody] NovoComentarioModel model)
        {
            var resposta = _comentarioAppService.ComentarioAvaliacao(model);
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
        [Route("EditarComentario")]
        public IActionResult EditarComentario([FromBody] EditarComentarioModel model)
        {
            var resposta = _comentarioAppService.EditarComentario(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Deletar comentario
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpDelete]
        [Route("DeletarComentario")]
        public IActionResult DeletarComentario([FromBody] DeletarComentarioModel model)
        {
            var resposta = _comentarioAppService.DeletarComentario(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar todos comentarios da avaliação
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetAllComentariosByAvaliacaoId")]
        public IActionResult GetAllComentariosByAvaliacaoId(Guid AvaliacaoId)
        {
            var resposta = _comentarioAppService.GetComentariosByAvaliacaoId(AvaliacaoId);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }
    }
}
