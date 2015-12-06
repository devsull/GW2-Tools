// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAccountInventory.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The inventory summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Core.AccountInventory
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
    using ShortStack.Core.Commands;
    using ShortStack.Core.Validation;

    /// <summary>
    /// The inventory summary.
    /// </summary>
    public class GetAccountInventory : BaseCommand<GetAccountInventoryRequest, List<ItemSummary>>
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
        /// The get itemLocation descriptions end point.
        /// </summary>
        private readonly IGw2ApiEndPoint<List<ItemDescription>> getItemDescriptionsEndPoint;

        /// <summary>
        /// The get account materials.
        /// </summary>
        private readonly IGw2ApiAuthEndPoint<AccountBankMaterials> getAccountMaterialsEndPoint;

        /// <summary>
        /// The get equipped items end point.
        /// </summary>
        private readonly IGw2ApiAuthEndPoint<CharacterEquipment> getEquippedItemsEndPoint;

        /// <summary>
        /// The itemLocation dictionary.
        /// </summary>
        private readonly Dictionary<string, List<ItemLocationInformation>> itemDictionary = new Dictionary<string, List<ItemLocationInformation>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAccountInventory"/> class.
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
        /// The get itemLocation descriptions end point.
        /// </param>
        /// <param name="getAccountMaterialsEndPoint">
        /// The get account materials.
        /// </param>
        public GetAccountInventory(
            IValidateObjects<GetAccountInventoryRequest> validator,
            IGw2ApiAuthEndPoint<AccountCharacterNames> getAccountCharacterNamesEndPoint,
            IGw2ApiAuthEndPoint<CharacterInventory> getCharacterInventoryEndPoint,
            IGw2ApiAuthEndPoint<AccountBank> getAccountBankEndPoint,
            IGw2ApiEndPoint<List<ItemDescription>> getItemDescriptionsEndPoint,
            IGw2ApiAuthEndPoint<AccountBankMaterials> getAccountMaterialsEndPoint,
            IGw2ApiAuthEndPoint<CharacterEquipment> getEquippedItemsEndPoint)
            : base(validator)
        {
            this.getAccountCharacterNamesEndPoint = getAccountCharacterNamesEndPoint;
            this.getCharacterInventoryEndPoint = getCharacterInventoryEndPoint;
            this.getAccountBankEndPoint = getAccountBankEndPoint;
            this.getItemDescriptionsEndPoint = getItemDescriptionsEndPoint;
            this.getAccountMaterialsEndPoint = getAccountMaterialsEndPoint;
            this.getEquippedItemsEndPoint = getEquippedItemsEndPoint;
        }


        protected override List<ItemSummary> HandleRequest()
        {
            return this.SummarizeInventory(this.Request.GuildWars2ApiKey);
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
        private List<ItemSummary> SummarizeInventory(string apiKey)
        {
            var materialBank = this.getAccountMaterialsEndPoint.HandleRequest(apiKey);

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
                
                var flatListOfItemsFromBags = inventory.Bags.Where(b => b != null).SelectMany(b => b.Inventory).ToList();

                foreach (var inventoryItem in flatListOfItemsFromBags)
                {
                    this.PutInventoryItemInItemDictionary(inventoryItem, LocationType.CharacterInventory, characterName);
                }

                var characterEquipment = this.getEquippedItemsEndPoint.HandleRequest(apiKey, characterName);

                foreach (var equippedItem in characterEquipment.Equipment)
                {
                    this.PutInventoryEquipmentInItemDictionary(equippedItem, characterName);
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

        private void PutInventoryEquipmentInItemDictionary(EquippedItem equippedItem, string characterName)
        {
            var key = equippedItem.Id.ToString();
            // TODO: figure out how get binding??
            var inventoryItem = new ItemLocationInformation { Quantity = 1 };

            var locationDescription = $"{characterName}, slot: {equippedItem.Slot}";

            this.PutItemIntoDictionary(key, inventoryItem, LocationType.Equipped, locationDescription);
        }

        /// <summary>
        /// Puts a material in itemLocation dictionary.
        /// </summary>
        /// <param name="material">
        /// The material.
        /// </param>
        private void PutMaterialInItemDictionary(MaterialBankItem material)
        {
            var key = material.Id;

            var mappedItem = Mapper.Map<MaterialBankItem, ItemLocationInformation>(material);

            this.PutItemIntoDictionary(key, mappedItem, LocationType.MaterialBank);
        }

        /// <summary>
        /// Puts an inventory itemLocation in itemLocation dictionary.
        /// </summary>
        /// <param name="item">
        /// The itemLocation.
        /// </param>
        /// <param name="locType">
        /// The location type.
        /// </param>
        /// <param name="locDescription">
        /// The location description.
        /// </param>
        private void PutInventoryItemInItemDictionary(InventoryItem item, string locType, string locDescription = null)
        {
            if (item == null)
            {
                return;
            }

            var key = item.Id;

            var mappedItem = Mapper.Map<InventoryItem, ItemLocationInformation>(item);

            this.PutItemIntoDictionary(key, mappedItem, locType, locDescription);
        }

        /// <summary>
        /// Puts itemLocation information into the itemLocation dictionary.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="itemLocation">
        /// The itemLocation.
        /// </param>
        /// <param name="locType">
        /// The location type.
        /// </param>
        /// <param name="locDescription">
        /// The location description.
        /// </param>
        private void PutItemIntoDictionary(string key, ItemLocationInformation itemLocation, string locType, string locDescription = null)
        {
            itemLocation.LocationType = locType;
            itemLocation.LocationDescription = locDescription;

            if (this.itemDictionary.ContainsKey(key))
            {
                this.itemDictionary[key].Add(itemLocation);
            }
            else
            {
                this.itemDictionary.Add(key, new List<ItemLocationInformation> { itemLocation });
            }
        }

        /// <summary>
        /// Get all itemLocation ids from the itemLocation dictionary.
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