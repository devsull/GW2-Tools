// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCharacterInformationTests.cs" company="Devin Sullivan">
//   Devin Sullivan made this.
// </copyright>
// <summary>
//   The get character information tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.Tests
{
    using EndPoints;
    using EndPoints.CharacterInformation;

    using Newtonsoft.Json;

    using ShortStack.Core.Testing;

    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// The get character information tests.
    /// </summary>
    public class GetCharacterInformationTests : BaseIntegrationTest<IGw2ApiAuthEndPoint<CharacterInformation>>
    {
        /// <summary>
        /// The output.
        /// </summary>
        private readonly ITestOutputHelper output;

        /// <summary>
        /// The test key.
        /// </summary>
        private readonly string testKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

        /// <summary>
        /// The character name.
        /// </summary>
        private readonly string characterName = "Synaw";

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCharacterInformationTests"/> class.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        public GetCharacterInformationTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// The get character information works.
        /// </summary>
        [Fact]
        public void GetCharacterInformationWorks()
        {
            var info = this.SystemUnderTest.HandleRequest(this.testKey, this.characterName);

            Assert.NotNull(info.Birthday);
            Assert.NotNull(info.Name);

            var json = JsonConvert.SerializeObject(info);

            this.output.WriteLine("Json: {0}", json);
        }
    }
}