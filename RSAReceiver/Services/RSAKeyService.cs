using System.Security.Cryptography;

namespace RSAReceiver.Services
{
    public class RSAKeyService
    {
        public RSA RSA { get; set; }
        public string PublicKeyPath { get; set; }
        public string PrivateKeyPath { get; set; }
        public FileService FileService { get; set; }

        public RSAKeyService()
        {
            RSA = new RSACryptoServiceProvider(2048);
            FileService = new FileService();
            PublicKeyPath = "c:\\temp\\publickey.xml";
            PrivateKeyPath = "c:\\temp\\privatekey.xml";
        }
        public void AssignPublicKey()
        {
            FileService.WriteRSACryptoToXML(RSA, PublicKeyPath, false);
        }

        public void AssignPrivateKey()
        {
            FileService.WriteRSACryptoToXML(RSA, PrivateKeyPath, true);
        }

        public void DisposeRSA()
        {
            RSA.Dispose();
        }
    }
}
