// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAccountCharacterNames.cs" company="Devin Sullivan">
//   I made this!
// </copyright>
// <summary>
//   The get account character names will get all the names of your gw2 characters on your account. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Gw2Api.Core.EndPoints;
using Gw2Api.Core.EndPoints.AccountCharacterNames;

namespace Gw2Api.Core
{
    using RestSharp;

    /// <summary>
    /// The get account character names.
    /// </summary>
    public class GetAccountCharacterNames : BaseGw2ApiEndPoint<List<string>>, IGw2ApiAuthEndPoint<AccountCharacterNames>
    {
        public GetAccountCharacterNames(Settings settings, RestClient restClient)
            : base(settings, restClient)
        {
            this.ApiEndPoint = "characters";
        }

        public AccountCharacterNames HandleRequest(string apiKey, string[] resources = null)
        {
            var data = base.Execute(apiKey);

            // var mapped = Mapper.Map<List<string>, AccountCharacterNames>(data);

            return new AccountCharacterNames { Names = data };

            // return mapped;
        }
    }
}
