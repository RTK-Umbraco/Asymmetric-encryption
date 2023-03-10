using RSASender.Services;

namespace RSASender
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sender");

            RSAEncrypterService rSAEncrypterService = new RSAEncrypterService();

            Console.WriteLine("Insert your message");

            string publicKeyPath = "c:\\temp\\publickey.xml";
            var password = Console.ReadLine();

            var encryptedPassword = rSAEncrypterService.EncryptData(publicKeyPath, password);

            Console.WriteLine($"Encrypted password: {Convert.ToBase64String(encryptedPassword)}");

            Console.ReadKey();
        }
    }
}