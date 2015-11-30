// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDescription.cs" company="Devin Sullivan">
//   DMS
// </copyright>
// <summary>
//   The item description.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints.Items
{
    /// <summary>
    /// The item description.
    /// </summary>
    public class ItemDescription
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the rarity.
        /// </summary>
        public string Rarity { get; set; }

        /// <summary>
        /// Gets or sets the icon url.
        /// </summary>
        public string IconUrl { get; set; }
    }
}