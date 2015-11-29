
using ShortStack.Core.Testing;

namespace Gw2Api.Core.Tests
{
    using EndPoints;
    using EndPoints.AccountBank;
    using Newtonsoft.Json;
    using Xunit.Abstractions;

    using Xunit;

    public class GetAccountBankTests : BaseIntegrationTest<IGw2ApiAuthEndPoint<AccountBank>>
    {
        private readonly ITestOutputHelper output;
        
        private readonly string testKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

        public GetAccountBankTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GetAccountCharacterNamesWorks()
        {
            var info = this.SystemUnderTest.HandleRequest(this.testKey);

            // since im testing my bank, I know I dont only have one item in it....
            Assert.True(info.Items.Count > 1, "I dont believe that you only have 1 item in your bank!");

            var json = JsonConvert.SerializeObject(info);

            this.output.WriteLine("Bank Json: {0}", json);
        }
    }
}
