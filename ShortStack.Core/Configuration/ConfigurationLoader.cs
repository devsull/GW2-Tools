using System;
using System.Linq;

namespace ShortStack.Core.Configuration
{
    /// <summary>
    /// The configuration loader.
    /// </summary>
    public static class ConfigurationLoader
    {
        /// <summary>
        /// Uses reflection to find all of the implementations of IConfigurationLoader and runs configure on them.
        /// </summary>
        /// <remarks>
        /// A major simplifying assumption of this method is that all assemblies are allready loaded into the app domain.
        /// It will not load any others.
        /// </remarks>
        public static void LoadConfigurations()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IConfigurationLoader)));
                foreach (var instance in types.Select(type => Activator.CreateInstance(type) as IConfigurationLoader))
                {
                    instance?.Configure();
                }
            }
        }
    }
}
