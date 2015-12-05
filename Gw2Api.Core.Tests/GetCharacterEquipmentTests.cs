using Gw2Api.Core.EndPoints;
using ShortStack.Core.Testing;

namespace Gw2Api.Core.Tests
{
    using GW2ApiRawObjects;

    using Newtonsoft.Json;
    using Xunit.Abstractions;
    using Xunit;

    public class GetCharacterEquipmentTests : BaseIntegrationTest<IGw2ApiAuthEndPoint<CharacterEquipment>>
    {
        private readonly ITestOutputHelper output;

        private readonly string testKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

        private readonly string characterName = "Synaw";

        public GetCharacterEquipmentTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GetCharacterEquipmentWorks()
        {
            var characterEquipment = this.SystemUnderTest.HandleRequest(this.testKey, this.characterName);
            
            Assert.NotNull(characterEquipment);
            Assert.NotEmpty(characterEquipment.Equipment);
            Assert.True(characterEquipment.Equipment.Count > 1, $"I dont believe that you have one equipped item on {this.characterName}!");
            
            var json = JsonConvert.SerializeObject(characterEquipment);

            this.output.WriteLine("Equipment Json: {0}", json);
        }
    }
}