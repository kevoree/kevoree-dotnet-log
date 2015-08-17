using System;
using System.Text;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Reflection;

namespace Org.Kevoree.Log
{

	public class Log
	{
		private string category;

		string caller;

		private bool PRINT_ERROR = false;

		private bool PRINT_TRACE = false;

		private bool PRINT_DEBUG = false;

		private bool PRINT_INFO = false;

		private bool PRINT_WARN = false;

		private void ResolveLevels (Level level)
		{
			if (level <= Level.ERROR) {
				this.PRINT_ERROR = true;
			}

			if (level <= Level.WARN) {
				this.PRINT_WARN = true;
			}
			if (level <= Level.INFO) {
				this.PRINT_INFO = true;
			}
			if (level <= Level.DEBUG) {
				this.PRINT_DEBUG = true;
			}
			if (level <= Level.TRACE) {
				this.PRINT_TRACE = true;
			}
		}

		public Log (string caller, Level level)
		{
			
			ResolveLevels (level);
			this.caller = caller;

		}

		public Log (string caller, Level level, string category)
		{
			ResolveLevels (level);
			this.category = category;
			this.caller = caller;
		}

		private void log (string message)
		{
			StringBuilder sb = new StringBuilder ();

			if (caller != null) {
				sb.Append (caller);
				sb.Append (' ');
			}

			if (category != null) {
				sb.Append ('[');
				sb.Append (category);
				sb.Append (']');
				sb.Append (' ');
			}


			if (message != null) {
				sb.Append (message);
			}
			Console.WriteLine (sb.ToString());
		}

		public void Error (string message)
		{
			if (this.PRINT_ERROR) {
				this.log (message);
			}
		}

		public void Warn (string message)
		{
			if (this.PRINT_WARN) {
				this.log (message);
			}
		}

		public void Info (string message)
		{
			if (this.PRINT_INFO) {
				this.log (message);
			}
		}

		public void Debug (string message)
		{
			if (this.PRINT_DEBUG) {
				this.log (message);
			}
		}

		public void Trace (string message)
		{
			if (this.PRINT_TRACE) {
				this.log (message);
			}
		}
	}
}

