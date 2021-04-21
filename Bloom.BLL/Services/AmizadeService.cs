using System;
using System.Collections.Generic;
using System.Text;
using Bloom.BLL.Entities;
using Bloom.BLL.RepositoriesInterfaces;
using Bloom.BLL.ServicesInterfaces;

namespace Bloom.BLL.Services
{
    public class AmizadeService : ServiceBase<Amizade>, IAmizadeService
    {
        private readonly IAmizadeRepository _amizadeRepository;

        public AmizadeService(IAmizadeRepository amizadeRepository) : base(amizadeRepository)
        {
            _amizadeRepository = amizadeRepository;
        }

        public Amizade GetAmizadeByAmigosId(Guid convidadoId, Guid convidanteId)
        {
            return _amizadeRepository.GetAmizadeByAmigosId(convidadoId, convidanteId);
        }
        public List<Amizade> GetMeusAmigos(Guid UsuarioId)
        {
            return _amizadeRepository.GetMeusAmigos(UsuarioId);
        }
        public List<Amizade> GetMeusConvitesDeAmizade(Guid UsuarioId)
        {
            return _amizadeRepository.GetMeusConvitesDeAmizade(UsuarioId);
        }
    }
}
