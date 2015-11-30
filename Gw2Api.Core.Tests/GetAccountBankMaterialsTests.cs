
using ShortStack.Core.Testing;

namespace Gw2Api.Core.Tests
{
    using EndPoints;
    using EndPoints.AccountBank;
    using Newtonsoft.Json;
    using Xunit.Abstractions;

    using Xunit;

    /// <summary>
    /// The get account bank materials tests.
    /// </summary>
    public class GetAccountBankMaterialsTests : BaseIntegrationTest<IGw2ApiAuthEndPoint<AccountBankMaterials>>
    {
        private readonly ITestOutputHelper output;
        
        private readonly string testKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

        public GetAccountBankMaterialsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GetAccountBankMaterialsWorks()
        {
            var info = this.SystemUnderTest.HandleRequest(this.testKey);

            // since im testing my material bank, I know I dont only have one item in it....
            Assert.True(info.Materials.Count > 1, "I dont believe that you only have 1 in your materials!");

            var json = JsonConvert.SerializeObject(info);

            this.output.WriteLine("Bank Json: {0}", json);
        }
    }
}
