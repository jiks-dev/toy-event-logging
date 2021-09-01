using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Toy.Pubsub.Models
{
    public class PubSubStage
    {
        private string _name;
        private int _counter;
        private Dictionary<int, Action<string>> _actions;

        public PubSubStage(string name)
        {
            _name = name;
            _counter = 0;
            _actions = new Dictionary<int, Action<string>>();
        }

        public int SaveAction(Action<string> action)
        {
            var ticket = Interlocked.Increment(ref _counter);
            _actions.Add(ticket, action);
            return ticket;
        }

        public void RemoveAction(int ticket)
        {
            _actions.Remove(ticket);
        }

        public void Publish(string json) 
        {
            var actions = _actions.Values.ToList();
            actions.ForEach((action) => action(json));
        }
    }
}
