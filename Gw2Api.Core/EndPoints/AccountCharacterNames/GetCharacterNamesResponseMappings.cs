using System.Collections.Generic;
using System.Reflection;
using Nelibur.ObjectMapper;
using ShortStack.Core;

namespace Gw2Api.Core
{
    public class GetCharacterNamesResponseMapping : IConfigurationLoader
    {
        public void Configure()
        {
            // TODO: figure out how to do this....
            //TinyMapper.Bind<List<string>, AccountCharacterNames>(config =>
            //{
            //    config.Bind();
            //    // config.Bind(source=> source, target=>target.Names);
            //});
        }
    }
}