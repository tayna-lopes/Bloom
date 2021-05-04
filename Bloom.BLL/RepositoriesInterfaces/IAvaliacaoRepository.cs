using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.RepositoriesInterfaces
{
    public interface IAvaliacaoRepository : IRepositoryBase<Avaliacao>
    {
        List<int> GetNotasFilme(Guid FilmeId);
        List<int> GetNotasLivro(Guid LivroId);
        List<int> GetNotasSerie(Guid SerieId);
        List<Avaliacao> GetAvaliacaoFilmesId(Guid FilmesId);
        List<Avaliacao> GetAvaliacaoSerieId(Guid SerieId);
        List<Avaliacao> GetAvaliacaoLivroId(Guid LivroId);
    }
}
