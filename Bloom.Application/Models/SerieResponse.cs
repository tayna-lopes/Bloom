using Bloom.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class SerieResponse
    {
        public Guid Id { get; set; }
        public string Diretor { get; set; }
        public string Titulo { get; set; }
        public string Elenco { get; set; }
        public string Pais { get; set; }
        public int Ano { get; set; }
        public double Classificacao { get; set; }
        public int NumeroDeTemporadas { get; set; }
        public Genero Genero { get; set; }
        public string Username { get; set; }
        public Guid UsuarioId { get; set; }
        public string Foto { get; set; }
    }
}
