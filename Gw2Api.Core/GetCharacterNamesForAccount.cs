// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCharacterNamesForAccount.cs" company="Devin Sullivan">
//   I made this!
// </copyright>
// <summary>
//   The get account character names will get all the names of your gw2 characters on your account. 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Gw2Api.Core.GW2ApiRawObjects;
using ShortStack.Core;

namespace Gw2Api.Core
{
    using RestSharp;

    /// <summary>
    /// The get account character names.
    /// </summary>
    public class GetCharacterNamesForAccount : BaseGw2ApiEndPoint<List<string>>, IGw2ApiAuthEndPoint<CharacterNamesForAccount>
    {
        private const string endPoint = "characters";

        public GetCharacterNamesForAccount(Settings settings, RestClient restClient)
            : base(settings, restClient, endPoint)
        {
        }

        public CharacterNamesForAccount HandleRequest(string apiKey)
        {
            var data = base.Execute(apiKey);

            // var mapped = Mapper.Map<List<string>, CharacterNamesForAccount>(data);

            return new CharacterNamesForAccount { Names = data };

            // return mapped;
        }
    }

    /// <summary>
    /// The get account character names.
    /// </summary>
    public class GetCharacterInformation : BaseGw2ApiEndPoint<Character> //, IGw2ApiAuthEndPoint<CharacterInformation> // TODO Figure out how to clean this up!
    {
        private const string endPoint = "characters";

        public GetCharacterInformation(Settings settings, RestClient restClient)
            : base(settings, restClient, endPoint)
        {
        }

        public CharacterInformation HandleRequest(string name, string apiKey)
        {
            var resources = new string[] {name};

            var data = base.Execute(apiKey, resources);

            var mapped = Mapper.Map<Character, CharacterInformation>(data);

            return mapped;
        }
    }
}
