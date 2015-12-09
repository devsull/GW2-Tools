// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetItemDescriptions.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Gets item descriptions from the guild wars 2 API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints.Items
{
    using System.Collections.Generic;
    using System.Linq;

    using Gw2Api.Core.LookUpValues.EndPointDefinitions;

    using GW2ApiRawObjects;

    using RestSharp;

    using ShortStack.Core;

    /// <summary>
    /// Gets item descriptions from the guild wars 2 API.
    /// </summary>
    public class GetItemDescriptions : BaseGw2ApiEndPoint<List<Item>>, IGw2ApiEndPoint<List<ItemDescription>>
    {
        /// <summary>
        /// The ids query parameter for the GW2 API.
        /// </summary>
        private readonly string idsParam = "ids";

        /// <summary>
        /// This is the limit of item ids that we can request at a time on the GW2 API.
        /// </summary>
        private readonly int idLimit = 200;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetItemDescriptions"/> class.
        /// </summary>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <param name="restClient">
        /// The rest client.
        /// </param>
        public GetItemDescriptions(Settings settings, RestClient restClient)
            : base(settings, restClient)
        {
            this.ApiEndPoint = Gw2EndPoints.Items;
        }

        /// <summary>
        /// The handle request.
        /// </summary>
        /// <param name="itemIds">
        /// The item ids.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<ItemDescription> HandleRequest(List<string> itemIds)
        {
            var itemDescriptions = new List<Item>();

            var total = itemIds.Count;

            //// TODO: handle failed requests

            // execute one api call per id limit
            for (var i = 0; i < total; i += this.idLimit)
            {
                // clear out any params from the last call
                this.ApiQueryParams.Clear();

                // get the next item ids to query for
                var values = itemIds.Skip(i).Take(this.idLimit).ToList();

                this.ApiQueryParams.Add(this.idsParam, values);

                var apiResponse = this.Execute();

                itemDescriptions.AddRange(apiResponse.Data);
            }

            var response = Mapper.Map<List<Item>, List<ItemDescription>>(itemDescriptions);
            
            return response;
        }
    }
}