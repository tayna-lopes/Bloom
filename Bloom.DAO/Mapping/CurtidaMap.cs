using Bloom.BLL.Entities;
using Bloom.BLL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.DAO.Mapping
{
    public class CurtidaMap : IEntityTypeConfiguration<Curtida>
    {
        public void Configure(EntityTypeBuilder<Curtida> builder)
        {
            builder.ToTable("Curtida");

            builder.HasKey(e => e.Id);
            builder.Property(x => x.TipoAvaliacao);
            builder.Property(x => x.UsuarioId);
            builder.Property(x => x.FilmeId).HasDefaultValue(null);
            builder.Property(x => x.LivroId).HasDefaultValue(null);
            builder.Property(x => x.SerieId).HasDefaultValue(null);
            builder.Property(x => x.TipoAvaliacao)
                .HasConversion(
                    x => x.ToString(),
                    x => (TipoAvaliacao)Enum.Parse(typeof(TipoAvaliacao), x))
                .HasDefaultValue(TipoAvaliacao.Filme);
        }
    }
}
