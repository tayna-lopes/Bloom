using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.Utils
{
    public class ResponseUtil
    {
        public ResponseUtil()
        {
            Sucesso = false;
            Resultado = string.Empty;
        }

        public bool Sucesso { get; set; }
        public object Resultado { get; set; }
    }
}

