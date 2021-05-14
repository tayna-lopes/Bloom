using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.RepositoriesInterfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario GetByEmail(string email);
        Usuario GetByUsername(string username);
        bool ValidarUsername(string username);
        List<Usuario> GetAllUsuarios();
    }
}
