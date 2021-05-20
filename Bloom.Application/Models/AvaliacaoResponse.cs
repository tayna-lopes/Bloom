using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class AvaliacaoResponse
    {
        public Guid UsuarioId { get; set; }
        public Guid AvaliacaoId { get; set; }
        public string Comentario { get; set; }
        public double Classificacao { get; set; }

        public int  Curtidas { get; set; }
        public Filme Filme { get; set; }

        public Serie Serie { get; set; }
        public Livro Livro{ get; set; }
    }
}
