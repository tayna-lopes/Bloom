using System;
using System.Collections.Generic;
using System.Text;
using Bloom.BLL.Entities;
using Bloom.BLL.RepositoriesInterfaces;
using Bloom.BLL.ServicesInterfaces;

namespace Bloom.BLL.Services
{
    public class ComentarioService : ServiceBase<Comentario>, IComentarioService
    {
        private readonly IComentarioRepository _ComentarioRepository;

        public ComentarioService(IComentarioRepository ComentarioRepository) : base(ComentarioRepository)
        {
            _ComentarioRepository = ComentarioRepository;
        }
    }
}
