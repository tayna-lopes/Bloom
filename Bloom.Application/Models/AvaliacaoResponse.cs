﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class AvaliacaoResponse
    {
        public Guid UsuarioId { get; set; }
        public string Comentario { get; set; }
        public int Classificacao { get; set; }
    }
}