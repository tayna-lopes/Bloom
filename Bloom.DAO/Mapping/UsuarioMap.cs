using Bloom.BLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Bloom.DAO.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.UsuarioId);

            builder.Property(t => t.Criado)
                .IsRequired()
                .HasDefaultValue(new DateTime(2010, 1, 1));

            builder.Property(t => t.Alterado)
                .IsRequired()
                .HasDefaultValue(new DateTime(2010, 1, 1));

            builder.Property(t => t.AlteradoPor)
                .IsRequired()
                .HasDefaultValue(new Guid());
            builder.Property(x => x.Email);
            builder.Property(x => x.Senha);
            builder.Property(x => x.Nome);
            builder.Property(x => x.Username);
            builder.Property(x => x.Cidade);
            builder.Property(x => x.Estado);
            builder.Property(x => x.IsAdmin);
            builder.Property(x => x.DataDeNascimento)
                .HasDefaultValue(new DateTime(2010, 1, 1));
            builder.Property(x => x.Foto);
        }
    }
}

