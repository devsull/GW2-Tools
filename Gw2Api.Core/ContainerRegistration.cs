namespace Gw2Api.Core
{
    using RestSharp;

    using ShortStack.Core;

    public class ContainerRegistration : IRegisterContainerObjects
    {
        public void Register()
        {
            ShortStack.Container.RegisterSingleton<Settings>(() => new Settings());
            ShortStack.Container.RegisterSingleton<RestClient>(() => new RestClient());
            ShortStack.Container.Register<GetAccountCharacterNames>();
        }
    }
}
