// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mapper.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Map an object from one type to another!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ShortStack.Core
{
    using Nelibur.ObjectMapper;

    /// <summary>
    /// Map an object from one type to another!
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Maps one object to another in TinyMapper.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <typeparam name="TSrc">
        /// Type of source.
        /// </typeparam>
        /// <typeparam name="TDest">
        /// Type of destination.
        /// </typeparam>
        /// <returns>
        /// The <see cref="TDest"/>.
        /// </returns>
        public static TDest Map<TSrc, TDest>(TSrc source) where TDest : class
        {
            return TinyMapper.Map<TDest>(source);
        }
    }
}