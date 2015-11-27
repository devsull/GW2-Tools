
namespace Gw2Api.Core.EndPoints.CharacterInformation
{
    using GW2ApiRawObjects;
    using Nelibur.ObjectMapper;
    using ShortStack.Core;

    public class CharacterInformationMappings : IConfigurationLoader
    {
        public void Configure()
        {
            TinyMapper.Bind<Character, CharacterInformation>(config =>
            {
                config.Bind(source => source.Created, target => target.Birthday);
            });
        }
    }
}