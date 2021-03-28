using Bloom.Application.Models;
using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.AppServicesInterfaces
{
    public interface IFilmeAppService
    {
        ResponseUtil CriarFilme(CriarFilmeModel model);
        ResponseUtil AtualizarFilme(AtualizarFilmeModel model);
        ResponseUtil GetById(Guid FilmeId);
        ResponseUtil GetAllFilmes();
        ResponseUtil GetAdicionadosRecentemente();
        ResponseUtil GetAllFilmesByUser(Guid UsuarioId);
        ResponseUtil DeletarFilme(Guid FilmeId);
    }
}
