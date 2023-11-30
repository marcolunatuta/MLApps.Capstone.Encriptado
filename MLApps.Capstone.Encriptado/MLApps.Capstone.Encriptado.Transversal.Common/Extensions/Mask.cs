using System;
using System.Linq;

namespace MLApps.Capstone.Encriptado.Transversal.Common.Extensions
{
    public static class Mask
    {
        public static readonly int CARACTERES_A_MOSTRAR = 4;

        public static string MaskingText(string cc)
        {
            if (string.IsNullOrEmpty(cc))
                throw new ArgumentException("Cadena vacía");

            if (cc.Length <= CARACTERES_A_MOSTRAR)
                return cc;

            var cifrado = Enumerable.Repeat("*", cc.Length - CARACTERES_A_MOSTRAR);
            return string.Join("", cifrado) + cc[^CARACTERES_A_MOSTRAR..];
        }
    }
}