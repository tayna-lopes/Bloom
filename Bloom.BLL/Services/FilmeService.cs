using Bloom.BLL.Entities;
using Bloom.BLL.RepositoriesInterfaces;
using Bloom.BLL.ServicesInterfaces;
using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.Services
{
    public class FilmeService : ServiceBase<Filme>, IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository) : base(filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }
    }
}
