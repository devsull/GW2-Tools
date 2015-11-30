namespace Gw2Api.Core.EndPoints.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Gw2Api.Core.ApiEndPointDefinitions;
    using Gw2Api.Core.GW2ApiRawObjects;

    using RestSharp;

    using ShortStack.Core;

    public class GetItemDescriptions : BaseGw2ApiEndPoint<List<Item>>, IGw2ApiEndPoint<List<ItemDescription>>
    {
        private string idsParam = "ids";

        private int idLimit = 200;

        public GetItemDescriptions(Settings settings, RestClient restClient)
            : base(settings, restClient)
        {
            this.ApiEndPoint = Gw2EndPoints.Items;
        }

        public List<ItemDescription> HandleRequest(List<string> itemIds)
        {
            var response = new List<ItemDescription>();

            var total = itemIds.Count;
            
            for (var i = 0; i < total; i += this.idLimit)
            {
                this.ApiQueryParams.Clear();
                var values = itemIds.Skip(i).Take(this.idLimit).ToList();
                this.ApiQueryParams.Add(this.idsParam, values);

                var data = this.Execute();

                var mapped = Mapper.Map<List<Item>, List<ItemDescription>>(data);

                response.AddRange(mapped);
            }

            return response;
        }
    }
}