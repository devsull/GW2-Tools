namespace Gw2Api.Core.EndPoints
{
    using System.Collections.Generic;

    /// <summary>
    /// The Guild Wars 2 API unauthorized end point interface.
    /// </summary>
    /// <typeparam name="T">
    ///     T should be a class that exists in GW2ApiRawObjects
    /// </typeparam>
    public interface IGw2ApiEndPoint<T> where T : new()
    {
        /// <summary>
        /// The handle request.
        /// </summary>
        /// <param name="itemIds">
        /// The query string Params.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T HandleRequest(List<string> itemIds);
    }
}