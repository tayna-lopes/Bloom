using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.RepositoriesInterfaces
{
    public interface IAvaliacaoRepository : IRepositoryBase<Avaliacao>
    {
        List<Avaliacao> GetAvaliacaoFilmesId(Guid FilmesId);
        List<Avaliacao> GetAvaliacaoSerieId(Guid SerieId);
        List<Avaliacao> GetAvaliacaoLivroId(Guid LivroId);
        List<Avaliacao> GetAvaliacoesFilmeByUsuarioId(Guid UsuarioId);
        List<Avaliacao> GetAvaliacoesSeriesByUsuarioId(Guid UsuarioId);
        List<Avaliacao> GetAvaliacoesLivrosByUsuarioId(Guid UsuarioId);
    }
}
