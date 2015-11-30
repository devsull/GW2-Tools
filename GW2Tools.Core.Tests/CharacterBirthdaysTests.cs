namespace GW2Tools.Core.Tests
{
    using GW2Tools.Core.Birthdays;

    using Newtonsoft.Json;

    using ShortStack.Core;

    using Xunit;
    using Xunit.Abstractions;

    public class CharacterBirthdaysTests
    {
        public ICharacterBirthdays SystemUnderTest { get; }

        private readonly ITestOutputHelper output;
        private readonly string testKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

        public CharacterBirthdaysTests(ITestOutputHelper output)
        {
            ShortStack.BootStack(false);
            Gw2CoreContainerRegistration.Configure();
            var mappingConfig = new Gw2Api.Core.ObjectMappings();
            mappingConfig.Configure();
            this.SystemUnderTest = Locator.GetInstance<ICharacterBirthdays>();
            this.output = output;
        }

        [Fact]
        public void CharacterBirthdaysWorks()
        {
            var characters = this.SystemUnderTest.GetBirthdays(testKey);

            foreach (var character in characters)
            {
                Assert.NotNull(character.Birthday);
                Assert.NotNull(character.Name);
                Assert.NotNull(character.Race);
                Assert.NotNull(character.Profession);
            }

            var json = JsonConvert.SerializeObject(characters);

            this.output.WriteLine("Json: {0}", json);
        }
    }
}
