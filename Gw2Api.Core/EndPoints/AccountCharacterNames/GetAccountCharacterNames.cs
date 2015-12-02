// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAccountCharacterNames.cs" company="Devin Sullivan">
//   I made this!
// </copyright>
// <summary>
//   The get account character names will get all the names of your gw2 characters on your account. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints.AccountCharacterNames
{
    using ApiEndPointDefinitions;
    using System.Collections.Generic;
    using RestSharp;

    /// <summary>
    /// The get account character names.
    /// </summary>
    public class GetAccountCharacterNames : BaseGw2ApiEndPoint<List<string>>, IGw2ApiAuthEndPoint<AccountCharacterNames>
    {
        public GetAccountCharacterNames(Settings settings, RestClient restClient)
            : base(settings, restClient)
        {
            this.ApiEndPoint = Gw2EndPoints.Characters;
        }

        public AccountCharacterNames HandleRequest(string apiKey, string resourceEndPoint = null)
        {
            var data = base.Execute(apiKey);
            
            return new AccountCharacterNames { Names = data };
        }
    }
}
