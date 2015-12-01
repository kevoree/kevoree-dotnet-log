using Org.Kevoree.Log.Api;

namespace Org.Kevoree.Log
{
    public interface IDelegateLogger
    {
        void forward(string name, Level level, string message);
    }
}
