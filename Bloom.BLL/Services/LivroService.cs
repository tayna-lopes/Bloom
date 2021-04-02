using Bloom.BLL.Entities;
using Bloom.BLL.RepositoriesInterfaces;
using Bloom.BLL.ServicesInterfaces;
using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.Services
{
    public class LivroService : ServiceBase<Livro>, ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository) : base(livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public List<Livro> GetAdicionadosRecentemente()
        {
            return _livroRepository.GetAdicionadosRecentemente();
        }

        public List<Livro> GetAllLivrosByUsuarioId(Guid UsuarioId)
        {
            return _livroRepository.GetAllLivrosByUsuarioId(UsuarioId);
        }

        public Livro GetByName(string nome)
        {
            return _livroRepository.GetByName(nome);
        }
    }
}
