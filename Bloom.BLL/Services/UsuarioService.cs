using Bloom.BLL.Entities;
using Bloom.BLL.RepositoriesInterfaces;
using Bloom.BLL.ServicesInterfaces;
using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Usuario GetByEmail(string email)
        {
            return _usuarioRepository.GetByEmail(email);
        }
        public Usuario GetByUsername(string username)
        {
            return _usuarioRepository.GetByUsername(username);
        }
        public bool ValidarUsuario(string usuarioId)
        {
            if (GuidUtil.IsGuidValid(usuarioId))
            {
                var user = _usuarioRepository.GetById(Guid.Parse(usuarioId));

                return user != null ? true : false;
            }
            return false;
        }
        public bool ValidarUsername(string username)
        {
            return _usuarioRepository.ValidarUsername(username);
        }
    }
}
