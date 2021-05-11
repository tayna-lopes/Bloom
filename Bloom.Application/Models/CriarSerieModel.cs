using Bloom.BLL.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class CriarSerieModel
    {
        public IFormFile Foto { get; set; }
        public string Diretor { get; set; }
        public string Titulo { get; set; }
        public string Elenco { get; set; }
        public string Pais { get; set; }
        public int Ano { get; set; }
        public double Classificacao { get; set; }
        public int NumeroDeTemporadas { get; set; }
        public Genero Genero { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
