using System;
using System.IO;
using System.Security.Cryptography;

namespace MLApps.Capstone.Encriptado.Transversal.Common.Extensions
{
    public static class Simetrico
    {
        public static string Encrypt(string plainText, byte[] key, byte[] iv)
        {
            byte[] encryptedData;

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new())
            {
                using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (StreamWriter swEncrypt = new(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }

                encryptedData = msEncrypt.ToArray();
            }

            return Convert.ToBase64String(encryptedData);
        }

        public static string Decrypt(string cipherData, byte[] key, byte[] iv)
        {
            byte[] cipherText = Convert.FromBase64String(cipherData);

            using Aes aesAlg = Aes.Create();

            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msDecrypt = new(cipherText);
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            return srDecrypt.ReadToEnd();
        }
    }
}