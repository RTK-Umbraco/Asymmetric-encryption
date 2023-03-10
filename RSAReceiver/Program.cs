using RSAReceiver.Services;
using System.Text;

namespace RSAReceiver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reciever");

            while (true)
            {
                Console.WriteLine("1. Assign keys");
                Console.WriteLine("2. Decrypt password");

                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        AssignKeys();
                        break;
                    case 2:
                        DecryptPassword();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void AssignKeys()
        {
            RSAKeyService rSAKeyService = new RSAKeyService();

            rSAKeyService.AssignPrivateKey();
            rSAKeyService.AssignPublicKey();
            rSAKeyService.DisposeRSA();
        }

        private static void DecryptPassword()
        {
            RSAEncrypterService rSAEncrypterService = new RSAEncrypterService();

            const string privateKeyPath = "c:\\temp\\privatekey.xml";

            Console.WriteLine("Insert encrypted password");

            var encryptedPassword = Console.ReadLine();

            var decryptedPassword = rSAEncrypterService.DecryptData(privateKeyPath, encryptedPassword);

            Console.WriteLine($"Decrypted password: {Encoding.Default.GetString(decryptedPassword)}");
            Console.ReadKey();

        }
    }
}