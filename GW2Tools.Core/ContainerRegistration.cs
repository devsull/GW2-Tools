// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerRegistration.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The container registration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Core
{
    using System.Collections.Generic;

    using AccountInventory;

    using Birthdays;

    using Gw2Api.Core.EndPoints.CharacterInformation;

    using Objects;

    using ShortStack.Core;
    using ShortStack.Core.Commands;
    using ShortStack.Core.Configuration;
    using ShortStack.Core.Validation;

    using Validators;

    /// <summary>
    /// The container registration.
    /// </summary>
    public class ContainerRegistration : IConfigurationLoader
    {
        /// <summary>
        /// The configure.
        /// </summary>
        public void Configure()
        {
            // validators
            ShortStack.Container.Register<IValidateObjects<GetBirthdaysRequest>, GetBirthdaysRequestValidator>();
            ShortStack.Container.Register<IValidateObjects<GetAccountInventoryRequest>, GetAccountInventoryRequestValidator>();

            // commands
            ShortStack.Container.Register<BaseCommand<GetBirthdaysRequest, List<CharacterInformation>>, GetBirthdaysCommand>();
            ShortStack.Container.Register<BaseCommand<GetAccountInventoryRequest, List<ItemSummary>>, GetAccountInventory>();
        }
    }
}
