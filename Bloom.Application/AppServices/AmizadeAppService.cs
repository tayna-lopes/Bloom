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
    public class AmizadeAppService: IAmizadeAppService
    {
        private readonly IAmizadeService _amizadeService;

        public AmizadeAppService(IAmizadeService amizadeService)
        {
            _amizadeService = amizadeService;

        }
    }
}
