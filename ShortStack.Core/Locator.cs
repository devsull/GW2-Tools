namespace ShortStack.Core
{
    public static class Locator
    {
        public static T GetInstance<T>() where T : class
        {
            return ShortStack.Container.GetInstance<T>();
        }
    }
}
namespace ShortStack.Core
{
}