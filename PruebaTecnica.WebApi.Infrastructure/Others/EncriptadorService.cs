using PruebaTecnica.WebApi.Core.Interfaces.Tools;
using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PruebaTecnica.WebApi.Infrastructure.Others
{
    public class EncriptadorService : IEncriptadorService
    {
        private readonly string _clavePrivada = ConfigurationManager.AppSettings["clavePrivada"];

        public string Encriptar(string textoPlano)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_clavePrivada);
                aesAlg.GenerateIV();

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(textoPlano);
                        }
                    }
                    return Convert.ToBase64String(aesAlg.IV) + Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public string Desencriptar(string textoCifrado)
        {
            using (Aes aesAlg = Aes.Create())
            {
                byte[] iv = Convert.FromBase64String(textoCifrado.Substring(0, 24));
                byte[] cipherBytes = Convert.FromBase64String(textoCifrado.Substring(24));
                aesAlg.Key = Encoding.UTF8.GetBytes(_clavePrivada);
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
