using Bloom.Application.AppServicesInterfaces;
using Bloom.Application.Models;
using Bloom.BLL.Entities;
using Bloom.BLL.ServicesInterfaces;
using Bloom.BLL.Utils;
using Cryptography;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.Application.AppServicesInterfaces
{
    public class CurtidaAppService : ICurtidaAppService
    {
        private readonly ICurtidaService _curtidaService;

        public CurtidaAppService(ICurtidaService curtidaService)
        {
            _curtidaService = curtidaService;

        }
    }
}
