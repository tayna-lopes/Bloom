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
    public class LivroController : ControllerBase
    {
        private readonly ILivroAppService _livroAppService;

        public LivroController(ILivroAppService livroAppService)
        {
            _livroAppService = livroAppService;
        }

        /// <summary>
        /// Novo livro
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("NovoLivro")]
        public IActionResult CriarLivro([FromForm] CriarLivroModel model)
        {
            var resposta = _livroAppService.CriarLivro(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Atualizar Livro
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("AtualizarLivro")]
        public IActionResult AtualizarLivro([FromForm] AtualizarLivroModel model)
        {
            var resposta = _livroAppService.AtualizarLivro(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Deletar livro
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpDelete]
        [Route("DeletarLivro")]
        public IActionResult DeletarLivro(Guid livroId)
        {
            var resposta = _livroAppService.DeletarFilme(livroId);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar todos os Livros
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetAllLivros")]
        public IActionResult GetAllFilmes()
        {
            var resposta = _livroAppService.GetAllLivros();
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar todos os livros cadastrados por um usuário
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetLivrosUsuario")]
        public IActionResult GetAllFilmesUsuario(Guid UsuarioId)
        {
            var resposta = _livroAppService.GetAllLivrosByUser(UsuarioId);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar todos os Livros adicionados recentemente
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetAdicionadosRecentemente")]
        public IActionResult GetAdicionadosRecentemente()
        {
            var resposta = _livroAppService.GetAdicionadosRecentemente();
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }
    }
}
