// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAccountBankMaterials.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Gets an account's materials contained in their "Materials bank".
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints.AccountBankMaterials
{
    using System.Collections.Generic;

    using LookUpValues.EndPointDefinitions;

    using GW2ApiRawObjects;

    using RestSharp;

    /// <summary>
    /// Gets an account's materials contained in their "Materials bank".
    /// </summary>
    public class GetAccountBankMaterials : BaseGw2ApiEndPoint<List<MaterialBankItem>>, IGw2ApiAuthEndPoint<AccountBankMaterials>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAccountBankMaterials"/> class.
        /// </summary>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <param name="restClient">
        /// The rest client.
        /// </param>
        public GetAccountBankMaterials(Settings settings, RestClient restClient) : base(settings, restClient)
        {
            this.ApiEndPoint = Gw2EndPoints.Account;
            this.ApiResources = new List<string> { Gw2EndPointResources.Material };
        }

        /// <summary>
        /// The handle request.
        /// </summary>
        /// <param name="apiKey">
        ///     The guild wars 2 API key.
        /// </param>
        /// <param name="resourceEndPoint">
        ///     The resource end point.
        /// </param>
        /// <returns>
        /// The <see cref="AccountBankMaterials"/>.
        /// </returns>
        public Gw2ApiResponse<AccountBankMaterials> HandleRequest(string apiKey, string resourceEndPoint = null)
        {
            var response = this.Execute(apiKey);

            return new Gw2ApiResponse<AccountBankMaterials>
                       {
                           Data =
                               new AccountBankMaterials
                                   {
                                       Materials = response.Data
                                   },
                           ErrorMessages = response.ErrorMessages
                       };
        }
    }
}