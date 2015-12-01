using System;
using Org.Kevoree.Log.Api;

namespace Org.Kevoree.Log
{
    public class Logger : MarshalByRefObject, ILogger
    {

        protected Level logLevel;
        private readonly string _name;
        protected IDelegateLogger parentNode;

        public Logger(Level level, string name, IDelegateLogger parent)
        {
            logLevel = level;
            _name = name;
            parentNode = parent;
        }


        private void log(string message, Level currentLevel)
        {
            if (LevelComparator.pass(currentLevel, logLevel))
            {
                parentNode.forward(_name, currentLevel, message);
            }
        }

        public void Error(string message)
        {
            log(message, Level.Error);
        }

        public void Warn(string message)
        {
            log(message, Level.Warn);
        }

        public void Info(string message)
        {
            log(message, Level.Info);
        }

        public void Debug(string message)
        {
            log(message, Level.Debug);
        }

        public void Trace(string message)
        {
            log(message, Level.Trace);
        }

        public void setLevel(string level)
        {
            logLevel = (Level) Enum.Parse(typeof(Level), level.Substring(0,1).ToUpper() + level.Substring(1).ToLower());
        }
    }
}

