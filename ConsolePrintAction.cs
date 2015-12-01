using System;
using System.Text;
using Org.Kevoree.Log.Api;

namespace Org.Kevoree.Log
{
    public class ConsolePrintAction:ILoggerAction
    {
        public void proceed(string caller, Level level, string message)
        {
            var sb = new StringBuilder();
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
}