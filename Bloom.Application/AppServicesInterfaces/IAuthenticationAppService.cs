using Bloom.Application.Models;
using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.AppServicesInterfaces
{
    public interface IAuthenticationAppService
    {
        ResponseUtil ValidarNovoUsuario(NovoUsuarioModel model);
        bool NovoUsuario(NovoUsuarioModel model);
        ResponseUtil ValidarUsuario(LoginModel model);
        ResponseUtil Login(LoginModel model);
        
    }
}
