using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toy.Pubsub.Services
{
    public interface IPubSubService
    {
        // TODO : Add the currently registered Pub/Sub event lookup function

        void Publish(string name, string value);
        int Subscribe(string name, Action<string> action);
    }
}
