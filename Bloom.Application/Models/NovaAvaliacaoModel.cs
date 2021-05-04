using Bloom.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class NovaAvaliacaoModel
    {
        public string Texto { get; set; }
        public int Classificacao { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid? FilmeId { get; set; }
        public Guid? SerieId { get; set; }
        public Guid? LivroId { get; set; }
        public TipoAvaliacao TipoAvaliacao { get; set; }
    }
}
