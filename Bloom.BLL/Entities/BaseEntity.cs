using Bloom.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.Entities
{
    [Serializable]
    public class BaseEntity
    {
        public BaseEntity()
        {
            Criado = DateTimeUtil.UtcToBrasilia();
            Alterado = DateTimeUtil.UtcToBrasilia();
        }

        public DateTime Criado { get; set; }
        public DateTime Alterado { get; set; }
        public Guid AlteradoPor { get; set; }
    }
}
