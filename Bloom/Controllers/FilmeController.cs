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
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeAppService _filmeAppService;

        public FilmeController(IFilmeAppService filmeAppService)
        {
            _filmeAppService = filmeAppService;
        }
        //Filme
        /// <summary>
        /// Novo Filme
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("NovoFilme")]
        public IActionResult CriarFilme([FromForm] CriarFilmeModel model)
        {
            var resposta = _filmeAppService.CriarFilme(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Atualizar Filme
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("AtualizarFilme")]
        public IActionResult AtualizarFilme([FromForm] AtualizarFilmeModel model)
        {
            var resposta = _filmeAppService.AtualizarFilme(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar todos os Filmes
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetAllFilmes")]
        public IActionResult GetAllFilmes()
        {
            var resposta = _filmeAppService.GetAllFilmes();
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar todos os Filmes cadastrados por um usuário
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetFilmesUsuario")]
        public IActionResult GetAllFilmesUsuario(Guid UsuarioId)
        {
            var resposta = _filmeAppService.GetAllFilmesByUser(UsuarioId);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar todos os Filmes adicionados recentemente
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetAdicionadosRecentemente")]
        public IActionResult GetAdicionadosRecentemente()
        {
            var resposta = _filmeAppService.GetAdicionadosRecentemente();
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Deletar filme
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpDelete]
        [Route("DeletarFilme")]
        public IActionResult DeletarFilme(Guid livroId)
        {
            var resposta = _filmeAppService.DeletarFilme(livroId);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }
    }
}
