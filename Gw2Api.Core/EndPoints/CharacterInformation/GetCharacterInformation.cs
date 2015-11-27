

namespace Gw2Api.Core.EndPoints.CharacterInformation
{
    using System;
    using System.Linq;
    using GW2ApiRawObjects;
    using RestSharp;
    using ShortStack.Core;

    /// <summary>
    /// The get account character names.
    /// </summary>
    public class GetCharacterInformation : BaseGw2ApiEndPoint<Character>, IGw2ApiAuthEndPoint<CharacterInformation>
    {
        public GetCharacterInformation(Settings settings, RestClient restClient)
            : base(settings, restClient)
        {
            this.ApiEndPoint = Gw2EndPoints.CharactersEndPoint;
        }
        
        public CharacterInformation HandleRequest(string apiKey, string[] name)
        {
            if (name.Length > 1)
            {
                throw new InvalidOperationException("Cannot get multiple character names at a time yet...!");
            }

            this.ApiResources = name.ToList();

            var data = base.Execute(apiKey);

            var mapped = Mapper.Map<Character, EndPoints.CharacterInformation.CharacterInformation>(data);

            return mapped;
        }
    }
}