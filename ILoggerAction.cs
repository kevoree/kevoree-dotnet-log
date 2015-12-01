using Org.Kevoree.Log.Api;

namespace Org.Kevoree.Log
{
    public interface ILoggerAction
    {
        void proceed(string caller, Level level, string message);
    }
}
