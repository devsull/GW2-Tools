
namespace GW2Tools.Core
{
    using Birthdays;
    using InventorySummary;

    using ShortStack.Core;

    public static class ContainerRegistration
    {
        public static void Configure()
        {
            var registerApi = new Gw2Api.Core.ContainerRegistration();
            registerApi.Configure();
            ShortStack.Container.Register<ICharacterBirthdays, CharacterBirthdays>();
            ShortStack.Container.Register<IInventorySummary, InventorySummary.InventorySummary>();
        }
    }
}
