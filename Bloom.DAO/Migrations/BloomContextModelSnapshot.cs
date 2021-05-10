﻿// <auto-generated />
using System;
using Bloom.DAO.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bloom.DAO.Migrations
{
    [DbContext(typeof(BloomContext))]
    partial class BloomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bloom.BLL.Entities.Amizade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ConvidadoId");

                    b.Property<Guid>("ConvidanteId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Pendente");

                    b.HasKey("Id");

                    b.ToTable("Amizade");
                });

            modelBuilder.Entity("Bloom.BLL.Entities.Avaliacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Classificacao");

                    b.Property<Guid?>("FilmeId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(null);

                    b.Property<Guid?>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(null);

                    b.Property<Guid?>("SerieId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(null);

                    b.Property<string>("Texto");

                    b.Property<string>("TipoAvaliacao")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Filme");

                    b.Property<Guid>("UsuarioId");

                    b.HasKey("Id");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("Bloom.BLL.Entities.Comentario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AvaliacaoId");

                    b.Property<Guid?>("FilmeId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(null);

                    b.Property<Guid?>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(null);

                    b.Property<Guid?>("SerieId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(null);

                    b.Property<string>("Texto");

                    b.Property<string>("TipoAvaliacao")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Filme");

                    b.Property<Guid>("UsuarioId");

                    b.HasKey("Id");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("Bloom.BLL.Entities.Curtida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AvaliacaoId");

                    b.Property<Guid?>("FilmeId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(null);

                    b.Property<Guid?>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(null);

                    b.Property<Guid?>("SerieId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(null);

                    b.Property<string>("TipoAvaliacao")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Filme");

                    b.Property<Guid>("UsuarioId");

                    b.HasKey("Id");

                    b.ToTable("Curtida");
                });

            modelBuilder.Entity("Bloom.BLL.Entities.Filme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Adicionado")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<int>("Ano");

                    b.Property<double>("Classificacao");

                    b.Property<string>("Diretor");

                    b.Property<string>("Elenco");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Aventura");

                    b.Property<string>("Pais");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Pendente");

                    b.Property<string>("Titulo");

                    b.Property<Guid>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Filme");
                });

            modelBuilder.Entity("Bloom.BLL.Entities.Livro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Adicionado")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<int>("Ano");

                    b.Property<string>("Autores");

                    b.Property<double>("Classificacao");

                    b.Property<string>("Editora");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Aventura");

                    b.Property<string>("Pais");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Pendente");

                    b.Property<string>("Titulo");

                    b.Property<Guid>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("Bloom.BLL.Entities.Serie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Adicionado")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<int>("Ano");

                    b.Property<double>("Classificacao");

                    b.Property<string>("Diretor");

                    b.Property<string>("Elenco");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Aventura");

                    b.Property<int>("NumeroDeTemporadas");

                    b.Property<string>("Pais");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("Pendente");

                    b.Property<string>("Titulo");

                    b.Property<Guid>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Serie");
                });

            modelBuilder.Entity("Bloom.BLL.Entities.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Alterado")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<Guid>("AlteradoPor")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<string>("Cidade");

                    b.Property<DateTime>("Criado")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<DateTime>("DataDeNascimento")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("Email");

                    b.Property<string>("Estado");

                    b.Property<string>("Foto");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.Property<string>("Username");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Bloom.BLL.Entities.Filme", b =>
                {
                    b.HasOne("Bloom.BLL.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bloom.BLL.Entities.Livro", b =>
                {
                    b.HasOne("Bloom.BLL.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bloom.BLL.Entities.Serie", b =>
                {
                    b.HasOne("Bloom.BLL.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
