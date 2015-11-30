﻿
namespace GW2Tools.Core
{
    using Birthdays;
    using InventorySummary;

    using ShortStack.Core;

    /// <summary>
    /// The container registration.
    /// </summary>
    public class ContainerRegistration : IConfigurationLoader
    {
        public void Configure()
        {
            ShortStack.Container.Register<ICharacterBirthdays, CharacterBirthdays>();
            ShortStack.Container.Register<IInventorySummary, InventorySummary.InventorySummary>();
        }
    }
}
