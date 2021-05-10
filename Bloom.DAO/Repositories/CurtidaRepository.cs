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
    public class CurtidaRepository : RepositoryBase<Curtida>, ICurtidasRepository
    {
        private readonly DbSet<Curtida> _curtidas;

        public CurtidaRepository(BloomContext context, IConfiguration configuration)
            : base(context, configuration)
        {
            _curtidas = _context.Curtidas;
        }
        public List<Curtida> GetCurtidasFilmesId(Guid FilmesId)
        {
            return _curtidas.Where(x => x.FilmeId == FilmesId).ToList();
        }
        public List<Curtida> GetCurtidasSerieId(Guid SerieId)
        {
            return _curtidas.Where(x => x.SerieId == SerieId).ToList();
        }
        public List<Curtida> GetCurtidasLivroId(Guid LivroId)
        {
            return _curtidas.Where(x => x.LivroId == LivroId).ToList();
        }
        public List<Curtida> GetCurtidasAvaliacaoId(Guid AvaliacaoId)
        {
            return _curtidas.Where(x => x.AvaliacaoId == AvaliacaoId).ToList();
        }
    }
}
