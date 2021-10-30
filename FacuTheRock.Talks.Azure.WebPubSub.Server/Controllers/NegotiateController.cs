using Azure.Messaging.WebPubSub;
using Microsoft.AspNetCore.Mvc;

namespace FacuTheRock.Talks.Azure.WebPubSub.Server.Controllers
{
    [ApiController]
    [Route("api/negotiate")]
    public class NegotiateController : ControllerBase
    {
        private readonly WebPubSubServiceClient _pubsubClient;

        public NegotiateController(WebPubSubServiceClient pubsubClient) =>
            _pubsubClient = pubsubClient;

        //[Authorize] --> Authenticate/Authorize user as usual
        [HttpGet]
        public IActionResult Get()
        {
            var clientAccessUrl = _pubsubClient.GenerateClientAccessUri().AbsoluteUri;
            return Ok(clientAccessUrl);
        }
    }
}
