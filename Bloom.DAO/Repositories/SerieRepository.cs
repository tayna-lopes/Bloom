using Bloom.BLL.Entities;
using Bloom.BLL.RepositoriesInterfaces;
using Bloom.DAO.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bloom.DAO.Repositories
{
    public class SerieRepository : RepositoryBase<Serie>, ISerieRepository
    {
        private readonly DbSet<Serie> _series;

        public SerieRepository(BloomContext context, IConfiguration configuration)
            : base(context, configuration)
        {
            _series = _context.Series;
        }

        public List<Serie> GetAdicionadosRecentemente()
        {
            var sday = DateTime.Now.Date.AddDays(-10);
            return _series.Where(x => x.Adicionado.Date == sday).ToList();
        }

        public List<Serie> GetAllSeriesByUsuarioId(Guid UsuarioId)
        {
            return _series.Where(x => x.UsuarioId == UsuarioId).ToList();
        }

        public Serie GetByName(string nome)
        {
            return _series.Where(x => x.Titulo == nome).FirstOrDefault();
        }
    }
}
