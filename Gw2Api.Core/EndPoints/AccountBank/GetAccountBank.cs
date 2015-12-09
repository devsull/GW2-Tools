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

    using Gw2Api.Core.LookUpValues.EndPointDefinitions;

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
        ///     The api key.
        /// </param>
        /// <param name="resourceEndPoint">
        ///     The resource end point.
        /// </param>
        /// <returns>
        /// The <see cref="AccountBank"/>.
        /// </returns>
        public Gw2ApiResponse<AccountBank> HandleRequest(string apiKey, string resourceEndPoint = null)
        {
            var response = this.Execute(apiKey);

            var data = new AccountBank { Items = response.Data };

            return new Gw2ApiResponse<AccountBank> { ErrorMessages = response.ErrorMessages, Data = data };
        }
    }
}