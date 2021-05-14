using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.Entities
{
   public  class Amizade
    {
        public Guid Id { get; set; }
        public Guid ConvidanteId { get; set; }
        public Guid ConvidadoId { get; set; }
        public StatusAmizade Status { get; set; }
        public virtual Usuario Convidante { get; set; }
        public virtual Usuario Convidado { get; set; }
    }
}
