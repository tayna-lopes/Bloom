using Bloom.Application.Models;
using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.AppServicesInterfaces
{
    public interface ILivroAppService
    {
        ResponseUtil CriarLivro(CriarLivroModel model);
        ResponseUtil AtualizarLivro(AtualizarLivroModel model);
        ResponseUtil GetById(Guid LivroId);
        ResponseUtil GetAllLivros();
        ResponseUtil GetAdicionadosRecentemente();
        ResponseUtil GetAllLivrosByUser(Guid UsuarioId);
        ResponseUtil DeletarFilme(Guid LivroId);

    }
}
