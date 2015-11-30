using System.Collections.Generic;
using Gw2Api.Core.EndPoints;
using Gw2Api.Core.EndPoints.AccountBank;
using Gw2Api.Core.EndPoints.AccountCharacterNames;
using Gw2Api.Core.EndPoints.CharacterInformation;
using Gw2Api.Core.EndPoints.CharacterInventory;
using Gw2Api.Core.GW2ApiRawObjects;

namespace Gw2Api.Core
{
    using RestSharp;

    using ShortStack.Core;

    public class ContainerRegistration : IConfigurationLoader
    {
        public void Configure()
        {
            ShortStack.Container.RegisterSingleton<Settings>(() => new Settings());
            ShortStack.Container.RegisterSingleton<RestClient>(() => new RestClient());
            ShortStack.Container.Register<IGw2ApiAuthEndPoint<AccountBank>, GetAccountBank>();
            ShortStack.Container.Register<IGw2ApiAuthEndPoint<AccountCharacterNames>, GetAccountCharacterNames>();
            ShortStack.Container.Register<IGw2ApiAuthEndPoint<CharacterInformation>, GetCharacterInformation>();
            ShortStack.Container.Register<IGw2ApiAuthEndPoint<CharacterInventory>, GetCharacterInventory>();
        }
    }
}
