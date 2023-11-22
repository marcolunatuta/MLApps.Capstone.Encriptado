using MLApps.Capstone.Encriptado.Application.Validator;

namespace MLApps.Capstone.Encriptado.Services.WebApi.Modules.Services
{
    /// <summary>
    /// Clase de inyeccion de dependencia FluentValidador
    /// </summary>
    public static class ValidatorExtensions
    {
        /// <summary>
        /// Adds the validator.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddAppValidator(this IServiceCollection services)
        {
            services.AddTransient<RequestDataValidator>();
            return services;
        }
    }
}