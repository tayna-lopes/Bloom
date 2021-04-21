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
    public class AmizadeController: ControllerBase
    {
        private readonly IAmizadeAppService _amizadeAppService;

        public AmizadeController(IAmizadeAppService amizadeAppService)
        {
            _amizadeAppService = amizadeAppService;
        }

        /// <summary>
        /// Solicitação amizade
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("Convidar")]
        public IActionResult Convidar([FromBody] ConviteModel model)
        {
            var resposta = _amizadeAppService.Convite(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Aceitar ou recusar amizade
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("AceitarRecusarAmizade")]
        public IActionResult AceitarRecusarAmizade([FromBody] ConviteModel model, bool AceitarAmizade)
        {
            var resposta = _amizadeAppService.AceitarRecusarConvite(model, AceitarAmizade);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Desfazer amizade
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpDelete]
        [Route("DesfazerAmizade")]
        public IActionResult DesfazerAmizade([FromBody] ConviteModel model)
        {
            var resposta = _amizadeAppService.DesfazerAmizade(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar meus amigos
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetMeusAmigos")]
        public IActionResult GetMeusAmigos(Guid UsuarioId)
        {
            var resposta = _amizadeAppService.GetMeusAmigos(UsuarioId);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar meus pedidos de amizade
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetMeusPedidosDeAmizade")]
        public IActionResult GetMeusPedidosDeAmizade(Guid UsuarioId)
        {
            var resposta = _amizadeAppService.GetMinhasSolicitacoesDeAmizade(UsuarioId);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }


    }
}
