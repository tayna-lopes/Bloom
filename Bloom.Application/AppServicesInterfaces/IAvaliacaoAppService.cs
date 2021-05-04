using Bloom.Application.Models;
using Bloom.BLL.Entities;
using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.AppServicesInterfaces
{
    public interface IAvaliacaoAppService
    {
        ResponseUtil NovaAvaliacao(NovaAvaliacaoModel avaliacao);
        ResponseUtil EditarAvaliacao(EditarAvaliacaoModel model);
        ResponseUtil DeletarAvaliacao(DeletarAvaliacaoModel model);
        ResponseUtil GetTodasAvaliacoesMediaId(GetTodasAvaliacoesMidiaModel model);
    }
}
