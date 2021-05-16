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
    }
}
