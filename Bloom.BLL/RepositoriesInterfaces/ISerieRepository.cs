using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.RepositoriesInterfaces
{
    public interface ISerieRepository : IRepositoryBase<Serie>
    {
        Serie GetByName(string nome);
        List<Serie> GetAllSeriesByUsuarioId(Guid UsuarioId);
        List<Serie> GetAdicionadosRecentemente();
    }
}
