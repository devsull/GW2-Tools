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

    using Birthdays;

    using Gw2Api.Core.EndPoints.CharacterInformation;

    using InventorySummary;

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

            // commands
            ShortStack.Container.Register<BaseCommand<GetBirthdaysRequest, List<CharacterInformation>>, GetBirthdaysCommand>();
            
            ShortStack.Container.Register<IInventorySummary, InventorySummary.InventorySummary>();
        }
    }
}
