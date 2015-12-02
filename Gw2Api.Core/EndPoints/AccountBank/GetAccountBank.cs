// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAccountBank.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Gets all the items in an account's bank.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints.AccountBank
{
    using System.Collections.Generic;

    using ApiEndPointDefinitions;
    using GW2ApiRawObjects;

    using RestSharp;

    /// <summary>
    /// Gets all the items in an account's bank.
    /// </summary>
    public class GetAccountBank : BaseGw2ApiEndPoint<List<InventoryItem>>, IGw2ApiAuthEndPoint<AccountBank>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAccountBank"/> class.
        /// </summary>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <param name="restClient">
        /// The rest client.
        /// </param>
        public GetAccountBank(Settings settings, RestClient restClient) : base(settings, restClient)
        {
            this.ApiEndPoint = Gw2EndPoints.Account;
            this.ApiResources = new List<string> { Gw2EndPointResources.Bank };
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
        /// The <see cref="AccountBank"/>.
        /// </returns>
        public AccountBank HandleRequest(string apiKey, string resourceEndPoint = null)
        {
            var data = this.Execute(apiKey);
            
            return new AccountBank { Items = data };
        }
    }
}