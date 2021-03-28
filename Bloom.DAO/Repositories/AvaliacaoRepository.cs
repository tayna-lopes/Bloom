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
    public class AvaliacaoRepository : RepositoryBase<Avaliacao>, IAvaliacaoRepository
    {
        private readonly DbSet<Avaliacao> _avaliacoes;

        public AvaliacaoRepository(BloomContext context, IConfiguration configuration)
            : base(context, configuration)
        {
            _avaliacoes = _context.Avaliacoes;
        }
    }
}
