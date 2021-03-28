using Bloom.BLL.Entities;
using Bloom.BLL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.DAO.Mapping
{
    public class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Filme");

            builder.HasKey(e => e.Id);
            builder.Property(x => x.Titulo);
            builder.Property(x => x.Classificacao);
            builder.Property(x => x.Diretor);
            builder.Property(x => x.Elenco);
            builder.Property(x => x.Pais);
            builder.Property(x => x.Ano);
            builder.Property(x => x.UsuarioId);
            builder.Property(x => x.Genero)
                .HasConversion(
                    x => x.ToString(),
                    x => (Genero)Enum.Parse(typeof(Genero), x))
                .HasDefaultValue(Genero.Aventura);
            builder.Property(x => x.Status)
                .HasConversion(
                    x => x.ToString(),
                    x => (StatusAvaliacao)Enum.Parse(typeof(StatusAvaliacao), x))
                .HasDefaultValue(StatusAvaliacao.Pendente);
            builder.Property(t => t.Adicionado)
              .IsRequired()
              .HasDefaultValue(new DateTime(2010, 1, 1));
        }
    }
}
