using System.Security.Cryptography;
using System.Text;

namespace MLApps.Capstone.Encriptado.Transversal.Common.Extensions
{
    public static class Hashing
    {
        public static string ComputeHash(string input)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            StringBuilder builder = new();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2")); // Convierte a formato hexadecimal
            }

            return builder.ToString();
        }

        public static bool VerifyHash(string input, string hashedString)
        {
            //TODO: Hacerlo más eficiente
            string newHash = ComputeHash(input);
            return newHash == hashedString;
        }
    }
}