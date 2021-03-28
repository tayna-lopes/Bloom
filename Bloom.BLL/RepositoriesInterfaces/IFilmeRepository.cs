using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.RepositoriesInterfaces
{
    public interface IFilmeRepository : IRepositoryBase<Filme>
    {
        Filme GetByName(string nome);
        List<Filme> GetAllFilmesByUsuarioId(Guid UsuarioId);
        List<Filme> GetAdicionadosRecentemente();
    }
}
