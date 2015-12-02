
namespace GW2Tools.Core
{
    using System.Collections.Generic;

    using Birthdays;

    using Gw2Api.Core.EndPoints.CharacterInformation;

    using GW2Tools.Core.Validators;

    using InventorySummary;

    using ShortStack.Core;
    using ShortStack.Core.Commands;
    using ShortStack.Core.Validation;

    /// <summary>
    /// The container registration.
    /// </summary>
    public class ContainerRegistration : IConfigurationLoader
    {
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
