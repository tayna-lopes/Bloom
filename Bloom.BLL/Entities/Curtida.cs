using Bloom.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.Entities
{
    public class Curtida
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid? FilmeId { get; set; }
        public Guid? SerieId { get; set; }
        public Guid? LivroId { get; set; }
        public Guid AvaliacaoId { get; set; }
        public TipoAvaliacao TipoAvaliacao { get; set; }
    }
}
