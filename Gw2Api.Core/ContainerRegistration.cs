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
            ShortStack.Container.Register<GetAccountCharacterNames>();
        }
    }
}
