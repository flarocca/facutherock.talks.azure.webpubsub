using System;
using System.Threading.Tasks;
using Websocket.Client;

namespace FacuTheRock.Talks.Azure.WebPubSub.Consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Azure Days Latinoamierca 2021");
            Console.WriteLine("Welcome to the Azure Web PubSub - Consumer\n\n");

            using var client = new WebsocketClient(new Uri("<Client URI>"));

            using var _ = client.MessageReceived
                .Subscribe(msg => Console.WriteLine($"Message received: {msg}"));

            await client.Start();

            Console.WriteLine("Connected!!!");
            Console.Read();
        }
    }
}
