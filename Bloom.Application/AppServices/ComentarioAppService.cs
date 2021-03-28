using Bloom.Application.AppServicesInterfaces;
using Bloom.Application.Models;
using Bloom.BLL.Entities;
using Bloom.BLL.ServicesInterfaces;
using Bloom.BLL.Utils;
using Cryptography;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.AppServices
{
    public class ComentarioAppService : IComentarioAppService
    {
        private readonly IComentarioService _comentarioService;

        public ComentarioAppService(IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;

        }
    }
}
