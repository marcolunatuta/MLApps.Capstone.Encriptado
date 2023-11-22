using System.Runtime.Serialization;

namespace MLApps.Capstone.Encriptado.Services.WebApi.Modules.Exceptions
{
    /// <summary>
    /// Invalid Token Exception type for app exceptions
    /// </summary>
    [Serializable]
    public class InvalidTokenException : ApplicationException
    {
        /// <summary>
        /// Indica si el token ha expirado.
        /// </summary>
        public bool TokenExpired { get; }

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="InvalidTokenException"/>.
        /// </summary>
        public InvalidTokenException() : base()
        {
        }

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="InvalidTokenException"/> con el mensaje de error especificado.
        /// </summary>
        /// <param name="message">El mensaje de error que describe la excepción.</param>
        public InvalidTokenException(string message) : base(message)
        {
        }

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="InvalidTokenException"/> con el mensaje de error especificado y la excepción interna que provocó esta excepción.
        /// </summary>
        /// <param name="message">El mensaje de error que describe la excepción.</param>
        /// <param name="innerException">La excepción interna que provocó esta excepción.</param>
        public InvalidTokenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="InvalidTokenException"/> a partir de los datos de serialización.
        /// </summary>
        /// <param name="info">El objeto <see cref="SerializationInfo"/> que contiene los datos de objeto serializados.</param>
        /// <param name="context">El contexto de destino de esta excepción.</param>
        protected InvalidTokenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            TokenExpired = info.GetBoolean("TokenExpired");
        }

        /// <summary>
        /// Establece el objeto <see cref="SerializationInfo"/> con información sobre la excepción.
        /// </summary>
        /// <param name="info">El objeto <see cref="SerializationInfo"/> que contiene los datos de objeto serializados.</param>
        /// <param name="context">El contexto de destino de esta excepción.</param>
        /// <exception cref="ArgumentNullException">Si el argumento <paramref name="info"/> es nulo.</exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("TokenExpired", TokenExpired);
            base.GetObjectData(info, context);
        }
    }
}
