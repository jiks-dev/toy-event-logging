using System;
using System.Collections.Concurrent;
using Toy.Pubsub.Services;

namespace Toy.Pubsub
{
    public class PubSubManager : IPubSubManager
    {
        private ConcurrentDictionary<string, Action<string>> actions;

        public PubSubManager()
        {
            actions = new ConcurrentDictionary<string, Action<string>>();
        }

        public Action<string> GetAction(string name)
        {
            // TODO : throw null error 
            actions.TryGetValue(name, out var action);
            return action;
        }

        public void SetAction(string name, Action<string> action)
        {
            actions.TryAdd(name, action);
        }
    }
}
