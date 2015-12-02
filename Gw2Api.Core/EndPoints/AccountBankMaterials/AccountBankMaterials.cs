// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountBankMaterials.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The account bank materials.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints.AccountBankMaterials
{
    using System.Collections.Generic;

    using GW2ApiRawObjects;

    /// <summary>
    /// The account bank materials.
    /// </summary>
    public class AccountBankMaterials
    {
        /// <summary>
        /// Gets or sets the materials.
        /// </summary>
        public List<MaterialBankItem> Materials { get; set; }
    }
}