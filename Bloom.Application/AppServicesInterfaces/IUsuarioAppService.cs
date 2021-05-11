using Bloom.Application.Models;
using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.AppServicesInterfaces
{
    public interface IUsuarioAppService
    {
        ResponseUtil GetInformacoesUser(string userEmail);
        ResponseUtil AtualizarUsuario(UpdateUserModel model);
    }
}
