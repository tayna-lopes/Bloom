﻿using Bloom.BLL.Entities;
using Bloom.BLL.Enums;
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
    public class FilmeRepository : RepositoryBase<Filme>, IFilmeRepository
    {
        private readonly DbSet<Filme> _filmes;

        public FilmeRepository(BloomContext context, IConfiguration configuration)
            : base(context, configuration)
        {
            _filmes = _context.Filmes;
        }
        public Filme GetByName(string nome)
        {
            return _filmes.Where(x => x.Titulo == nome).FirstOrDefault();
        }
        public List<Filme> GetAllFilmesByUsuarioId(Guid UsuarioId)
        {
            return _filmes.Where(x => x.UsuarioId == UsuarioId).ToList();
        }
        public List<Filme> GetAdicionadosRecentemente()
        {
            var sday = DateTime.Now;
            return _filmes.Where(x => x.Adicionado.Date <= sday).ToList();
        }
        public List<Filme> GetFilmesParaAprovacao()
        {
            return _filmes.Where(x => x.Status == StatusAvaliacao.Pendente).ToList();
        }
    }
}
