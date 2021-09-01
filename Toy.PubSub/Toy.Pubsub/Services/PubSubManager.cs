using System;
using System.Collections.Concurrent;
using Toy.Pubsub.Models;
using Toy.Pubsub.Services;

namespace Toy.Pubsub
{
    public class PubSubManager : IPubSubManager
    {
        private ConcurrentDictionary<string, PubSubStage> pubSubStages;

        public PubSubManager()
        {
            pubSubStages = new ConcurrentDictionary<string, PubSubStage>();
        }

        public PubSubStage GetPubSubStage(string name)
        {
            pubSubStages.TryGetValue(name, out var pubSubStage);
            return pubSubStage;
        }

        public void RegisterPubSubStage(string name)
        {
            var isFind = pubSubStages.TryGetValue(name, out var pubSubStage);
            if (isFind == false)
            {
                pubSubStage = new PubSubStage(name);
                pubSubStages.TryAdd(name, pubSubStage);
            }
        }
    }
}
