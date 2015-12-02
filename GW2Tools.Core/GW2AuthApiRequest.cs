// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GW2AuthApiRequest.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The Guild Wars 2 authentication API request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Core
{
    using ShortStack.Core.Commands;

    /// <summary>
    /// The Guild Wars 2 authentication API request.
    /// </summary>
    public class GW2AuthApiRequest : Request
    {
        /// <summary>
        /// Gets or sets the guild wars 2 API key.
        /// </summary>
        public string GuildWars2ApiKey { get; set; }
    }
}