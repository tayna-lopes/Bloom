using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.ServicesInterfaces
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        bool ValidarUsuario(string usuarioId);
        Usuario GetByEmail(string email);
        bool ValidarUsername(string username);
    }
}
