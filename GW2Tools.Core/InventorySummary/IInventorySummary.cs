// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInventorySummary.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The InventorySummary interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Core.InventorySummary
{
    using System.Collections.Generic;

    using Objects;

    /// <summary>
    /// The InventorySummary interface.
    /// </summary>
    public interface IInventorySummary
    {
        /// <summary>
        /// Summarizes an account's inventory by aggregating all items queried into an itemized list
        /// with location information.
        /// </summary>
        /// <param name="apiKey">
        /// The guild wars 2 API key.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        List<ItemSummary> SummarizeInventory(string apiKey);
    }
}