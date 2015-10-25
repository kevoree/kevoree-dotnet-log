using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Org.Kevoree.Log.Api;

namespace Org.Kevoree.Log
{
    public class LoggerMaster : Logger, IDelegateLogger
    {

        private Dictionary<string, LoggerSlave> map = new Dictionary<string, LoggerSlave>();

        public void forward(string caller, Level level, string message)
        {
            if (level >= this.logLevel)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(DateTime.UtcNow.ToString("HH:mm:ss.fff"));
                sb.Append(' ');
                sb.Append(level);
                sb.Append(' ');
                sb.Append(caller);
                sb.Append(' ');
                sb.Append(message);
                Console.WriteLine(sb.ToString());
            }
        }

        public LoggerMaster(Level level, string name) : base(level, name, null)
        {
            this.parentNode = this;
        }


        public ILogger getInstance(string name)
        {
            var loggerSalve = new LoggerSlave(this.logLevel, name, this);
            map.Add(name, loggerSalve);
            return loggerSalve;
        }

        public ILogger getInstance(string nodeName, string name)
        {
            var parentNode = map[nodeName];

            return new Logger(Level.Trace, name, parentNode);
        }
    }
}
