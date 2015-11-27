
namespace Gw2Api.Core.EndPoints.CharacterInventory
{
    using GW2ApiRawObjects;
    using Nelibur.ObjectMapper;
    using ShortStack.Core;

    public class CharacterInventoryMappings : IConfigurationLoader
    {
        public void Configure()
        {
            TinyMapper.Bind<Inventory, CharacterInventory>();
        }
    }
}