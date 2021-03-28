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
    }
}
