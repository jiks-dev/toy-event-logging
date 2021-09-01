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
            var pubSubStage = _pubSubManager.GetPubSubStage(name);
            pubSubStage.Publish(value);
        }

        public int Subscribe(string name, Action<string> action)
        {
            _pubSubManager.RegisterPubSubStage(name);
            var pubSubStage = _pubSubManager.GetPubSubStage(name);
            var ticket = pubSubStage.SaveAction(action);
            return ticket;
        }
    }
}
