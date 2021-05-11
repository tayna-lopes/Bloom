using Bloom.BLL.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class AtualizarLivroModel
    {
        public IFormFile Foto { get; set; }
        public string Editora { get; set; }
        public string Titulo { get; set; }
        public List<string> Autores { get; set; }
        public string Pais { get; set; }
        public int Ano { get; set; }
        public Genero Genero { get; set; }
        public Guid LivroId { get; set; }
    }
}
