using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class EditarComentarioModel
    {
        public Guid ComentarioId { get; set; }
        public Guid UsuarioId { get; set; }
        public string Texto { get; set; }
    }
}
