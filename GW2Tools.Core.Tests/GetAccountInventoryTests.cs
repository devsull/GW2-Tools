namespace GW2Tools.Core.Tests
{
    using System.Collections.Generic;

    using GW2Tools.Core.AccountInventory;

    using Newtonsoft.Json;

    using Objects;

    using ShortStack.Core.Commands;
    using ShortStack.Core.Testing;

    using Xunit;
    using Xunit.Abstractions;

    public class GetAccountInventoryTests : BaseIntegrationTest<BaseCommand<GetAccountInventoryRequest, List<ItemSummary>>>
    {
        private readonly ITestOutputHelper output;
        private readonly string testKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

        public GetAccountInventoryTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GetAccountInventoryWorks()
        {
            var request = new GetAccountInventoryRequest { GuildWars2ApiKey = this.testKey };

            var inventorySummary = this.SystemUnderTest.Execute(request);

            var json = JsonConvert.SerializeObject(inventorySummary);

            this.output.WriteLine("Json: {0}", json);
        }
    }
}
