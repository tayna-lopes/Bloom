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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        //Buscas
        /// <summary>
        /// Busca usuário por username
        /// </summary>
        /// <returns>Token de autenticação</returns>
        /// <response code="200">Token</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetUserByUsername")]
        public IActionResult GetUserByUsername(string username)
        {
            var resposta = _usuarioAppService.GetUserByUsername(username);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        //Perfil
        /// <summary>
        /// Retorna as informações do usuário
        /// </summary>
        /// <returns>Token de autenticação</returns>
        /// <response code="200">Token</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetInformacoesUser")]
        public IActionResult GetInformacoesUser(string userEmail)
        {
            var resposta = _usuarioAppService.GetInformacoesUser(userEmail);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Atualiza as informações do usuário
        /// </summary>
        /// <returns>Token de autenticação</returns>
        /// <response code="200">Token</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("AtualizarUsuario")]
        public IActionResult AtualizarUsuario([FromForm] UpdateUserModel model)
        {
            var resposta = _usuarioAppService.AtualizarUsuario(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Retorna a média de amigos
        /// </summary>
        /// <returns>Token de autenticação</returns>
        /// <response code="200">Token</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetMediaDeAmigos")]
        public IActionResult GetMediaDeAmigos()
        {
            var resposta = _usuarioAppService.GetMediaDeAmigos();
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        //Admin
        /// <summary>
        /// Dados para o gráfico de visualização do admin
        /// </summary>
        /// <returns>Token de autenticação</returns>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("Admin/GraficoUsuariosByEstado")]
        public IActionResult GraficoUsuariosByEstado()
        {
            var resposta = _usuarioAppService.GraficoUsuariosByEstado();
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Retorna os 10 usuários mais conectados
        /// </summary>
        /// <returns>Token de autenticação</returns>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("Admin/GetMaisConectados")]
        public IActionResult GetMaisConectados(int take)
        {
            var resposta = _usuarioAppService.GetMaisConectados(take);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar séries para aprovação
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("Admin/GetSeriesParaAprovacao")]
        public IActionResult GetSeriesParaAprovacao()
        {
            var resposta = _usuarioAppService.GetSeriesParaAprovacao();
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Aprovar ou recusar série
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("Admin/AprovarRecusarSerie")]
        public IActionResult AprovarRecusarSerie(Guid serieId, bool Aprovar)
        {
            var resposta = _usuarioAppService.AprovarRecusarSerie(serieId, Aprovar);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar filmes para aprovação
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("Admin/GetFilmesParaAprovacao")]
        public IActionResult GetFilmesParaAprovacao()
        {
            var resposta = _usuarioAppService.GetFilmesParaAprovacao();
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Aprovar ou recusar filme
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("Admin/AprovarRecusarFilme")]
        public IActionResult AprovarRecusarFilme(Guid FilmeId, bool Aprovar)
        {
            var resposta = _usuarioAppService.AprovarRecusarFilmes(FilmeId, Aprovar);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Buscar livros para aprovação
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("Admin/GetLivrosParaAprovacao")]
        public IActionResult GetLivrosParaAprovacao()
        {
            var resposta = _usuarioAppService.GetLivrosParaAprovacao();
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Aprovar ou recusar livro
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("Admin/AprovarRecusarLivro")]
        public IActionResult AprovarRecusarLivro(Guid LivroId, bool Aprovar)
        {
            var resposta = _usuarioAppService.AprovarRecusarLivro(LivroId, Aprovar);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }


    }
}
