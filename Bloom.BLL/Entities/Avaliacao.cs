using Bloom.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.Entities
{
    public class Avaliacao
    {
        public Guid Id { get; set; }
        public string Texto { get; set; }
        public double Classificacao { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid? FilmeId { get; set; }
        public Guid? SerieId { get; set; }
        public Guid? LivroId { get; set; }
        public TipoAvaliacao TipoAvaliacao { get; set; }
    }
}