﻿using Bloom.BLL.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class CriarLivroModel
    {
        public string Editora { get; set; }
        public string Foto { get; set; }
        public string Titulo { get; set; }
        public List<string> Autores { get; set; }
        public string Pais { get; set; }
        public int Ano { get; set; }
        public double Classificacao { get; set; }
        public Genero Genero { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
