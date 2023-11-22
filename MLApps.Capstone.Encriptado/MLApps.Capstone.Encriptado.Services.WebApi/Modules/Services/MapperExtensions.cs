using AutoMapper;

namespace MLApps.Capstone.Encriptado.Services.WebApi.Modules.Services
{
    /// <summary>
    /// Clase de inyeccion de dependencia AutoMapper
    /// </summary>
    public static class MapperExtensions
    {
        private const string AssemblyNamesToScan = "MLApps.Capstone.Encriptado.Transversal.Mapper";

        /// <summary>
        /// Adds the mapper.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddAppMapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(AssemblyNamesToScan);
                cfg.AllowNullDestinationValues = true;
                cfg.AllowNullCollections = true;
            });

            var mapper = configuration.CreateMapper();

            configuration.AssertConfigurationIsValid();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
