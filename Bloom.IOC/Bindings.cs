using Bloom.BLL.RepositoriesInterfaces;
using Bloom.BLL.Services;
using Bloom.BLL.ServicesInterfaces;
using Bloom.DAO.Context;
using Bloom.DAO.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.IOC
{
    public class Bindings
    {
        public static void ConfigureServices(IServiceCollection services, string connection)
        {
            services.AddDbContext<BloomContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            //AppService
            //EX - services.AddScoped<IProgramAppService, ProgramAppService>();

            //Service
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            //EX - services.AddScoped<IProgramService, ProgramService>();

            //Repository
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            //EX - services.AddScoped<IProgramRepository, ProgramRepository>();

        }
    }
}

