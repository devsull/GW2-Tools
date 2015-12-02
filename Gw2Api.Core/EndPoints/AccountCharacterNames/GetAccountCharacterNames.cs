// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAccountCharacterNames.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Gets all character names for a Guild Wars 2 account. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints.AccountCharacterNames
{
    using System.Collections.Generic;

    using ApiEndPointDefinitions;

    using RestSharp;

    /// <summary>
    /// Gets all character names for a Guild Wars 2 account. 
    /// </summary>
    public class GetAccountCharacterNames : BaseGw2ApiEndPoint<List<string>>, IGw2ApiAuthEndPoint<AccountCharacterNames>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAccountCharacterNames"/> class.
        /// </summary>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <param name="restClient">
        /// The rest client.
        /// </param>
        public GetAccountCharacterNames(Settings settings, RestClient restClient)
            : base(settings, restClient)
        {
            this.ApiEndPoint = Gw2EndPoints.Characters;
        }

        /// <summary>
        /// The handle request.
        /// </summary>
        /// <param name="apiKey">
        /// The api key.
        /// </param>
        /// <param name="resourceEndPoint">
        /// The resource end point.
        /// </param>
        /// <returns>
        /// The <see cref="AccountCharacterNames"/>.
        /// </returns>
        public AccountCharacterNames HandleRequest(string apiKey, string resourceEndPoint = null)
        {
            var data = this.Execute(apiKey);
            
            return new AccountCharacterNames { Names = data };
        }
    }
}
