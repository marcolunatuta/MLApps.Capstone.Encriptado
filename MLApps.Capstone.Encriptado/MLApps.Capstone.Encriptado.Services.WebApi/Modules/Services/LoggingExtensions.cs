using NLog.Extensions.Logging;

namespace MLApps.Capstone.Encriptado.Services.WebApi.Modules.Services
{
    /// <summary>
    /// Add Logging rules
    /// </summary>
    public static class LoggingExtensions
    {
        /// <summary>
        /// Configura los tipos de salida del logueo de la aplicacion
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAppLogging(this IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddNLog();
                loggingBuilder.AddDebug();
                loggingBuilder.AddConsole();
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
            });

            return services;
        }
    }
}
