using System.Security.Cryptography;

namespace RSAReceiver.Services
{
    public class FileService
    {
        public void WriteRSACryptoToXML(RSA rsa, string path, bool includePrivateParameters)
        {

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            var keyfolder = Path.GetDirectoryName(path);

            if (!Directory.Exists(keyfolder))
            {
                Directory.CreateDirectory(keyfolder);
            }

            File.WriteAllText(path, rsa.ToXmlString(includePrivateParameters));
        }
    }
}
