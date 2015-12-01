using Org.Kevoree.Log.Api;

namespace Org.Kevoree.Log
{
    public class LevelComparator
    {
        public static bool pass(Level asked, Level current)
        {
            return asked >= current;
        }
    }
}