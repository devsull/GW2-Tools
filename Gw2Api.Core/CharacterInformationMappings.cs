using System;
using Gw2Api.Core.GW2ApiRawObjects;
using Nelibur.ObjectMapper;
using RestSharp;
using ShortStack.Core;

namespace Gw2Api.Core
{
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