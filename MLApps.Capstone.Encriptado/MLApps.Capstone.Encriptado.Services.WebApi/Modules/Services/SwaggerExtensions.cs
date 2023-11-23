using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace MLApps.Capstone.Encriptado.Services.WebApi.Modules.Services
{
    /// <summary>
    /// Clase de inyeccion de dependencia Swagger
    /// </summary>
    public static class SwaggerExtensions
    {
        private const string _ssamUrl = "https://www.ssamexico.com";

        /// <summary>
        /// Adds the swagger.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddAppSwaggerGen(this IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Encriptado de tarjetas",
                    Description = ".Net Core Web API API",
                    Contact = new OpenApiContact
                    {
                        Name = "Marco Antonio Luna Serrano",
                        Email = "marco.luna@ssamexico.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        securityScheme, new List<string>()
                    }
                });
            });
            return services;
        }
    }
}