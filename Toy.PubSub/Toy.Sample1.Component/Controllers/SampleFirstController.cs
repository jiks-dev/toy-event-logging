using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Toy.Pubsub.Services;

namespace Toy.Sample1.Component.Controllers
{
    [Route("sample-first")]
    public class SampleFirstController : Controller
    {
        private const string PublishEventName = "SampleFirstController";
        private const string SubscribeEventName = "SampleSecondController";

        private readonly IPubSubService _pubSubService;

        public SampleFirstController(IPubSubService pubSubService)
        {
            _pubSubService = pubSubService;
        }

        [HttpPut("subscribe")]
        public IActionResult SubSubscribe()
        {
            _pubSubService.Subscribe(SubscribeEventName, (value) => 
            {
                Console.WriteLine($"SampleFirstController Subscribe : {value}");
            });

            return Ok();
        }

        [HttpPut("publish")]
        public IActionResult Publish()
        {
            _pubSubService.Publish(PublishEventName, "SampleFirstController Send");
            return Ok();
        }
    }
}
