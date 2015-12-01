using Org.Kevoree.Log.Api;

namespace Org.Kevoree.Log
{
    public class LoggerSlave: Logger, ILoggerNode, IDelegateLogger
    {

        /**
         * It the local is permissive enougth we forward the message to the master.
         */
        public void forward(string caller, Level level, string message)
        {

            if (LevelComparator.pass(level, logLevel))
            {
                parentNode.forward(caller, level, message);
            }
        }


        public LoggerSlave(Level level, string name, IDelegateLogger parent) : base(level, name, parent)
        {
        }

        public ILogger createInstance(string name)
        {
            return new Logger(logLevel, name, this);
        }

        internal Level getLogLevel()
        {
            return logLevel;
        }
    }
}
