﻿namespace MLApps.Capstone.Encriptado.Domain.Entity
{
    /// <summary>
    /// Clase generica de peticiones del cliente hacia el servidor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RequestDomain<T> : RequestDomain
    {
        /// <summary>
        /// Gets or sets the data. Objeto con la informacion a procesar en el request
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public T Data { get; set; } = default!;
    }

    /// <summary>
    /// Clase generica de peticiones del cliente hacia el servidor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RequestDomain
    {
        /// <summary>
        /// Servicio, Aplicacion, HandHeld ID, etc. Que invoca la peticion.
        /// </summary>
        public string? ClienteAlias { get; set; }
    }
}