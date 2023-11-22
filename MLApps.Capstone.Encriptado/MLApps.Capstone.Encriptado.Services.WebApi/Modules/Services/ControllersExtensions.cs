using MessagePack;
using MessagePack.AspNetCoreMvcFormatter;
using System.Text.Json.Serialization;

namespace MLApps.Capstone.Encriptado.Services.WebApi.Modules.Services
{
    /// <summary>
    /// Controllers Setup
    /// </summary>
    public static class ControllersExtensions
    {
        /// <summary>
        /// Configura el comportamiento de los controllers
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAppControllers(this IServiceCollection services)
        {
            services.AddControllers(opt =>
            {
                var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);
                opt.InputFormatters.Add(new MessagePackInputFormatter(lz4Options));
                opt.OutputFormatters.Add(new MessagePackOutputFormatter(lz4Options));
                opt.RespectBrowserAcceptHeader = true;
                opt.ReturnHttpNotAcceptable = true;
                opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            }).AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
                opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });

            return services;
        }
    }
}
