// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Item.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The raw item object received from the GW2 API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.GW2ApiRawObjects
{
    /// <summary>
    /// The raw item object received from the GW2 API.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        public string Rarity { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        public string Icon { get; set; }
    }
}
