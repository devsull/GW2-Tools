// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountBank.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The account bank.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints.AccountBank
{
    using System.Collections.Generic;

    using GW2ApiRawObjects;

    /// <summary>
    /// The account bank.
    /// </summary>
    public class AccountBank
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public List<InventoryItem> Items { get; set; }
    }
}