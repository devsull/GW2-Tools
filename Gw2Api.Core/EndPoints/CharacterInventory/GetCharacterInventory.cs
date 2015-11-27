
namespace Gw2Api.Core.EndPoints.CharacterInventory
{
    using System.Collections.Generic;
    using ApiEndPointDefinitions;
    using GW2ApiRawObjects;
    using RestSharp;
    using ShortStack.Core;

    public class GetCharacterInventory : BaseGw2ApiEndPoint<Inventory>, IGw2ApiAuthEndPoint<CharacterInventory>
    {
        public GetCharacterInventory(Settings settings, RestClient restClient) : base(settings, restClient)
        {
            this.ApiEndPoint = Gw2EndPoints.Characters;
        }

        public CharacterInventory HandleRequest(string apiKey, string name)
        {
            // add name to the resource list
            // we also must have inventory to the list because we want the inventory of the character!
            this.ApiResources = new List<string> { name, Gw2EndPointResources.Inventory };

            var data = base.Execute(apiKey);

            var mapped = Mapper.Map<Inventory, CharacterInventory>(data);

            return mapped;
        }
    }
}