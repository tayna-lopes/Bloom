﻿using Bloom.Application.AppServicesInterfaces;
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
    public class SerieAppService: ISerieAppService
    {
        private readonly ISerieService _serieService;

        public SerieAppService(ISerieService serieService)
        {
            _serieService = serieService;

        }
    }
}