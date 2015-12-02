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
    using Gw2Api.Core.EndPoints.AccountBankMaterials;
    using Gw2Api.Core.EndPoints.AccountCharacterNames;
    using Gw2Api.Core.EndPoints.CharacterInventory;
    using Gw2Api.Core.EndPoints.Items;
    using Gw2Api.Core.GW2ApiRawObjects;

    using Objects;

    using ShortStack.Core;

    /// <summary>
    /// The inventory summary.
    /// TODO: convert to command structure
    /// </summary>
    public class InventorySummary : IInventorySummary
    {
        /// <summary>
        /// The get account character names end point.
        /// </summary>
        private readonly IGw2ApiAuthEndPoint<AccountCharacterNames> getAccountCharacterNamesEndPoint;

        /// <summary>
        /// The get character inventory end point.
        /// </summary>
        private readonly IGw2ApiAuthEndPoint<CharacterInventory> getCharacterInventoryEndPoint;

        /// <summary>
        /// The get account bank end point.
        /// </summary>
        private readonly IGw2ApiAuthEndPoint<AccountBank> getAccountBankEndPoint;

        /// <summary>
        /// The get item descriptions end point.
        /// </summary>
        private readonly IGw2ApiEndPoint<List<ItemDescription>> getItemDescriptionsEndPoint;

        /// <summary>
        /// The get account materials.
        /// </summary>
        private readonly IGw2ApiAuthEndPoint<AccountBankMaterials> getAccountMaterials;

        /// <summary>
        /// The item dictionary.
        /// </summary>
        private readonly Dictionary<string, List<ItemInformation>> itemDictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventorySummary"/> class.
        /// </summary>
        /// <param name="getAccountCharacterNamesEndPoint">
        /// The get account character names end point.
        /// </param>
        /// <param name="getCharacterInventoryEndPoint">
        /// The get character inventory end point.
        /// </param>
        /// <param name="getAccountBankEndPoint">
        /// The get account bank end point.
        /// </param>
        /// <param name="getItemDescriptionsEndPoint">
        /// The get item descriptions end point.
        /// </param>
        /// <param name="getAccountMaterials">
        /// The get account materials.
        /// </param>
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

        /// <summary>
        /// Summarizes an account's inventory by aggregating all items queried into an itemized list
        /// with location information.
        /// </summary>
        /// <param name="apiKey">
        /// The guild wars 2 API key.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
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

        /// <summary>
        /// Puts a material in item dictionary.
        /// </summary>
        /// <param name="material">
        /// The material.
        /// </param>
        private void PutMaterialInItemDictionary(MaterialBankItem material)
        {
            var key = material.Id;

            var mappedItem = Mapper.Map<MaterialBankItem, ItemInformation>(material);

            this.PutItemIntoDictionary(key, mappedItem, LocationType.MaterialBank);
        }

        /// <summary>
        /// Puts an inventory item in item dictionary.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="locType">
        /// The loc type.
        /// </param>
        /// <param name="locDescription">
        /// The loc description.
        /// </param>
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

        /// <summary>
        /// Puts item information into the item dictionary.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="locType">
        /// The loc type.
        /// </param>
        /// <param name="locDescription">
        /// The loc description.
        /// </param>
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

        /// <summary>
        /// Get all item ids from the item dictionary.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        private List<string> GetItemIdsFromItemDictionary()
        {
            return this.itemDictionary.Keys.ToList();
        }
    }
}