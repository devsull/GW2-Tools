// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAccountInventoryRequest.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The get inventory summary request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Core.AccountInventory
{
    using ShortStack.Core.Commands;

    /// <summary>
    /// The get inventory summary request.
    /// </summary>
    public class GetAccountInventoryRequest : Request
    {
        /// <summary>
        /// Gets or sets the guild wars 2 API key.
        /// </summary>
        public string GuildWars2ApiKey { get; set; }
    }
}