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
            services.AddScoped<IAmizadeAppService, AmizadeAppService>();
            services.AddScoped<IAvaliacaoAppService, AvaliacaoAppService>();
            services.AddScoped<ICurtidaAppService, CurtidaAppService>();
            services.AddScoped<IComentarioAppService, ComentarioAppService>();
            services.AddScoped<IFilmeAppService, FilmeAppService>();
            services.AddScoped<ILivroAppService, LivroAppService>();
            services.AddScoped<ISerieAppService, SerieAppService>();

            //Service
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAmizadeService, AmizadeService>();
            services.AddScoped<IAvaliacaoService, AvaliacaoService>();
            services.AddScoped<ICurtidaService, CurtidaService>();
            services.AddScoped<IComentarioService, ComentarioService>();
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<ISerieService, SerieService>();

            //Repository
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAmizadeRepository, AmizadeRepository>();
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            services.AddScoped<IComentarioRepository, ComentarioRepository>();
            services.AddScoped<ICurtidasRepository, CurtidaRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<ISerieRepository, SerieRepository>();

        }
    }
}

