using Bloom.Application.Models;
using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.AppServicesInterfaces
{
    public interface IAmizadeAppService
    {
        ResponseUtil Convite(ConviteModel model);
        ResponseUtil AceitarRecusarConvite(ConviteModel model, bool AceitarAmizade);
        ResponseUtil DesfazerAmizade(ConviteModel model);
        ResponseUtil GetMeusAmigos(Guid UsuarioId);
        ResponseUtil GetMinhasSolicitacoesDeAmizade(Guid UsuarioId);
    }
}
