using System.Collections.Generic;
using Gw2Api.Core.ApiEndPointDefinitions;
using Gw2Api.Core.GW2ApiRawObjects;
using RestSharp;

namespace Gw2Api.Core.EndPoints.AccountBank
{
    public class GetAccountBankMaterials : BaseGw2ApiEndPoint<List<MaterialBankItem>>, IGw2ApiAuthEndPoint<AccountBankMaterials>
    {
        public GetAccountBankMaterials(Settings settings, RestClient restClient) : base(settings, restClient)
        {
            this.ApiEndPoint = Gw2EndPoints.Account;
            this.ApiResources = new List<string> { Gw2EndPointResources.Material };
        }

        public AccountBankMaterials HandleRequest(string apiKey, string resourceEndPoint = null)
        {
            var data = base.Execute(apiKey);
            
            return new AccountBankMaterials { Materials = data };
        }
    }
}