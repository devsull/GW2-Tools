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

            // var selfAssembly =

            var typesOfLoaders =
                assemblies.SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof (IConfigurationLoader))));

            var activatedTypesOfLoaders =
                typesOfLoaders.Select(type => Activator.CreateInstance(type) as IConfigurationLoader);

            foreach (var loader in activatedTypesOfLoaders)
            {
                loader?.Configure();
            }
        }
    }
}
