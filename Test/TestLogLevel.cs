using NUnit.Framework;
using Org.Kevoree.Log.Api;

namespace Org.Kevoree.Log.Test
{
    [TestFixture]
    class TestLogLevel
    {
        [Test]
        public void testWarn()
        {
            var logger = new LoggerMaster(Level.Warn, "test");
            logger.Action = new TestAction("test");
            logger.Debug("a");
            logger.Trace("a");
            logger.Info("a");
            logger.Warn("a");
            logger.Error("a");
        }

        [Test]
        public void testNone()
        {
            var logger = new LoggerMaster(Level.None, "test");
            logger.Action = new TestFailAction();
            logger.Debug("a");
            logger.Trace("a");
            logger.Info("a");
            logger.Warn("a");
            logger.Error("a");
        }

        [Test]
        public void testWarnWithOneChild()
        {
            var loggerM = new LoggerMaster(Level.Info, "test");
            loggerM.Action = new TestAction("test1");
            var logger = loggerM.getInstance("test1");
            logger.setLevel(Level.Warn.ToString());
            logger.Debug("a");
            logger.Trace("a");
            logger.Info("a");
            logger.Warn("a");
            logger.Error("a");
        }

        [Test]
        public void testWarnWithOneChildRestrictive()
        {
            var loggerM = new LoggerMaster(Level.Warn, "test");
            loggerM.Action = new TestAction("test1");
            var logger = loggerM.getInstance("test1");
            logger.setLevel(Level.Debug.ToString());
            logger.Debug("a");
            logger.Trace("a");
            logger.Info("a");
            logger.Warn("a");
            logger.Error("a");
        }

        [Test]
        public void testWarnWithTwoChild()
        {
            var loggerM = new LoggerMaster(Level.Info, "test");
            loggerM.Action = new TestAction("test2");
            var loggerMid = loggerM.getInstance("test1");
            var logger = loggerM.getInstance("test1", "test2");
            logger.setLevel(Level.Warn.ToString());
            logger.Debug("a");
            logger.Trace("a");
            logger.Info("a");
            logger.Warn("a");
            logger.Error("a");
        }

        [Test]
        public void testWarnWithTwoChildRestrictive()
        {
            var loggerM = new LoggerMaster(Level.Warn, "test");
            loggerM.Action = new TestAction("test2");
            var loggerMid = loggerM.getInstance("test1");
            var logger = loggerM.getInstance("test1", "test2");
            logger.setLevel(Level.Trace.ToString());
            logger.Debug("a");
            logger.Trace("a");
            logger.Info("a");
            logger.Warn("a");
            logger.Error("a");
        }

        [Test]
        public void testWarnWithTwoChildRestrictive2()
        {
            var loggerM = new LoggerMaster(Level.Debug, "test");
            loggerM.Action = new TestAction("test2");
            var loggerMid = loggerM.getInstance("test1");
            loggerMid.setLevel(Level.Warn.ToString());
            var logger = loggerM.getInstance("test1", "test2");
            logger.setLevel(Level.Trace.ToString());
            logger.Debug("a");
            logger.Trace("a");
            logger.Info("a");
            logger.Warn("a");
            logger.Error("a");
        }

        internal class TestFailAction : ILoggerAction
        {
            public void proceed(string caller, Level level, string message)
            {
                Assert.Fail();
            }
        }

        internal class TestAction : ILoggerAction
        {
            private readonly string name;

            public TestAction(string name)
            {
                this.name = name;
            }

            public void proceed(string caller, Level level, string message)
            {
                Assert.True(level == Level.Warn|| level == Level.Error);
                Assert.AreEqual(name, caller);
            }
        }
    }
}
