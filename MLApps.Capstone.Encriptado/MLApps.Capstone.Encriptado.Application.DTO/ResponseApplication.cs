using System.Collections.Generic;

namespace MLApps.Capstone.Encriptado.Application.DTO
{
    /// <summary>
    /// Clase generica de respuesta
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseApplication<T> : ResponseApplication
    {
        /// <summary>
        /// Object type
        /// </summary>
#if NET6_0_OR_GREATER

        public T? Data { get; set; }

#else

        public T Data { get; set; } = default!;

#endif

        /// <summary>
        /// Metodo de extension para respuestas de proceso no completado satisfactoriamente
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public new static ResponseApplication<T> Fail(string? message = null, List<string>? messages = null)
        {
            var response = new ResponseApplication<T>() { IsSuccess = false };

            if (message != null)
            {
                response.Message = message;
            }

            if (messages != null)
            {
                response.Messages = messages;
            }

            return response;
        }

        public static ResponseApplication<T> Success(T data, string? message = null, List<string>? messages = null)
        {
            var response = new ResponseApplication<T>() { IsSuccess = true, Data = data };

            if (message != null)
            {
                response.Message = message;
            }

            if (messages != null)
            {
                response.Messages = messages;
            }

            return response;
        }
    }

    /// <summary>
    /// Base response
    /// </summary>
    public class ResponseApplication
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Si IsSuccess == true regreso nombre de archvo generado.
        /// Si IsSuccess == false regreso mensaje de error encontrado
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets the detail by vehicle.
        /// </summary>
        /// <value>
        /// The detail by vehicle.
        /// </value>
        public List<string>? Messages { get; set; }

        /// <summary>
        /// Metodo de respuesta para procesos con error
        /// </summary>
        /// <param name="message"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static ResponseApplication Fail(string message, List<string>? messages = null)
        {
            var response = new ResponseApplication() { IsSuccess = false };

            if (message != null)
            {
                response.Message = message;
            }

            if (messages != null)
            {
                response.Messages = messages;
            }

            return response;
        }

        /// <summary>
        /// Metodo para respuestas exitosas
        /// </summary>
        /// <param name="message"></param>
        /// <param name="modelErrors"></param>
        /// <param name="scapDetailedErrors"></param>
        /// <returns></returns>
        public static ResponseApplication Success(string? message = null, List<string>? messages = null)
        {
            var response = new ResponseApplication() { IsSuccess = true };
            if (message != null)
            {
                response.Message = message;
            }

            if (message != null)
            {
                response.Messages = messages;
            }

            return response;
        }
    }
}