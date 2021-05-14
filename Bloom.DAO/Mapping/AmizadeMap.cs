using Bloom.BLL.Entities;
using Bloom.BLL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.DAO.Mapping
{
    public class AmizadeMap : IEntityTypeConfiguration<Amizade>
    {
        public void Configure(EntityTypeBuilder<Amizade> builder)
        {
            builder.ToTable("Amizade");

            builder.HasKey(e => e.Id);
            builder.Property(x => x.ConvidadoId);
            builder.HasOne(x => x.Convidante).WithMany(x => x.Convidados).HasForeignKey(x=> x.ConvidanteId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Convidado).WithMany(x => x.Convites).HasForeignKey(x=> x.ConvidadoId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.Status)
                .HasConversion(
                    x => x.ToString(),
                    x => (StatusAmizade)Enum.Parse(typeof(StatusAmizade), x))
                .HasDefaultValue(StatusAmizade.Pendente);
        }
    }
}
