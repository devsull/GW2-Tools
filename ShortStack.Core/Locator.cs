// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Locator.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Locates objects in the IoC container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ShortStack.Core
{
    /// <summary>
    /// Locates objects in the IoC container.
    /// </summary>
    public static class Locator
    {
        /// <summary>
        /// Gets an instance of an object in the ShortStack container.
        /// </summary>
        /// <typeparam name="T">
        /// Type of object.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T GetInstance<T>() where T : class
        {
            return ShortStack.Container.GetInstance<T>();
        }
    }
}