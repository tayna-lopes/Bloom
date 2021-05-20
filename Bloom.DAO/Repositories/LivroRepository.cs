using Bloom.BLL.Entities;
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
    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {
        private readonly DbSet<Livro> _livros;

        public LivroRepository(BloomContext context, IConfiguration configuration)
            : base(context, configuration)
        {
            _livros = _context.Livros;
        }

        public Livro GetByName(string nome)
        {
            return _livros.Where(x => x.Titulo == nome).FirstOrDefault();
        }
        public List<Livro> GetAllLivrosByUsuarioId(Guid UsuarioId)
        {
            return _livros.Where(x => x.UsuarioId == UsuarioId).ToList();
        }
        public List<Livro> GetAdicionadosRecentemente()
        {
            var sday = DateTime.Now;
            return _livros.Where(x => x.Adicionado.Date <= sday).ToList();
        }
        public List<Livro> GetLivrosParaAprovacao()
        {
            return _livros.Where(x => x.Status == StatusAvaliacao.Pendente).ToList();
        }
    }
}
