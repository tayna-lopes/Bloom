using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.RepositoriesInterfaces
{
    public interface IComentarioRepository : IRepositoryBase<Comentario>
    {
        List<Comentario> GetComentariosByAvaliacaoId(Guid AvaliacaoId);
    }
}
