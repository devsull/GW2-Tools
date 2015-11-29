using Gw2Api.Core.EndPoints;
using Gw2Api.Core.EndPoints.AccountCharacterNames;
using ShortStack.Core.Testing;

namespace Gw2Api.Core.Tests
{
    using ShortStack.Core;

    using Xunit;

    public class GetAccountCharacterNamesTests : BaseIntegrationTest<IGw2ApiAuthEndPoint<AccountCharacterNames>>
    {
        private readonly string testKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";
        
        [Fact]
        public void GetAccountCharacterNamesWorks()
        {
            var expectedNameCount = 12;

            var actual = this.SystemUnderTest.HandleRequest(this.testKey);

            Assert.Equal(expectedNameCount, actual.Names.Count);
        }
    }
}
