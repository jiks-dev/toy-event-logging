using System;

namespace Toy.Pubsub.Services
{
    public class PubSubService : IPubSubService
    {
        private readonly IPubSubManager _pubSubManager;

        public PubSubService(IPubSubManager pubSubManager)
        {
            _pubSubManager = pubSubManager;
        }

        public void Publish(string name, string value)
        {
            var action = _pubSubManager.GetAction(name);
            action(value);
        }

        public void Subscribe(string name, Action<string> action)
        {
            _pubSubManager.SetAction(name, action);
        }
    }
}
