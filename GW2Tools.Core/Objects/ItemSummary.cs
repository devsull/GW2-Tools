namespace GW2Tools.Core.Objects
{
    using System.Collections.Generic;

    /// <summary>
    /// The item summary.
    /// </summary>
    public class ItemSummary
    {
        public string Id { get; set; }

        public string Rarity { get; set; }

        public int Quantity
        {
            get
            {
                var count = 0;
                foreach (var itemInformation in this.LocationList)
                {
                    count += itemInformation.Quantity;
                }
                return count;
            }
        }

        public string Name { get; set; }

        public string IconUrl { get; set; }

        public List<ItemInformation> LocationList { get; set; }
    }
}