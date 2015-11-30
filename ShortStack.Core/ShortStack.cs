using System;
using System.Reflection;
using ShortStack.Core.Configuration;
using SimpleInjector;

namespace ShortStack.Core
{
    public static class ShortStack
    {
        public static Container Container = new Container();

        private static bool booted = false;

        private static object bootLock = new object();

        public static void BootStack(bool loadDiscovery = true)
        {
            lock (bootLock)
            {
                if (!booted)
                {
                    if (loadDiscovery)
                    {
                        ConfigurationLoader.LoadConfigurations();
                    }
                    booted = true;
                }
            }
        }
    }
}
