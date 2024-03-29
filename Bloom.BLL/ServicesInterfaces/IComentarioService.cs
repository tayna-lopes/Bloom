﻿using Bloom.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.ServicesInterfaces
{
    public interface IComentarioService : IServiceBase<Comentario>
    {
        List<Comentario> GetComentariosByAvaliacaoId(Guid AvaliacaoId);
    }
}
