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
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioAppService _comentarioAppService;

        public ComentarioController(IComentarioAppService comentarioAppService)
        {
            _comentarioAppService = comentarioAppService;
        }
    }
}
