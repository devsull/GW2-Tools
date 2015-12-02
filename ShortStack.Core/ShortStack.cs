// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShortStack.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The short stack.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ShortStack.Core
{
    using Configuration;

    using SimpleInjector;

    /// <summary>
    /// The short stack.
    /// </summary>
    public static class ShortStack
    {
        /// <summary>
        /// The container.
        /// </summary>
        public static Container Container { get; } = new Container();

        /// <summary>
        /// The boot lock.
        /// </summary>
        private static readonly object BootLock = new object();

        /// <summary>
        /// The booted.
        /// </summary>
        private static bool booted = false;
        
        /// <summary>
        /// Boots the ShortStack.
        /// </summary>
        /// <param name="loadDiscovery">
        /// Will attempt to discover configurations unless this is set to false.
        /// TODO: make this cleaner.
        /// </param>
        public static void BootStack(bool loadDiscovery = true)
        {
            lock (BootLock)
            {
                if (booted)
                {
                    return;
                }

                if (loadDiscovery)
                {
                    ConfigurationLoader.LoadConfigurations();
                }
                booted = true;
            }
        }
    }
}
