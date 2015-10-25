using System;
using System.Text;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Org.Kevoree.Log.Api;

namespace Org.Kevoree.Log
{
    public class Logger : MarshalByRefObject, ILogger
    {

        protected Level logLevel;
        private readonly string name;
        protected IDelegateLogger parentNode;

        public Logger(Level level, string name, IDelegateLogger parent)
        {
            this.logLevel = level;
            this.name = name;
            this.parentNode = parent;
        }


        private void log(string message, Level currentLevel)
        {
            if (this.logLevel <= currentLevel)
            {
                parentNode.forward(name, currentLevel, message);
            }
        }

        public void Error(string message)
        {
            this.log(message, Level.Error);
        }

        public void Warn(string message)
        {
            this.log(message, Level.Warn);
        }

        public void Info(string message)
        {
            this.log(message, Level.Info);
        }

        public void Debug(string message)
        {
            this.log(message, Level.Debug);
        }

        public void Trace(string message)
        {
            this.log(message, Level.Trace);
        }

        public void setLevel(string level)
        {
            this.logLevel = (Level) Enum.Parse(typeof(Level), level.Substring(0,1).ToUpper() + level.Substring(1).ToLower());
        }
    }
}

