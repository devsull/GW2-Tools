namespace Gw2Api.Core.GW2ApiRawObjects
{
    using System.Collections.Generic;

    /// <summary>
    /// The raw inventory bag object received from the GW2 API.
    /// </summary>
    public class InventoryBag
    {
        public string Id { get; set; }
        public int Size { get; set; }
        public List<InventoryItem> Inventory { get; set; }
    }
}