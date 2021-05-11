using Azure.Messaging.WebPubSub;
using System;
using System.Threading.Tasks;

namespace FacuTheRock.Talks.Azure.WebPubSub.Publisher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Azure Days Latinoamierca 2021");
            Console.WriteLine("Welcome to the Azure Web PubSub - Producer\n\n");

            var serviceClient = new WebPubSubServiceClient("<Connection string>", "<Hub>");

            string message;
            while ((message = ReadInput()) != "c")
            {
                await serviceClient.SendToAllAsync(message);
            }
        }

        private static string ReadInput()
        {
            Console.Write("Enter a message or press c to exit: ");
            return Console.ReadLine();
        }
    }
}
