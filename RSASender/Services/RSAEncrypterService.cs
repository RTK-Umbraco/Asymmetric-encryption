using System.Security.Cryptography;
using System.Text;

namespace RSASender.Services
{
    public class RSAEncrypterService
    {
        public byte[] EncryptData(string publicKeyPath, string password)
        {
            byte[] cipherbytes;

            var dataToEncrypt = Encoding.UTF8.GetBytes(password);

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(publicKeyPath));

                cipherbytes = rsa.Encrypt(dataToEncrypt, false);
            }

            return cipherbytes;
        }
    }
}
