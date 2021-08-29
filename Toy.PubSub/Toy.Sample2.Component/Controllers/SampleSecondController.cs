using Microsoft.AspNetCore.Mvc;
using System;
using Toy.Pubsub.Services;

namespace Toy.Sample2.Component.Controllers
{
    [Route("sample-second")]
    public class SampleSecondController : Controller
    {
        private const string PublishEventName = "SampleSecondController";
        private const string SubscribeEventName = "SampleFirstController";

        private readonly IPubSubService _pubSubService;

        public SampleSecondController(IPubSubService pubSubService)
        {
            _pubSubService = pubSubService;
        }

        [HttpPut("subscribe")]
        public IActionResult SubSubscribe()
        {
            _pubSubService.Subscribe(SubscribeEventName, (value) =>
            {
                Console.WriteLine($"SampleSecondController Subscribe : {value}");
            });

            return Ok();
        }

        [HttpPut("publish")]
        public IActionResult Publish()
        {
            _pubSubService.Publish(PublishEventName, "SampleSecondController Send");
            return Ok();
        }
    }
}
