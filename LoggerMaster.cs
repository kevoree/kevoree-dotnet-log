using System.Collections.Generic;
using Org.Kevoree.Log.Api;

namespace Org.Kevoree.Log
{
    public class LoggerMaster : Logger, IDelegateLogger
    {

        private readonly Dictionary<string, LoggerSlave> _map = new Dictionary<string, LoggerSlave>();
        private ILoggerAction _action = new ConsolePrintAction();

        public ILoggerAction Action
        {
            set { _action = value; }
        }

        public void forward(string caller, Level level, string message)
        {
            if (LevelComparator.pass(level,logLevel))
            {
                _action.proceed(caller, level, message);
            }
        }

        public LoggerMaster(Level level, string name) : base(level, name, null)
        {
            parentNode = this;
        }


        public ILogger getInstance(string name)
        {
            var loggerSalve = new LoggerSlave(logLevel, name, this);
            _map.Add(name, loggerSalve);
            return loggerSalve;
        }

        public ILogger getInstance(string nodeName, string name)
        {
            return new Logger(Level.Trace, name, _map[nodeName]);
        }
    }
}
