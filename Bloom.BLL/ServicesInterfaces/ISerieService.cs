using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.ServicesInterfaces
{
    public interface ISerieService : IServiceBase<Serie>
    {
        Serie GetByName(string nome);
        List<Serie> GetAllSeriesByUsuarioId(Guid UsuarioId);
        List<Serie> GetAdicionadosRecentemente();
        List<Serie> GetSeriesParaAprovacao();
    }
}
