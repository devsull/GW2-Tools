namespace GW2Tools.Core.Tests
{
    using System.Collections.Generic;

    using Gw2Api.Core.EndPoints.CharacterInformation;

    using ShortStack.Core.Commands;
    using ShortStack.Core.Testing;

    using Xunit;
    using Xunit.Abstractions;

    public class GetCharacterBirthdaysCommandTests : BaseIntegrationTest<BaseCommand<GetBirthdaysRequest, List<CharacterInformation>>>
    {
        private readonly ITestOutputHelper output;

        private readonly string testKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

        public GetCharacterBirthdaysCommandTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CommandWorks()
        {
            var request = new GetBirthdaysRequest { GuildWars2ApiKey = this.testKey };
            var response = this.SystemUnderTest.Execute(request);

            Assert.True(response.Success);
            Assert.NotEmpty(response.Result);

            this.output.WriteLine($"Command completed in {response.ExecutionTime}ms");
        }
    }
}