
namespace GW2Tools.Core
{
    using ShortStack.Core;

    public class ContainerRegistration : IConfigurationLoader
    {
        public void Configure()
        {
            ShortStack.Container.Register<ICharacterBirthdays, CharacterBirthdays>();
        }
    }
}
