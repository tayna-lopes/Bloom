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
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationAppService _authenticationAppService;

        public AuthenticationController(IAuthenticationAppService authenticationAppService)
        {
            _authenticationAppService = authenticationAppService;
        }
    
        //Login
        /// <summary>
        /// Novo Usuario
        /// </summary>
        /// <returns>Sucesso e mensagem</returns>
        /// <response code="200">bool</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("NovoUsuario")]
        public IActionResult NovoUsuario([FromBody] NovoUsuarioModel model)
        {
            model.Email = model.Email?.Trim();
            //checar usuario valido
            var modelValido = _authenticationAppService.ValidarNovoUsuario(model);

            if (!modelValido.Sucesso)
            {
                return BadRequest(new { sucesso = false, mensagem = modelValido.Resultado });
            }

            ResponseUtil response = new ResponseUtil();
            response.Sucesso = _authenticationAppService.NovoUsuario(model);
            response.Resultado = response.Sucesso ? "Conta criada com sucesso." : "Ocorreu um problema";

            if (!response.Sucesso)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Login de usuário.
        /// </summary>
        /// <returns>Token de autenticação</returns>
        /// <response code="200">Token</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        public IActionResult Index([FromBody] LoginModel model)
        {
            var validar = _authenticationAppService.ValidarUsuario(model);
            var resposta = _authenticationAppService.Login(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        
    }
}
