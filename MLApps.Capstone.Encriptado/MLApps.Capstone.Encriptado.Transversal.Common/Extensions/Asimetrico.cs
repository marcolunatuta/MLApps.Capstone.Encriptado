using System.Security.Cryptography;

namespace MLApps.Capstone.Encriptado.Transversal.Common.Extensions
{
    public class Asimetrico
    {
        /// <summary>
        /// Función para cifrar datos con una clave pública
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static byte[] CifrarConClavePublica(string publicKey, string mensaje)
        {
            using RSACryptoServiceProvider rsa = new();
            rsa.FromXmlString(publicKey);
            byte[] datos = System.Text.Encoding.UTF8.GetBytes(mensaje);
            return rsa.Encrypt(datos, false);
        }

        /// <summary>
        /// Función para descifrar datos con una clave privada
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="datosCifrados"></param>
        /// <returns></returns>
        public static string DescifrarConClavePrivada(string privateKey, byte[] datosCifrados)
        {
            using RSACryptoServiceProvider rsa = new();
            rsa.FromXmlString(privateKey);
            byte[] datosDescifrados = rsa.Decrypt(datosCifrados, false);
            return System.Text.Encoding.UTF8.GetString(datosDescifrados);
        }
    }
}