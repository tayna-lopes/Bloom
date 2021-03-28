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
    public class AmizadeRepository : RepositoryBase<Amizade>, IAmizadeRepository
    {
        private readonly DbSet<Amizade> _amizades;

        public AmizadeRepository(BloomContext context, IConfiguration configuration)
            : base(context, configuration)
        {
            _amizades = _context.Amizades;
        }

        public List<Amizade> GetMeusAmigos(Guid UsuarioId)
        {
            return _amizades.Where(x => x.ConvidadoId == UsuarioId || x.ConvidanteId == UsuarioId && x.Status == StatusAmizade.Aceita).ToList();
        }
        
        public List<Amizade> GetMeusConvitesDeAmizade(Guid UsuarioId)
        {
            return _amizades.Where(x => x.ConvidadoId == UsuarioId && x.Status == StatusAmizade.Pendente).ToList();
        }
    }
}
