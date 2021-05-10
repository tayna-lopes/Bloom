using System;
using System.Collections.Generic;
using System.Text;
using Bloom.BLL.Entities;
using Bloom.BLL.RepositoriesInterfaces;
using Bloom.BLL.ServicesInterfaces;

namespace Bloom.BLL.Services
{
    public class CurtidaService : ServiceBase<Curtida>, ICurtidaService
    {
        private readonly ICurtidasRepository _CurtidasRepository;

        public CurtidaService(ICurtidasRepository CurtidasRepository) : base(CurtidasRepository)
        {
            _CurtidasRepository = CurtidasRepository;
        }

        public List<Curtida> GetCurtidasAvaliacaoId(Guid AvaliacaoId)
        {
            return _CurtidasRepository.GetCurtidasAvaliacaoId(AvaliacaoId);
        }

        public List<Curtida> GetCurtidasFilmesId(Guid FilmesId)
        {
            return _CurtidasRepository.GetCurtidasFilmesId(FilmesId);
        }

        public List<Curtida> GetCurtidasLivroId(Guid LivroId)
        {
            return _CurtidasRepository.GetCurtidasLivroId(LivroId);
        }

        public List<Curtida> GetCurtidasSerieId(Guid SerieId)
        {
            return _CurtidasRepository.GetCurtidasSerieId(SerieId);
        }
    }
}
