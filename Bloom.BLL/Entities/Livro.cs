using Bloom.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.Entities
{
    public class Livro
    {
        public Guid Id { get; set; }
        public string Autores { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public string Pais { get; set; }
        public int Ano { get; set; }
        public double Classificacao { get; set; }
        public Genero Genero { get; set; }
        public Guid UsuarioId { get; set; }
        public StatusAvaliacao Status { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
