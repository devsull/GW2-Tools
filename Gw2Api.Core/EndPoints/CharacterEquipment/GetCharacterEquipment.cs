// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCharacterEquipment.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Gets a character equiped items.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints.CharacterEquipment
{
    using System.Collections.Generic;

    using Gw2Api.Core.LookUpValues.EndPointDefinitions;

    using GW2ApiRawObjects;

    using RestSharp;

    /// <summary>
    /// Gets a character equipped items.
    /// </summary>
    public class GetCharacterEquipment : BaseGw2ApiEndPoint<CharacterEquipment>, IGw2ApiAuthEndPoint<CharacterEquipment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharacterEquipment"/> class.
        /// </summary>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <param name="restClient">
        /// The rest client.
        /// </param>
        public GetCharacterEquipment(Settings settings, RestClient restClient)
            : base(settings, restClient)
        {
            this.ApiEndPoint = Gw2EndPoints.Characters;
        }

        /// <summary>
        /// The handle request.
        /// </summary>
        /// <param name="apiKey">
        ///     The guild wars 2 api key.
        /// </param>
        /// <param name="name">
        ///     The name of the character.
        /// </param>
        /// <returns>
        /// The <see cref="CharacterEquipment"/>.
        /// </returns>
        public Gw2ApiResponse<CharacterEquipment> HandleRequest(string apiKey, string name = null)
        {
            // add name to the resource list
            // also add "equipment" to the list because we want the equipped items of the character!
            this.ApiResources = new List<string> { name, Gw2EndPointResources.Equipment };

            var response = this.Execute(apiKey);
            
            return response;
        }
    }
}
