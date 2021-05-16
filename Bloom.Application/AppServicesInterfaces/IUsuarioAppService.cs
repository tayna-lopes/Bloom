using Bloom.Application.Models;
using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.AppServicesInterfaces
{
    public interface IUsuarioAppService
    {
        ResponseUtil GetInformacoesUser(string userEmail);
        ResponseUtil AtualizarUsuario(UpdateUserModel model);
        ResponseUtil GraficoUsuariosByEstado();
        ResponseUtil GetMaisConectados(int Take);
        ResponseUtil GetSeriesParaAprovacao();
        ResponseUtil AprovarRecusarSerie(Guid serieId, bool Aprovar);
        ResponseUtil GetFilmesParaAprovacao();
        ResponseUtil AprovarRecusarFilmes(Guid FilmeId, bool Aprovar);
        ResponseUtil GetLivrosParaAprovacao();
        ResponseUtil AprovarRecusarLivro(Guid LivroId, bool Aprovar);
    }
}
