using System;
using System.Collections.Generic;
using System.Text;
using Bloom.BLL.Entities;
using Bloom.BLL.RepositoriesInterfaces;
using Bloom.BLL.ServicesInterfaces;

namespace Bloom.BLL.Services
{
    public class AvaliacaoService : ServiceBase<Avaliacao>, IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService(IAvaliacaoRepository avaliacaoRepository) : base(avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        public List<Avaliacao> GetAvaliacaoFilmesId(Guid FilmesId)
        {
            return _avaliacaoRepository.GetAvaliacaoFilmesId(FilmesId);
        }

        public List<Avaliacao> GetAvaliacaoLivroId(Guid LivroId)
        {
            return _avaliacaoRepository.GetAvaliacaoLivroId(LivroId);
        }

        public List<Avaliacao> GetAvaliacaoSerieId(Guid SerieId)
        {
            return _avaliacaoRepository.GetAvaliacaoSerieId(SerieId);
        }

        public List<int> GetNotasFilme(Guid FilmeId)
        {
            return _avaliacaoRepository.GetNotasFilme(FilmeId);
        }

        public List<int> GetNotasLivro(Guid LivroId)
        {
            return _avaliacaoRepository.GetNotasLivro(LivroId);
        }

        public List<int> GetNotasSerie(Guid SerieId)
        {
            return _avaliacaoRepository.GetNotasSerie(SerieId);
        }
    }
}
