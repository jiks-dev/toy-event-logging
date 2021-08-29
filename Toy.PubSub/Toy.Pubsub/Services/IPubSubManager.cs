using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toy.Pubsub.Services
{
    public interface IPubSubManager
    {
        Action<string> GetAction(string name);
        void SetAction(string name, Action<string> action);
    }
}
