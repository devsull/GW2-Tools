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

    using Contracts;

    using GW2ApiRawObjects;

    using LookUpValues.EndPointDefinitions;

    using RestSharp;

    /// <summary>
    /// Gets all the items in an account's bank.
    /// </summary>
    public class GetAccountBank : BaseGw2ApiEndPoint<List<InventoryItem>>, IGetAccountBank
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
        /// The list of inventory items in the account's bank
        /// </returns>
        Gw2ApiResponse<List<InventoryItem>> IGw2ApiAuthEndPoint<List<InventoryItem>>.HandleRequest(string apiKey, string resourceEndPoint)
        {
            var response = this.Execute(apiKey);

            return response;
        }
    }
}