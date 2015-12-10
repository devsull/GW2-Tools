// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGetAccountBank.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Defines the IGetAccountBank type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.Contracts
{
    using System.Collections.Generic;

    using EndPoints;
    using GW2ApiRawObjects;

    public interface IGetAccountBank : IGw2ApiAuthEndPoint<List<InventoryItem>>
    {
         
    }
}