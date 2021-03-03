using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.RepositoriesInterfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario GetByEmail(string email);
        bool ValidarUsername(string username);
    }
}
