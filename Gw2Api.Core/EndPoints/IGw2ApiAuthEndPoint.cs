// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGw2ApiAuthEndPoint.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The Gw2ApiAuthEndPoint interface - signature for GW2 API calls that require authentication through an API key
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints
{
    /// <summary>
    /// The Gw2ApiAuthEndPoint interface - signature for GW2 API calls that require authentication through an API key.
    /// </summary>
    /// <typeparam name="T">
    /// Type of data that the implementation will return.
    /// </typeparam>
    public interface IGw2ApiAuthEndPoint<T> where T : new()
    {
        /// <summary>
        /// The handle request.
        /// </summary>
        /// <param name="apiKey">
        /// The guild wars 2 API key.
        /// </param>
        /// <param name="resourceEndPoint">
        /// Optional resource end point.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T HandleRequest(string apiKey, string resourceEndPoint = null);
    }
}