namespace GW2Tools.Core.Tests
{
    using Newtonsoft.Json;
    using System;
    using Xunit;
    using Xunit.Abstractions;
    using ShortStack.Core.Testing;

    public class CharacterBirthdaysTests : BaseIntegrationTest<ICharacterBirthdays>
    {
        private readonly ITestOutputHelper output;
        private readonly string testKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

        public CharacterBirthdaysTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CharacterBirthdaysWorks()
        {
            var characters = this.SystemUnderTest.GetBirthdays(testKey);

            foreach (var character in characters)
            {
                Assert.NotEqual(default(DateTime), character.Birthday);
                Assert.NotNull(character.Name);
                Assert.NotNull(character.Race);
                Assert.NotNull(character.Profession);
            }

            var json = JsonConvert.SerializeObject(characters);

            this.output.WriteLine("Json: {0}", json);
        }
    }
}
