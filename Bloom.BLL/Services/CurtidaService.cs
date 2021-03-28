using System;
using System.Collections.Generic;
using System.Text;
using Bloom.BLL.Entities;
using Bloom.BLL.RepositoriesInterfaces;
using Bloom.BLL.ServicesInterfaces;

namespace Bloom.BLL.Services
{
    public class CurtidaService : ServiceBase<Curtida>, ICurtidaService
    {
        private readonly ICurtidasRepository _CurtidasRepository;

        public CurtidaService(ICurtidasRepository CurtidasRepository) : base(CurtidasRepository)
        {
            _CurtidasRepository = CurtidasRepository;
        }
    }
}
