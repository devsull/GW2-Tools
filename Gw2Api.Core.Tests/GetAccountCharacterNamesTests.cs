namespace Gw2Api.Core.Tests
{
    using System.ComponentModel;

    using ShortStack.Core;

    using Xunit;

    public class GetAccountCharacterNamesTests
    {
        private GetAccountCharacterNames SystemUnderTest;

        private readonly string testKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

        public GetAccountCharacterNamesTests()
        {
            ShortStack.BootStack();
            this.SystemUnderTest = DependencyResolver.GetInstance<GetAccountCharacterNames>();
        }

        [Fact]
        public void GetAccountCharacterNamesWorks()
        {
            var expectedNameCount = 12;

            var actualNames = this.SystemUnderTest.Execute(this.testKey);

            Assert.Equal(expectedNameCount, actualNames.Count);
        }
    }
}
