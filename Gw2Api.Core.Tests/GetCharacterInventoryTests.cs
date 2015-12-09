
using Gw2Api.Core.EndPoints;
using ShortStack.Core.Testing;

namespace Gw2Api.Core.Tests
{
    using EndPoints.CharacterInventory;
    using Newtonsoft.Json;
    using Xunit.Abstractions;
    using ShortStack.Core;
    using Xunit;

    public class GetCharacterInventoryTests : BaseIntegrationTest<IGw2ApiAuthEndPoint<CharacterInventory>>
    {
        private readonly ITestOutputHelper output;

        private readonly string testKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

        private readonly string characterName = "Synaw";

        public GetCharacterInventoryTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GetCharacterInventoryWorks()
        {
            var info = this.SystemUnderTest.HandleRequest(this.testKey, this.characterName);
            
            Assert.True(info.Data.Bags.Count > 1, $"I dont believe that you only have 1 bag on {this.characterName}!");
            
            var json = JsonConvert.SerializeObject(info);

            this.output.WriteLine("Inventory Json: {0}", json);
        }
    }
}