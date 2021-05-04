using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class GetTodasAvaliacoesMidiaModel
    {
        public Guid? SerieId { get; set; }
        public Guid? FilmeId { get; set; }
        public Guid? LivroId { get; set; }
    }
}
