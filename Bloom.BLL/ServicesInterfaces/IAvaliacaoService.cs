using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.ServicesInterfaces
{
    public interface IAvaliacaoService : IServiceBase<Avaliacao>
    {
        List<int> GetNotasFilme(Guid FilmeId);
        List<int> GetNotasLivro(Guid LivroId);
        List<int> GetNotasSerie(Guid SerieId);
    }
}
