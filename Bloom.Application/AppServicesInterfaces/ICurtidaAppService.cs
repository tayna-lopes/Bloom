using Bloom.Application.Models;
using Bloom.BLL.Entities;
using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.AppServicesInterfaces
{
    public interface ICurtidaAppService
    {
        ResponseUtil CurtirAvaliacao(CurtirAvaliacaoModel model);
        ResponseUtil DescurtirAvaliacao(Guid CurtidaId);
        ResponseUtil GetTodasCurtidasAvaliacaoIdId(Guid AvaliacaoId);
    }
}
