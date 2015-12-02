// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectMappings.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Defines the ObjectMappings type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core
{
    using EndPoints.CharacterInformation;
    using EndPoints.CharacterInventory;

    using Gw2Api.Core.EndPoints.Items;

    using GW2ApiRawObjects;

    using Nelibur.ObjectMapper;

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
            // character information mappings
            TinyMapper.Bind<Character, CharacterInformation>(config =>
            {
                config.Bind(source => source.Created, target => target.Birthday);
            });

            // character inventory mappings
            TinyMapper.Bind<Inventory, CharacterInventory>();

            // ItemDescription mappings
            TinyMapper.Bind<Item, ItemDescription>(config =>
            {
                config.Bind(source => source.Icon, target => target.IconUrl);
            });
        }
    }
}
