using System;
using System.Threading.Tasks;
using Websocket.Client;

namespace FacuTheRock.Talks.Azure.WebPubSub.Consumer
{
    class Program
    {
        private const string ClientAccessUrl = "<< Client Access URL >>";

        static async Task Main(string[] args)
        {
            #region Console Setup
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Azure Community Conference 2021");
            Console.WriteLine("Azure Web PubSub: Web Sockets Revolution");
            Console.WriteLine("By Facundo La Rocca\n");

            Console.WriteLine("Console App Consumer\n\n");
            #endregion

            using var client = new WebsocketClient(new Uri(ClientAccessUrl));

            using var _ = client.MessageReceived
                .Subscribe(msg => Console.WriteLine($"Message received: {msg}"));

            await client.Start();

            Console.WriteLine("Connected!!!");
            Console.Read();
        }
    }
}
