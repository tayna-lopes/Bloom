using Bloom.BLL.Entities;
using Bloom.BLL.RepositoriesInterfaces;
using Bloom.BLL.ServicesInterfaces;
using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.Services
{
    public class SerieService : ServiceBase<Serie>, ISerieService
    {
        private readonly ISerieRepository _serieRepository;

        public SerieService(ISerieRepository serieRepository) : base(serieRepository)
        {
            _serieRepository = serieRepository;
        }

        public List<Serie> GetAdicionadosRecentemente()
        {
            return _serieRepository.GetAdicionadosRecentemente();
        }
        public List<Serie> GetAllSeriesByUsuarioId(Guid UsuarioId)
        {
            return _serieRepository.GetAllSeriesByUsuarioId(UsuarioId);
        }
        public Serie GetByName(string nome)
        {
            return _serieRepository.GetByName(nome);
        }
        public List<Serie> GetSeriesParaAprovacao()
        {
            return _serieRepository.GetSeriesParaAprovacao();
        }
    }
}
