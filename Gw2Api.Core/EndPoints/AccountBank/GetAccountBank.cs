using System.Collections.Generic;
using Gw2Api.Core.ApiEndPointDefinitions;
using Gw2Api.Core.GW2ApiRawObjects;
using RestSharp;

namespace Gw2Api.Core.EndPoints.AccountBank
{
    public class GetAccountBank : BaseGw2ApiEndPoint<List<InventoryItem>>, IGw2ApiAuthEndPoint<List<InventoryItem>>
    {
        public GetAccountBank(Settings settings, RestClient restClient) : base(settings, restClient)
        {
            this.ApiEndPoint = Gw2EndPoints.Account;
            this.ApiResources = new List<string> { Gw2EndPointResources.Bank };
        }

        public List<InventoryItem> HandleRequest(string apiKey, string resourceEndPoint = null)
        {
            var data = base.Execute(apiKey);
            
            // maybe map this to something better...?

            return  data;
        }
    }
}