using Bloom.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class FilmeResponse
    {
        public string Diretor { get; set; }
        public string Titulo { get; set; }
        public string Elenco { get; set; }
        public string Pais { get; set; }
        public int Ano { get; set; }
        public Genero Genero { get; set; }
        public string Username { get; set; }
        public Guid FilmeId { get; set; }
        public double Classificacao { get; set; }
        public string Foto { get; set; }
    }
}
