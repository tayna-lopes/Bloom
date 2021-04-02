using Bloom.Application.Models;
using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.AppServicesInterfaces
{
    public interface ISerieAppService
    {
        ResponseUtil CriarSerie(CriarSerieModel model);
        ResponseUtil AtualizarSerie(AtualizarSerieModel model);
        ResponseUtil GetById(Guid SerieId);
        ResponseUtil GetAllSeriess();
        ResponseUtil GetAdicionadosRecentemente();
        ResponseUtil GetAllSeriesByUser(Guid UsuarioId);
        ResponseUtil DeletarSerie(Guid SerieId);
    }
}
