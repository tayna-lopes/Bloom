﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.Models
{
    public class UpdateUserModel
    {
        public string userEmail { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}
