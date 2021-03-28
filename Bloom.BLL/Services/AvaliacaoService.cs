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
