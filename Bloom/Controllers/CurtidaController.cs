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
    public class CurtidaController : ControllerBase
    {
        private readonly ICurtidaAppService _curtidaAppService;

        public CurtidaController(ICurtidaAppService curtidaAppService)
        {
            _curtidaAppService = curtidaAppService;
        }
        /// <summary>
        /// Curtir avaliação
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("CurtirCurtida")]
        public IActionResult CurtirAvaliacao([FromBody] CurtirAvaliacaoModel model)
        {
            var resposta = _curtidaAppService.CurtirAvaliacao(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Descurtir avaliação
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpDelete]
        [Route("DescurtirCurtida")]
        public IActionResult DescurtirAvaliacao(Guid AvaliacaoId)
        {
            var resposta = _curtidaAppService.DescurtirAvaliacao(AvaliacaoId);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar todas as curtidas de uma avaliação
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetAllCurtidasByAvaliacaoId")]
        public IActionResult GetAllCurtidasByAvaliacaoId(Guid AvaliacaoId)
        {
            var resposta = _curtidaAppService.GetTodasCurtidasAvaliacaoIdId(AvaliacaoId);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }
    }
}
