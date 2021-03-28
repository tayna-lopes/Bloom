using Bloom.Application.AppServicesInterfaces;
using Bloom.Application.Models;
using Bloom.BLL.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloom.Controllers
{
    [Route("api/[controller]")]
    public class SerieController : ControllerBase
    {
        private readonly ILivroAppService _livroAppService;

        public SerieController(ILivroAppService livroAppService)
        {
            _livroAppService = livroAppService;
        }
    }
}
