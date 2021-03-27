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
            modelBuilder.Entity<Filme>(new FilmeMap().Configure);
            modelBuilder.Entity<Serie>(new SerieMap().Configure);
            modelBuilder.Entity<Livro>(new LivroMap().Configure);
            modelBuilder.Entity<Avaliacao>(new AvaliacaoMap().Configure);
            modelBuilder.Entity<Comentario>(new ComentarioMap().Configure);
            modelBuilder.Entity<Amizade>(new AmizadeMap().Configure);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Amizade> Amizades { get; set; }
    }
}
