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
    public class FilmeRepository : RepositoryBase<Filme>, IFilmeRepository
    {
        private readonly DbSet<Filme> _filmes;

        public FilmeRepository(BloomContext context, IConfiguration configuration)
            : base(context, configuration)
        {
            _filmes = _context.Filmes;
        }
    }
}
