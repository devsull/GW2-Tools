// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterInventory.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The character inventory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints.CharacterInventory
{
    using System.Collections.Generic;
    using GW2ApiRawObjects;

    /// <summary>
    /// The character inventory.
    /// </summary>
    public class CharacterInventory
    {
        /// <summary>
        /// Gets or sets the bags.
        /// </summary>
        public List<InventoryBag> Bags { get; set; }
    }
}
