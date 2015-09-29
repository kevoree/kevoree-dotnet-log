using System;
using NUnit.Framework;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Org.Kevoree.Log
{

	[TestFixture]
	public class TestSerialization
	{
		public TestSerialization ()
		{
		}

		[Test]
		public void testSerilization ()
		{
            var obj = LogFactory.getLog("hello", Level.DEBUG);
            var tmpFile = Path.GetTempFileName();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(tmpFile,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();

            File.Delete(tmpFile);
		}

	}
}

