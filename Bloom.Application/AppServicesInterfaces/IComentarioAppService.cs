using Bloom.Application.Models;
using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.AppServicesInterfaces
{
    public interface IComentarioAppService
    {
        ResponseUtil ComentarioAvaliacao(NovoComentarioModel model);
        ResponseUtil EditarComentario(EditarComentarioModel model);
        ResponseUtil DeletarComentario(string model);
        ResponseUtil GetComentariosByAvaliacaoId(Guid AvaliacaoId);
    }
}
