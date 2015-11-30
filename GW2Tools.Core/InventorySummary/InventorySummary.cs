// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InventorySummary.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The inventory summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Core.InventorySummary
{
    using System.Collections.Generic;
    using System.Linq;

    using Gw2Api.Core.EndPoints;
    using Gw2Api.Core.EndPoints.AccountBank;
    using Gw2Api.Core.EndPoints.AccountCharacterNames;
    using Gw2Api.Core.EndPoints.CharacterInformation;
    using Gw2Api.Core.EndPoints.CharacterInventory;
    using Gw2Api.Core.EndPoints.Items;
    using Gw2Api.Core.GW2ApiRawObjects;

    using GW2Tools.Core.Objects;

    using ShortStack.Core;

    /// <summary>
    /// The inventory summary.
    /// </summary>
    public class InventorySummary : IInventorySummary
    {
        private readonly IGw2ApiAuthEndPoint<AccountCharacterNames> getAccountCharacterNamesEndPoint;

        private readonly IGw2ApiAuthEndPoint<CharacterInventory> getCharacterInventoryEndPoint;

        private readonly IGw2ApiAuthEndPoint<AccountBank> getAccountBankEndPoint;

        private readonly IGw2ApiEndPoint<List<ItemDescription>> getItemDescriptionsEndPoint;

        private readonly IGw2ApiAuthEndPoint<AccountBankMaterials> getAccountMaterials;

        private Dictionary<string, List<ItemInformation>> itemDictionary;

        public InventorySummary(
            IGw2ApiAuthEndPoint<AccountCharacterNames> getAccountCharacterNamesEndPoint,
            IGw2ApiAuthEndPoint<CharacterInventory> getCharacterInventoryEndPoint,
            IGw2ApiAuthEndPoint<AccountBank> getAccountBankEndPoint,
            IGw2ApiEndPoint<List<ItemDescription>> getItemDescriptionsEndPoint,
            IGw2ApiAuthEndPoint<AccountBankMaterials> getAccountMaterials)
        {
            this.getAccountCharacterNamesEndPoint = getAccountCharacterNamesEndPoint;
            this.getCharacterInventoryEndPoint = getCharacterInventoryEndPoint;
            this.getAccountBankEndPoint = getAccountBankEndPoint;
            this.getItemDescriptionsEndPoint = getItemDescriptionsEndPoint;
            this.getAccountMaterials = getAccountMaterials;
            this.itemDictionary = new Dictionary<string, List<ItemInformation>>();
        }

        public List<ItemSummary> SummarizeInventory(string apiKey)
        {
            var materialBank = this.getAccountMaterials.HandleRequest(apiKey);

            foreach (var material in materialBank.Materials)
            {
                this.PutMaterialInItemDictionary(material);
            }

            var bank = this.getAccountBankEndPoint.HandleRequest(apiKey);

            // insert bank into dictionary
            foreach (var inventoryItem in bank.Items)
            {
                this.PutInventoryItemInItemDictionary(inventoryItem, LocationType.Bank);
            }


            // insert character inventories into dictionary
            var characters = this.getAccountCharacterNamesEndPoint.HandleRequest(apiKey);
            
            foreach (var characterName in characters.Names)
            {
                var inventory = this.getCharacterInventoryEndPoint.HandleRequest(apiKey, characterName);
                var flatListOfItemsFromBags = inventory.Bags.Where(b => b != null).SelectMany(b => b.Inventory);

                foreach (var inventoryItem in flatListOfItemsFromBags)
                {
                    this.PutInventoryItemInItemDictionary(inventoryItem, LocationType.CharacterInventory, characterName);
                }
            }

            // once the dictionary is filled out
            // get name and rarity information

            var itemIds = this.GetItemIdsFromItemDictionary();

            var itemDescriptions = this.getItemDescriptionsEndPoint.HandleRequest(itemIds);

            var itemSummaries = Mapper.Map<List<ItemDescription>, List<ItemSummary>>(itemDescriptions);

            // put locations into summary
            foreach (var itemSummary in itemSummaries)
            {
                itemSummary.LocationList = this.itemDictionary[itemSummary.Id];
            }

            return itemSummaries;
        }

        private void PutItemIntoDictionary(string key, ItemInformation item, string locType, string locDescription = null)
        {
            item.LocationType = locType;
            item.LocationDescription = locDescription;

            if (this.itemDictionary.ContainsKey(key))
            {
                this.itemDictionary[key].Add(item);
            }
            else
            {
                this.itemDictionary.Add(key, new List<ItemInformation> { item });
            }
        }

        private void PutMaterialInItemDictionary(MaterialBankItem material)
        {
            var key = material.Id;

            var mappedItem = Mapper.Map<MaterialBankItem, ItemInformation>(material);

            this.PutItemIntoDictionary(key, mappedItem, LocationType.MaterialBank);
        }

        private void PutInventoryItemInItemDictionary(InventoryItem item, string locType, string locDescription = null)
        {
            if (item == null)
            {
                return;
            }

            var key = item.Id;

            var mappedItem = Mapper.Map<InventoryItem, ItemInformation>(item);

            this.PutItemIntoDictionary(key, mappedItem, locType, locDescription);
        }

        private List<string> GetItemIdsFromItemDictionary()
        {
            return this.itemDictionary.Keys.ToList();
        }
    }
}