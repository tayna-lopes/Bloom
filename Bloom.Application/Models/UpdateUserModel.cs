using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Bloom.Application.Models
{
    public class UpdateUserModel
    {
        public Guid UsuarioId { get; set; }
        public string userEmail { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}
