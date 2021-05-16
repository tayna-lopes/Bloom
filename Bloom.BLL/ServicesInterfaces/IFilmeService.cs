using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.ServicesInterfaces
{
    public interface IFilmeService : IServiceBase<Filme>
    {
        Filme GetByName(string nome);
        List<Filme> GetAllFilmesByUsuarioId(Guid UsuarioId);
        List<Filme> GetAdicionadosRecentemente();
        List<Filme> GetFilmesParaAprovacao();
    }
}
