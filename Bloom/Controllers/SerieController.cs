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
    public class SerieController : ControllerBase
    {
        private readonly ISerieAppService _serieAppService;

        public SerieController(ISerieAppService serieAppService)
        {
            _serieAppService = serieAppService;
        }
        /// <summary>
        /// Nova serie
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("NovaSerie")]
        public IActionResult CriarSerie([FromBody] CriarSerieModel model)
        {
            var resposta = _serieAppService.CriarSerie(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Atualizar serie
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("AtualizarSerie")]
        public IActionResult AtualizarSerie([FromBody] AtualizarSerieModel model)
        {
            var resposta = _serieAppService.AtualizarSerie(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Deletar serie
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpDelete]
        [Route("DeletarSerie")]
        public IActionResult DeletarSerie(Guid SerieId)
        {
            var resposta = _serieAppService.DeletarSerie(SerieId);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar todas as series
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetAllSeries")]
        public IActionResult GetAllSeries()
        {
            var resposta = _serieAppService.GetAllSeriess();
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar todas as series cadastrados por um usuário
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetSeriesUsuario")]
        public IActionResult GetAllSeriesUsuario(Guid UsuarioId)
        {
            var resposta = _serieAppService.GetAllSeriesByUser(UsuarioId);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar todas as series adicionados recentemente
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetAdicionadosRecentemente")]
        public IActionResult GetAdicionadosRecentemente()
        {
            var resposta = _serieAppService.GetAdicionadosRecentemente();
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }
    }
}
