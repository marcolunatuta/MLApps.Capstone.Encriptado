using Microsoft.AspNetCore.HttpLogging;
using MLApps.Capstone.Encriptado.Transversal.Common.Models.AppConfig;

namespace MLApps.Capstone.Encriptado.Services.WebApi.Modules.Services
{
    /// <summary>
    /// Configuración de toda la aplicación.
    /// </summary>
    public static class ServiceSetupExtensions
    {
        /// <summary>
        /// Agrega la configuracion desde appsettings.json y pasa informacion a otros metodos de extension de dependencias
        /// que necesitan esta informacion.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.RequestScheme
                | HttpLoggingFields.RequestProtocol
                | HttpLoggingFields.RequestMethod
                | HttpLoggingFields.RequestPath
                | HttpLoggingFields.RequestBody
                | HttpLoggingFields.ResponseStatusCode
                | HttpLoggingFields.ResponseHeaders;

                logging.RequestHeaders.Add("X-Request-Time");
                logging.RequestHeaders.Add("X-Response-Time");
                logging.RequestHeaders.Add("X-Elapsed-Time");
                logging.RequestHeaders.Add("X-Correlation-ID");
                logging.RequestHeaders.Add("X-Powered-By");
                logging.RequestHeaders.Add("Date");
                logging.MediaTypeOptions.AddText("application/json; charset=utf-8");
            });

            services.Configure<AppSettingsConfig>(configuration.GetSection("AppSettingsConfig"));
            var appSettings = configuration.GetAppSettingsConfig();

            services.AddResourceLocalization();
            services.AddAppLogging();
            services.AddAppControllers();
            services.AddEndpointsApiExplorer();
            services.AddAppSwaggerGen();
            services.AddVLogJsonConfigurations();
            services.AddAppMapper();
            services.AddAppVersioning();
            services.AddAppDi();
            services.AddAppValidator();
            services.AddAppHealthCheck();
            return services;
        }

        internal static AppSettingsConfig GetAppSettingsConfig(this IConfiguration configuration)
        {
            var appSettings = new AppSettingsConfig();

            appSettings.Key = GetDirectValue(configuration, "AppSettingsConfig:Key");
            appSettings.Iv = GetDirectValue(configuration, "AppSettingsConfig:Iv");
            return appSettings;
        }

        internal static string GetDirectValue(IConfiguration configuration, string section)
        {
            var getSection = configuration.GetSection(section);
            if (getSection == null)
            {
                throw new ArgumentNullException(nameof(getSection), "El parametro no puede ser nulo, el parametro no esta configurado en appSettings.json");
            }
            return getSection.Value!;
        }

        internal static T BinSection<T>(this T key, IConfiguration configuration, string section)
        {
            var getSection = configuration.GetSection(section);
            if (getSection == null)
            {
                throw new ArgumentNullException(nameof(getSection), "El parametro no puede ser nulo, el parametro no esta configurado en appSettings.json");
            }
            getSection.Bind(key);
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return key;
        }
    }
}