using Bloom.Application.AppServices;
using Bloom.Application.AppServicesInterfaces;
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
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();

            //Service
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IUsuarioService, UsuarioService>();

            //Repository
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        }
    }
}

