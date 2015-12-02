using System.Collections.Generic;

namespace Gw2Api.Core.GW2ApiRawObjects
{
    /// <summary>
    /// The raw inventory object received from the GW2 API.
    /// </summary>
    public class Inventory
    {
        public List<InventoryBag> Bags { get; set; }
    }
}
