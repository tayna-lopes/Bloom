using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.RepositoriesInterfaces
{
    public interface ILivroRepository : IRepositoryBase<Livro>
    {
        Livro GetByName(string nome);
        List<Livro> GetAllLivrosByUsuarioId(Guid UsuarioId);
        List<Livro> GetAdicionadosRecentemente();
    }
}
