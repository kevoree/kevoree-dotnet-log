using System;
using NUnit.Framework;

namespace Org.Kevoree.Log
{

	[TestFixture]
	public class LogTest
	{
		public LogTest ()
		{
		}

		[Test]
		public void testINFO ()
		{
			var log = LogFactory.getLog (this.GetType().ToString(), Level.INFO);
			log.Error ("OK");
			log.Warn ("OK");
			log.Info ("OK");
			log.Debug ("PAS OK");
			log.Trace ("PAS OK");
		}

		[Test]
		public void testNONE ()
		{
			var log = LogFactory.getLog (this.GetType().ToString(), Level.NONE);
			log.Error ("PAS OK");
			log.Warn ("PAS OK");
			log.Info ("PAS OK");
			log.Debug ("PAS OK");
			log.Trace ("PAS OK");
		}

		[Test]
		public void testERROR ()
		{
			var log = LogFactory.getLog (this.GetType().ToString(), Level.ERROR);
			log.Error ("OK");
			log.Warn ("PAS OK");
			log.Info ("PAS OK");
			log.Debug ("PAS OK");
			log.Trace ("PAS OK");
		}

		[Test]
		public void testTRACE ()
		{
			var log = LogFactory.getLog (this.GetType().ToString(), Level.TRACE);
			log.Error ("OK");
			log.Warn ("OK");
			log.Info ("OK");
			log.Debug ("OK");
			log.Trace ("OK");
		}
		[Test]
		public void testCategory ()
		{
			var log = LogFactory.getLog (this.GetType().ToString(), Level.ERROR, "TEST");
			log.Error ("OK");
			log.Debug ("PAS OK");
		}
	}
}

