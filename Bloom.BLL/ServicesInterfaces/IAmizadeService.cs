using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.ServicesInterfaces
{
    public interface IAmizadeService : IServiceBase<Amizade>
    {
        List<Amizade> GetMeusAmigos(Guid UsuarioId);
        List<Amizade> GetMeusConvitesDeAmizade(Guid UsuarioId);
        Amizade GetAmizadeByAmigosId(Guid convidadoId, Guid convidanteId);
    }
}
