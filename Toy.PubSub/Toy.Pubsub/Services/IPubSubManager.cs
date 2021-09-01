using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toy.Pubsub.Models;

namespace Toy.Pubsub.Services
{
    public interface IPubSubManager
    {
        PubSubStage GetPubSubStage(string name);

        // TODO : Lets you return a unique identification number.
        void RegisterPubSubStage(string name);
    }
}
