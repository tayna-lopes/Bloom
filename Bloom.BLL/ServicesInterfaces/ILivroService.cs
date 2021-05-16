using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.ServicesInterfaces
{
    public interface ILivroService: IServiceBase<Livro>
    {
        Livro GetByName(string nome);
        List<Livro> GetAllLivrosByUsuarioId(Guid UsuarioId);
        List<Livro> GetAdicionadosRecentemente();
        List<Livro> GetLivrosParaAprovacao();
    }
}
