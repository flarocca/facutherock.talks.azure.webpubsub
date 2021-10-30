using Azure.Messaging.WebPubSub;
using System;
using System.Threading.Tasks;

namespace FacuTheRock.Talks.Azure.WebPubSub.Publisher
{
    class Program
    {
        private const string ConnectionString = "<< Connection String >>";
        private const string Hub = "<< Hub >>";

        static async Task Main(string[] args)
        {
            #region Console Setup
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Azure Community Conference 2021");
            Console.WriteLine("Azure Web PubSub - Web Sockets Revolution");
            Console.WriteLine("By Facundo La Rocca\n");

            Console.WriteLine("Console App Producer\n\n");
            #endregion

            var serviceClient = new WebPubSubServiceClient(ConnectionString, Hub);

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
