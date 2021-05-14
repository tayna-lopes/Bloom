using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.Entities
{
    [Serializable]
    public class Usuario : BaseEntity
    {
        public Guid UsuarioId { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public virtual List<Amizade> Convidados { get; set; } 
        public virtual List<Amizade> Convites { get; set; } 
    }
}
