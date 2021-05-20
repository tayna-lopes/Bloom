using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class AmizadeResponse
    {
        public Guid AmigoId { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Foto { get; set; }
    }
}
