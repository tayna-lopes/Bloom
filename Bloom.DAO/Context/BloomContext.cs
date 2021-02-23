using Bloom.BLL.Entities;
using Bloom.DAO.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.DAO.Context
{
    public class BloomContext : DbContext
    {
        public BloomContext(DbContextOptions<BloomContext> contextOptions) : base(contextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
