using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class EditarAvaliacaoModel
    {
        public Guid AvaliacaoId { get; set; }
        public string Texto { get; set; }
        public int? Classificacao { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
