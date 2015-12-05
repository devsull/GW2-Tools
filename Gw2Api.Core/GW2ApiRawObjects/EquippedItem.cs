// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EquippedItem.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The equipped item, documentation from http://wiki.guildwars2.com/wiki/API:2/characters
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.GW2ApiRawObjects
{
    using System.Collections.Generic;

    /// <summary>
    /// The equipped item.
    /// </summary>
    public class EquippedItem
    {
        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the slot, possible values:
        ///     HelmAquatic
        ///     Backpack
        ///     Coat
        ///     Boots
        ///     Gloves
        ///     Helm
        ///     Leggings
        ///     Shoulders
        ///     Accessory1
        ///     Accessory2
        ///     Ring1
        ///     Ring2
        ///     Amulet
        ///     WeaponAquaticA
        ///     WeaponAquaticB
        ///     WeaponA1 - primary main hand
        ///     WeaponA2 - primary off hand
        ///     WeaponB1 - secondary main hand
        ///     WeaponB2 - secondary off hand
        ///     Sickle
        ///     Axe
        ///     Pick
        /// </summary>
        public string Slot { get; set; }

        /// <summary>
        /// Gets or sets the id of the skin of the item.
        /// </summary>
        public string Skin { get; set; }

        /// <summary>
        /// Gets or sets the list of upgrade item IDs (optional)
        /// </summary>
        public List<string> Upgrades { get; set; }

        /// <summary>
        /// Gets or sets the list of infusion item IDs (optional)
        /// </summary>
        public List<string> Infusions { get; set; }
    }
}
