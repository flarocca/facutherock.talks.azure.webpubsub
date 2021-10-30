using Azure.Messaging.WebPubSub;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.WebPubSub;
using System;
using System.Threading.Tasks;

namespace FacuTheRock.Talks.Azure.WebPubSub.Serverless
{
    public static class Publisher
    {
        private const string ConnectionStringSetting = "ConnectionString";
        private const string Hub = "<< Hub >>";

        [FunctionName("Publisher")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "serverless/publish")] 
                HttpRequest req,
            [WebPubSub(ConnectionStringSetting = ConnectionStringSetting, Hub = Hub)] 
                IAsyncCollector<WebPubSubOperation> operations)
        {
            var message = req.Query["message"];

            await operations.AddAsync(new SendToAll
            {
                Message = BinaryData.FromString($"Azure Function producer: {message}"),
                DataType = MessageDataType.Text
            });

            return new OkObjectResult("Message sent...");
        }
    }
}

