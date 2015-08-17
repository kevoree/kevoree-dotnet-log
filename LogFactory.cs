using System;

namespace Org.Kevoree.Log
{
	public class LogFactory
	{
		private LogFactory ()
		{
		}
			
		public static Log getLog (string caller, Level level)
		{
			return new Log (caller, level);
		}

		public static Log getLog(string caller, Level level, string category) {
			return new Log (caller, level, category);
		}
	}
}

