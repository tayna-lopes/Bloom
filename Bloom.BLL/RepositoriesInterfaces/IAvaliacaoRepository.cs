using Bloom.BLL.Entities;
using Bloom.BLL.Enums;
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
        List<Avaliacao> GetAvaliacaoMidia(Guid UsuarioId, TipoAvaliacao tipo);
    }
}
