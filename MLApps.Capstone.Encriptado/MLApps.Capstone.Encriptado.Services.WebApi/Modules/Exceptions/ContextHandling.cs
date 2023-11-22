using MLApps.Capstone.Encriptado.Application.DTO;
using MLApps.Capstone.Encriptado.Services.WebApi.Modules.Exceptions;
using MLApps.Capstone.Encriptado.Transversal.Common.Extensions;
using MLApps.Capstone.Encriptado.Transversal.Common.Interfaces;
using System.Globalization;
using System.Net;
using System.Text;

namespace MLApps.Capstone.Encriptado.Services.WebApi.Modules.Exceptions
{
    /// <summary>
    /// Global exception handling
    /// </summary>
    public class ContextHandling
    {
        private readonly RequestDelegate next;
        private readonly IAppLogger<ContextHandling> logger;

        /// <summary>
        /// Global middleware handling
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ContextHandling(RequestDelegate next, IAppLogger<ContextHandling> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        /// <summary>
        /// Handles the occurred exception and formats the appropriate HTTP response.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                var requestTime = DateTimeOffset.Now;

                //await GuardarRequestAsync(httpContext.Request);


                httpContext.Response.OnStarting(() =>
                {
                    var responseTime = DateTimeOffset.Now;
                    var elapsedMilliseconds = responseTime - requestTime;

                    httpContext.Response.Headers.Add("X-Request-Time", requestTime.ToString("o", CultureInfo.CurrentCulture));
                    httpContext.Response.Headers.Add("X-Response-Time", responseTime.ToString("o", CultureInfo.CurrentCulture));
                    httpContext.Response.Headers.Add("X-Elapsed-Time", elapsedMilliseconds.TotalMilliseconds.ToString("0", CultureInfo.CurrentCulture));
                    return Task.CompletedTask;
                });

                //var response = await FormatResponse(httpContext.Response);
                //logger.LogInformation(response);

                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Handles the occurred exception and formats the appropriate HTTP response.
        /// </summary>
        /// <param name="context">The current HTTP context.</param>
        /// <param name="exception">The exception that occurred.</param>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var statusCode = DetermineStatusCode(exception);
            response.StatusCode = (int)statusCode;

            var responseModel = ResponseApplication<string>.Fail(string.Format("Message:{0}  InnerException:{1} StackTrace:{2}", exception.Message, exception.InnerException, exception.StackTrace));
            logger.LogError(exception);

            var result = await responseModel.SerializarAsync().ConfigureAwait(false);
            await context.Response.WriteAsync(result).ConfigureAwait(false);
        }

        /// <summary>
        /// Determines the status code to be returned based on the type of exception.
        /// </summary>
        /// <param name="exception">The exception that occurred.</param>
        /// <returns>The determined status code.</returns>
        private HttpStatusCode DetermineStatusCode(Exception exception)
        {
            switch (exception)
            {
                case InvalidTokenException ex:
                    return ex.TokenExpired ? HttpStatusCode.Unauthorized : HttpStatusCode.Forbidden;

                case ApplicationException _:
                    return HttpStatusCode.BadRequest;

                case KeyNotFoundException _:
                    return HttpStatusCode.NotFound;

                default:
                    return HttpStatusCode.InternalServerError;
            }
        }

        private async Task GuardarRequestAsync(HttpRequest context)
        {
            var request = await FormatRequest(context);
            logger.LogInformation(request);
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            try
            {
                request.EnableBuffering();

                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length));

                var bodyAsText = Encoding.UTF8.GetString(buffer);
                request.Body.Seek(0, SeekOrigin.Begin);

                return $"Request Schema: {request.Scheme} Protocol:{request.Protocol} Method: {request.Method}, Path: {request.Path}, Body: {bodyAsText}";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al formatear la solicitud");
                return $"Error al formatear la solicitud: {ex.Message}";
            }
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            try
            {
                response.Body.Seek(0, SeekOrigin.Begin);
                string text = await new StreamReader(response.Body).ReadToEndAsync();
                response.Body.Seek(0, SeekOrigin.Begin);

                var headers = response.Headers.Select(h => $"{h.Key}: {h.Value}").ToArray();
                var formattedHeaders = string.Join(", ", headers);

                return $"Response Status Code: {response.StatusCode}, Body: {text}, Headers: {formattedHeaders}";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al formatear la respuesta");
                return $"Error al formatear la respuesta: {ex.Message}";
            }
        }

    }
}