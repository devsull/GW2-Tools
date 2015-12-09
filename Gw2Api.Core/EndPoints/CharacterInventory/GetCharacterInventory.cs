// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCharacterInventory.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Gets a character's bags and the items in their inventory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints.CharacterInventory
{
    using System.Collections.Generic;

    using Gw2Api.Core.LookUpValues.EndPointDefinitions;

    using GW2ApiRawObjects;
    using RestSharp;
    using ShortStack.Core;

    /// <summary>
    /// Gets a character's bags and the items in their inventory.
    /// </summary>
    public class GetCharacterInventory : BaseGw2ApiEndPoint<Inventory>, IGw2ApiAuthEndPoint<CharacterInventory>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharacterInventory"/> class.
        /// </summary>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <param name="restClient">
        /// The rest client.
        /// </param>
        public GetCharacterInventory(Settings settings, RestClient restClient) : base(settings, restClient)
        {
            this.ApiEndPoint = Gw2EndPoints.Characters;
        }

        /// <summary>
        /// The handle request.
        /// </summary>
        /// <param name="apiKey">
        ///     The guild wars 2 API key.
        /// </param>
        /// <param name="name">
        ///     The name.
        /// </param>
        /// <returns>
        /// The <see cref="CharacterInventory"/>.
        /// </returns>
        public Gw2ApiResponse<CharacterInventory> HandleRequest(string apiKey, string name = null)
        {
            // add name to the resource list
            // we also must have inventory to the list because we want the inventory of the character!
            this.ApiResources = new List<string> { name, Gw2EndPointResources.Inventory };

            var response = this.Execute(apiKey);
            
            var mapped = Mapper.Map<Inventory, CharacterInventory>(response.Data);

            return new Gw2ApiResponse<CharacterInventory> { Data = mapped, ErrorMessages = response.ErrorMessages };
        }
    }
}