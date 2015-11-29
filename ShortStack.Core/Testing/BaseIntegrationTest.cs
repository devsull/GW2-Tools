namespace ShortStack.Core.Testing
{
    public abstract class BaseIntegrationTest<T> where T : class
    {
        public T SystemUnderTest { get; }

        protected BaseIntegrationTest()
        {
            ShortStack.BootStack();
            this.SystemUnderTest = Locator.GetInstance<T>();
        }
    }
}