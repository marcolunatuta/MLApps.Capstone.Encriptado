using MLApps.Capstone.Encriptado.Transversal.Common.Constants;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MLApps.Capstone.Encriptado.Transversal.Common.Extensions
{
    /// <summary>
    /// Metodos de extension para JsonSerializer
    /// </summary>
    public static class JsonSerializerExtensions
    {
        /// <summary>
        /// Serializa objeto a json string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static async Task<string> SerializarAsync<T>(this T obj)
        {
            await using MemoryStream stream = AppRecyclabeMemoryStream.Manager.GetStream();
            await JsonSerializer.SerializeAsync(stream, obj, AppJsonConst.Options.Value).ConfigureAwaitFalse();
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync().ConfigureAwaitFalse();
        }

        /// <summary>
        /// Método general para deserializar un objeto de tipo T desde un Stream obtenido de una respuesta HTTP ya enviada desde el REST API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="respuestaObtenida"></param>
        /// <returns></returns>
        public static Task<T> DeserializarStreamToJson<T>(this HttpContent respuestaObtenida)
        {
            if (respuestaObtenida == null)
            {
                throw new ArgumentNullException(nameof(respuestaObtenida), "Objeto nulo");
            }
            return respuestaObtenida.Deserializar<T>();
        }

        public static T Deserializar<T>(this string json) where T : new()
        {
            return JsonSerializer.Deserialize<T>(json, AppJsonConst.Options.Value) ?? default!;
        }

        /// <summary>
        /// Serializa objeto a json string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static async Task<T> Deserializar<T>(this HttpContent httpContent)
        {
            string jsonString = await httpContent.ReadAsStringAsync().ConfigureAwaitFalse();

            if (string.IsNullOrWhiteSpace(jsonString))
            {
                throw new ArgumentException("No se pudo deserializar el objeto", nameof(httpContent));
            }
            var objectResult = JsonSerializer.Deserialize<T>(jsonString, AppJsonConst.Options.Value);
            if (objectResult == null)
            {
                throw new ArgumentException("No se pudo deserializar el objeto", nameof(httpContent));
            }
            return objectResult;
        }
    }
}