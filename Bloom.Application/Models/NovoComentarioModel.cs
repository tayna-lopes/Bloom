using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class NovoComentarioModel
    {
        public Guid AvaliacaoId { get; set; }
        public Guid UsuarioId { get; set; }
        public string Texto { get; set; }
    }
}
