// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectMappings.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Defines the ObjectMappings type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Core
{
    using Gw2Api.Core.EndPoints.Items;
    using Gw2Api.Core.GW2ApiRawObjects;

    using Nelibur.ObjectMapper;

    using Objects;

    using ShortStack.Core;
    using ShortStack.Core.Configuration;

    /// <summary>
    /// The object mappings.
    /// </summary>
    public class ObjectMappings : IConfigurationLoader
    {
        /// <summary>
        /// The configure.
        /// </summary>
        public void Configure()
        {
            // item information mappings
            TinyMapper.Bind<InventoryItem, ItemLocationInformation>(config =>
            {
                config.Bind(source => source.Bound_To, target => target.BoundTo);
                config.Bind(source => source.Count, target => target.Quantity);
            });
            TinyMapper.Bind<MaterialBankItem, ItemLocationInformation>(config =>
            {
                config.Bind(source => source.Count, target => target.Quantity);
            });
            //TinyMapper.Bind<EquippedItem, ItemLocationInformation>(config =>
            //{
            //    config.Bind(source => LocationType.CharacterInventory, target => target.Location);
                
            //});

            //// character inventory mappings
            TinyMapper.Bind<ItemDescription, ItemSummary>();
        }
    }
}
