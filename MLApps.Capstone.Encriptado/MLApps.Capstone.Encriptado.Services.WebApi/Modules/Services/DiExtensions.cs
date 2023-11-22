using MLApps.Capstone.Encriptado.Application.Interface;
using MLApps.Capstone.Encriptado.Application.Main;
using MLApps.Capstone.Encriptado.Domain.Core;
using MLApps.Capstone.Encriptado.Domain.Interface;
using MLApps.Capstone.Encriptado.Infrastructure.Data;
using MLApps.Capstone.Encriptado.Infrastructure.Interface;
using MLApps.Capstone.Encriptado.Infrastructure.Repository;
using MLApps.Capstone.Encriptado.Transversal.Common.Interfaces;
using MLApps.Capstone.Encriptado.Transversal.Logging;

namespace MLApps.Capstone.Encriptado.Services.WebApi.Modules.Services
{
    /// <summary>
    /// Aqui se hacen las inyecciones de dependecias.
    /// </summary>
    public static class DIExtensions
    {
        /// <summary>
        /// Adds the injection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddAppDi(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IAppLogger<>), typeof(AppLogger<>));
            services.AddSingleton<DatabaseContext>();
            services.AddScoped<IEncriptadosRepository, EncriptadosRepository>();
            services.AddScoped<IEncriptadosDomain, EncriptadosDomain>();
            services.AddScoped<IEncriptadosApplication, EncriptadosApplication>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}