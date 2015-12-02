// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaterialBankItem.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The raw material bank item received from the GW2 API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.GW2ApiRawObjects
{
    /// <summary>
    /// The raw material bank item received from the GW2 API.
    /// </summary>
    public class MaterialBankItem
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public int Category { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        public int Count { get; set; } 
    }
}