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

            //EX - modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
        }

        //EX - public DbSet<Usuario> Usuarios { get; set; }
    }
}
