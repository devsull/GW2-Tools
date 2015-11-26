using ShortStack.Core.Configuration;
using SimpleInjector;

namespace ShortStack.Core
{
    public static class ShortStack
    {
        public static Container Container = new Container();

        private static bool booted = false;

        private static object bootLock = new object();

        public static void BootStack()
        {
            lock (bootLock)
            {
                if (!booted)
                {
                    ConfigurationLoader.LoadConfigurations();
                    booted = true;
                }
            }
        }
    }
}
