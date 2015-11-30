namespace GW2Tools.Core.Tests
{
    using GW2Tools.Core.Birthdays;
    using GW2Tools.Core.InventorySummary;

    using Newtonsoft.Json;

    using ShortStack.Core;

    using Xunit;
    using Xunit.Abstractions;

    public class InventorySummaryTests
    {
        public IInventorySummary SystemUnderTest { get; }

        private readonly ITestOutputHelper output;
        private readonly string testKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

        public InventorySummaryTests(ITestOutputHelper output)
        {
            ShortStack.BootStack(false);
            ContainerRegistration.Configure();
            var mappingConfig = new Gw2Api.Core.ObjectMappings();
            mappingConfig.Configure();
            var thisMappingConfig = new ObjectMappings();
            thisMappingConfig.Configure();
            this.SystemUnderTest = Locator.GetInstance<IInventorySummary>();
            this.output = output;
        }

        [Fact]
        public void InventorySummaryWorks()
        {
            var inventorySummary = this.SystemUnderTest.SummarizeInventory(testKey);

            //foreach (var character in characters)
            //{
            //    Assert.NotNull(character.Birthday);
            //    Assert.NotNull(character.Name);
            //    Assert.NotNull(character.Race);
            //    Assert.NotNull(character.Profession);
            //}

            var json = JsonConvert.SerializeObject(inventorySummary);

            this.output.WriteLine("Json: {0}", json);
        }
    }
}
