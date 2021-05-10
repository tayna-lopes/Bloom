using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class DeletarComentarioModel
    {
        public Guid ComentarioId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
