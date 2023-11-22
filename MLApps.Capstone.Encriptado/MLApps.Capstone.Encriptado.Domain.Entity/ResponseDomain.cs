using MLApps.Capstone.Encriptado.Transversal.Common.Constants;
using System.Collections.Generic;

namespace MLApps.Capstone.Encriptado.Domain.Entity
{
    /// <summary>
    /// Clase generica de respuesta
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseDomain<T> : ResponseDomain
    {
        /// <summary>
        /// Object type
        /// </summary>
        public T Data { get; set; } = default!;

        public override string ToString()
        {
            return Data.Serializar();
        }

        ///<inheritdoc/>
        public static ResponseDomain<T> Fail(string message, List<string>? messages = null, T data = default!)
        {
            var response = new ResponseDomain<T>() { IsSuccess = false };

            if (message != null)
            {
                response.Message = message;
            }

            if (messages != null)
            {
                response.Messages = messages;
            }

            if (data != null)
            {
                response.Data = data;
            }

            return response;
        }

        public static ResponseDomain<T> Success(T data, string message, List<string>? scapDetailedErrors = null)
        {
            var response = new ResponseDomain<T>() { Data = data, IsSuccess = true };
            if (message != null)
            {
                response.Message = message;
            }

            if (scapDetailedErrors != null)
            {
                response.Messages = scapDetailedErrors;
            }

            return response;
        }
    }

    /// <summary>
    /// Base response
    /// </summary>
    public class ResponseDomain
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; } = null!;

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
        /// <param name="modelErrors"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static ResponseDomain Fail(string message, List<string>? messages = null)
        {
            var response = new ResponseDomain() { IsSuccess = false };

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
        public static ResponseDomain Success(string message, List<string>? scapDetailedErrors = null)
        {
            var response = new ResponseDomain() { IsSuccess = true };
            if (message != null)
            {
                response.Message = message;
            }

            if (scapDetailedErrors != null)
            {
                response.Messages = scapDetailedErrors;
            }

            return response;
        }
    }
}
