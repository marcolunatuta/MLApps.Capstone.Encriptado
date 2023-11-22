using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using MLApps.Capstone.Encriptado.Services.WebApi.Modules.Exceptions;
using MLApps.Capstone.Encriptado.Transversal.Common.Models.AppConfig;
using MLApps.Capstone.Encriptado.Transversal.Logging;
using System.Globalization;

namespace MLApps.Capstone.Encriptado.Services.WebApi.Modules.App
{
    /// <summary>
    /// App Initialization
    /// </summary>
    public static class AppExtensions
    {
        /// <summary>
        /// Adds the application settings.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        public static void AddAppSettings(this WebApplication app)
        {
            var supportedCultures = new[]
              {
                  new CultureInfo("en-US"),
                  new CultureInfo("en"),
                  new CultureInfo("es-MX"),
                  new CultureInfo("es"),
              };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("es-MX"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            // needed for  ${aspnet-request-posted-body} with an API Controller.
            app.UseMiddleware<NLog.Web.NLogRequestPostedBodyMiddleware>(new NLog.Web.NLogRequestPostedBodyMiddlewareOptions());
            var appSettings = app.Services.GetService<IOptions<AppSettingsConfig>>();

            FileTarget.TextFile(NLog.LogLevel.Trace);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
                app.UseDeveloperExceptionPage();
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("policyApiSCAP");
            app.UseMiddleware<ContextHandling>();
            app.MapControllers();
            app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
    }
}