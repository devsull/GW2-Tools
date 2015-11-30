// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectMappings.cs" company="Devin Sullivan">
//   Copy write
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
            TinyMapper.Bind<InventoryItem, ItemInformation>(config =>
            {
                config.Bind(source => source.Bound_To, target => target.BoundTo);
                config.Bind(source => source.Count, target => target.Quantity);
            });
            TinyMapper.Bind<MaterialBankItem, ItemInformation>(config =>
            {
                config.Bind(source => source.Count, target => target.Quantity);
            });

            //// character inventory mappings
            TinyMapper.Bind<ItemDescription, ItemSummary>();
        }
    }
}
