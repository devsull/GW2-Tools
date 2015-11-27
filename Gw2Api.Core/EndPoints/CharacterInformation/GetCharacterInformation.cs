
namespace Gw2Api.Core.EndPoints.CharacterInformation
{

    using System.Collections.Generic;
    using ApiEndPointDefinitions;
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
            this.ApiEndPoint = Gw2EndPoints.Characters;
        }
        
        public CharacterInformation HandleRequest(string apiKey, string name = null)
        {
            // add name to the resource list
            this.ApiResources = new List<string> {name };

            var data = base.Execute(apiKey);

            var mapped = Mapper.Map<Character, EndPoints.CharacterInformation.CharacterInformation>(data);

            return mapped;
        }
    }
}