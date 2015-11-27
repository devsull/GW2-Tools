using System;
using Gw2Api.Core.EndPoints.AccountCharacterNames;
using Gw2Api.Core.EndPoints.CharacterInformation;
using Newtonsoft.Json;
using ShortStack.Core;
using Xunit;
using Xunit.Abstractions;

namespace Gw2Api.Core.Tests
{
    public class GetCharacterInformationTests
    {
        private readonly ITestOutputHelper output;
        private GetCharacterInformation SystemUnderTest;

        private readonly string testKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

        private readonly string characterName = "Synaw";

        public GetCharacterInformationTests(ITestOutputHelper output)
        {
            this.output = output;
            ShortStack.Core.ShortStack.BootStack();
            this.SystemUnderTest = Locator.GetInstance<GetCharacterInformation>();
        }

        [Fact]
        public void GetCharacterInformationWorks()
        {
            var info = this.SystemUnderTest.HandleRequest(this.testKey, this.characterName);

            Assert.NotEqual(default(DateTime), info.Birthday);
            Assert.NotNull(info.Name);

            var json = JsonConvert.SerializeObject(info);

            this.output.WriteLine("Json: {0}", json);
        }
    }
}