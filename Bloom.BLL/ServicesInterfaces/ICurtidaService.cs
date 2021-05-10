using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.ServicesInterfaces
{
    public interface ICurtidaService : IServiceBase<Curtida>
    {
        List<Curtida> GetCurtidasFilmesId(Guid FilmesId);
        List<Curtida> GetCurtidasSerieId(Guid SerieId);
        List<Curtida> GetCurtidasLivroId(Guid LivroId);
        List<Curtida> GetCurtidasAvaliacaoId(Guid AvaliacaoId);
    }
}
