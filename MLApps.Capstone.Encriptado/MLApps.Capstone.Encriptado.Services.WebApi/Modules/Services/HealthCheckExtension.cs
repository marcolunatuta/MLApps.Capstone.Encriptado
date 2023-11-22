namespace MLApps.Capstone.Encriptado.Services.WebApi.Modules.Services
{
    /// <summary>
    /// HealthCheck
    /// </summary>
    public static class HealthCheckExtensions
    {
        /// <summary>
        /// Adds the health check.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddAppHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks();
            return services;
        }
    }
}
