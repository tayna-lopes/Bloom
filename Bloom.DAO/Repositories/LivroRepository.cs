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
    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {
        private readonly DbSet<Livro> _livros;

        public LivroRepository(BloomContext context, IConfiguration configuration)
            : base(context, configuration)
        {
            _livros = _context.Livros;
        }
    }
}
