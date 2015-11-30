﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InventoryItem.cs" company="Devin Sullivan">
//   DMS
// </copyright>
// <summary>
//   The inventory item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.GW2ApiRawObjects
{
    /// <summary>
    /// The inventory item.
    /// </summary>
    public class InventoryItem
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the binding.
        /// </summary>
        public string Binding { get; set; }

        /// <summary>
        /// Gets or sets the bound_ to.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public string Bound_To { get; set; }
    }
}