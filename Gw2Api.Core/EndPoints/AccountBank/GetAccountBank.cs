using System.Collections.Generic;
using Gw2Api.Core.ApiEndPointDefinitions;
using Gw2Api.Core.GW2ApiRawObjects;
using RestSharp;

namespace Gw2Api.Core.EndPoints.AccountBank
{
    public class GetAccountBank : BaseGw2ApiEndPoint<List<InventoryItem>>, IGw2ApiAuthEndPoint<AccountBank>
    {
        public GetAccountBank(Settings settings, RestClient restClient) : base(settings, restClient)
        {
            this.ApiEndPoint = Gw2EndPoints.Account;
            this.ApiResources = new List<string> { Gw2EndPointResources.Bank };
        }

        public AccountBank HandleRequest(string apiKey, string resourceEndPoint = null)
        {
            var data = base.Execute(apiKey);
            
            return new AccountBank { Items = data };
        }
    }
}