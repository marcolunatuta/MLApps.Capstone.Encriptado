using System.Text.Json.Serialization;

namespace MLApps.Capstone.Encriptado.Services.WebApi.Modules.Services
{
    /// <summary>
    /// Crea la inyección
    /// </summary>
    public static class JsonConfigurationExtensions
    {
        /// <summary>
        /// Define las reglas de serialización de los objetos JSON en cada respuesta solicitada.
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddVLogJsonConfigurations(this IServiceCollection services)
        {
            services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.SerializerOptions.PropertyNameCaseInsensitive = true;
                options.SerializerOptions.PropertyNamingPolicy = null;
                options.SerializerOptions.WriteIndented = true;
                options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });

            return services;
        }
    }
}
