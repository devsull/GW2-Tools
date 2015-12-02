namespace Gw2Api.Core
{
    using System.Collections.Generic;

    using EndPoints;
    using EndPoints.AccountBank;
    using EndPoints.AccountCharacterNames;
    using EndPoints.CharacterInformation;
    using EndPoints.CharacterInventory;
    using EndPoints.Items;

    using Gw2Api.Core.EndPoints.AccountBankMaterials;

    using RestSharp;

    using ShortStack.Core;
    using ShortStack.Core.Configuration;

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
            ShortStack.Container.Register<IGw2ApiAuthEndPoint<AccountBankMaterials>, GetAccountBankMaterials>();

            ShortStack.Container.Register<IGw2ApiEndPoint<List<ItemDescription>>, GetItemDescriptions>();
        }
    }
}
