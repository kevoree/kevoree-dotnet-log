
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.Kevoree.Log.Api;

namespace Org.Kevoree.Log
{
    public interface IDelegateLogger
    {
        void forward(string name, Level level, string message);
    }
}
