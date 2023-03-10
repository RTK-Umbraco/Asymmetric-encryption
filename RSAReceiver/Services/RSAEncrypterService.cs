using System.Security.Cryptography;

namespace RSAReceiver.Services
{
    public class RSAEncrypterService
    {
        public byte[] DecryptData(string privateKeyPath, string encryptedPassword)
        {
            byte[] plain;

            var dataToEncrypt = Convert.FromBase64String(encryptedPassword);
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(privateKeyPath));

                plain = rsa.Decrypt(dataToEncrypt, false);
            }

            return plain;
        }
    }
}
