// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerRegistration.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Configures the IoC container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core
{
    using System.Collections.Generic;

    using EndPoints;
    using EndPoints.AccountBank;
    using EndPoints.AccountCharacterNames;
    using EndPoints.CharacterInformation;
    using EndPoints.CharacterInventory;
    using EndPoints.Items;

    using Gw2Api.Core.Contracts;
    using Gw2Api.Core.EndPoints.AccountBankMaterials;
    using Gw2Api.Core.EndPoints.CharacterEquipment;
    using Gw2Api.Core.GW2ApiRawObjects;

    using RestSharp;

    using ShortStack.Core;
    using ShortStack.Core.Configuration;

    /// <summary>
    /// Configures the IoC container.
    /// </summary>
    public class ContainerRegistration : IConfigurationLoader
    {
        /// <summary>
        /// Configures the IoC container.
        /// </summary>
        public void Configure()
        {
            ShortStack.Container.RegisterSingleton<Settings>(() => new Settings());
            ShortStack.Container.RegisterSingleton<RestClient>(() => new RestClient());
            ShortStack.Container.Register<IGetAccountBank, GetAccountBank>();

            // auth end points
            ShortStack.Container.Register<IGw2ApiAuthEndPoint<AccountBankMaterials>, GetAccountBankMaterials>();
            ShortStack.Container.Register<IGw2ApiAuthEndPoint<AccountCharacterNames>, GetAccountCharacterNames>();
            ShortStack.Container.Register<IGw2ApiAuthEndPoint<CharacterEquipment>, GetCharacterEquipment>();
            ShortStack.Container.Register<IGw2ApiAuthEndPoint<CharacterInformation>, GetCharacterInformation>();
            ShortStack.Container.Register<IGw2ApiAuthEndPoint<CharacterInventory>, GetCharacterInventory>();

            // open end points
            ShortStack.Container.Register<IGw2ApiEndPoint<List<ItemDescription>>, GetItemDescriptions>();
        }
    }
}
