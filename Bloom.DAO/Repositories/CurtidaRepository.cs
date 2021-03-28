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
    }
}
