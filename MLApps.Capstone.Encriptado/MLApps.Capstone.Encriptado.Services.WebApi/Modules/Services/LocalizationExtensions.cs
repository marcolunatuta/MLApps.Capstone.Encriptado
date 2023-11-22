namespace MLApps.Capstone.Encriptado.Services.WebApi.Modules.Services
{
    /// <summary>
    /// Agrega servicio de localización.
    /// </summary>
    public static class LocalizationExtensions
    {
        /// <summary>
        /// Sirve la inyección para los archivos de configuración de idioma
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddResourceLocalization(this IServiceCollection services)
        {
            services.AddLocalization();
            return services;
        }
    }
}
