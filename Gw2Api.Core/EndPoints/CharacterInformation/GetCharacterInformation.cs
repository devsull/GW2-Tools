// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCharacterInformation.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Get the character information for a Guild Wars 2 character.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints.CharacterInformation
{
    using System.Collections.Generic;
    using ApiEndPointDefinitions;
    using GW2ApiRawObjects;
    using RestSharp;
    using ShortStack.Core;

    /// <summary>
    /// Get the character information for a Guild Wars 2 character.
    /// </summary>
    public class GetCharacterInformation : BaseGw2ApiEndPoint<Character>, IGw2ApiAuthEndPoint<CharacterInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharacterInformation"/> class.
        /// </summary>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <param name="restClient">
        /// The rest client.
        /// </param>
        public GetCharacterInformation(Settings settings, RestClient restClient)
            : base(settings, restClient)
        {
            this.ApiEndPoint = Gw2EndPoints.Characters;
        }

        /// <summary>
        /// The handle request.
        /// </summary>
        /// <param name="apiKey">
        /// The guild wars 2 API key.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="CharacterInformation"/>.
        /// </returns>
        public CharacterInformation HandleRequest(string apiKey, string name = null)
        {
            // add name to the resource list
            this.ApiResources = new List<string> {name };

            var data = this.Execute(apiKey);

            var mapped = Mapper.Map<Character, CharacterInformation>(data);

            return mapped;
        }
    }
}