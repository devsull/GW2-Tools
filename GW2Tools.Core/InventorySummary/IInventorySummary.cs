namespace GW2Tools.Core.InventorySummary
{
    using System.Collections.Generic;

    using GW2Tools.Core.Objects;

    public interface IInventorySummary
    {
        List<ItemSummary> SummarizeInventory(string apiKey);
    }
}