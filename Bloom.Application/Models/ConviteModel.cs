using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class ConviteModel
    {
        public string ConvidanteUsername { get; set; }
        public string ConvidadoUsername { get; set; }

        public bool aceita { get; set; }
    }
}
