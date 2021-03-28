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
    public class ComentarioRepository : RepositoryBase<Comentario>, IComentarioRepository
    {
        private readonly DbSet<Comentario> _comentarios;

        public ComentarioRepository(BloomContext context, IConfiguration configuration)
            : base(context, configuration)
        {
            _comentarios = _context.Comentarios;
        }
    }
}
