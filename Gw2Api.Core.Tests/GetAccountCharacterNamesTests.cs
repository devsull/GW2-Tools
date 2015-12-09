// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAccountCharacterNamesTests.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Defines the GetAccountCharacterNamesTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.Tests
{
    using EndPoints;
    using EndPoints.AccountCharacterNames;

    using Newtonsoft.Json;

    using ShortStack.Core.Testing;

    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// The get account character names tests.
    /// </summary>
    public class GetAccountCharacterNamesTests : BaseIntegrationTest<IGw2ApiAuthEndPoint<AccountCharacterNames>>
    {
        private readonly ITestOutputHelper output;

        /// <summary>
        /// The test key, my api key that should have account access.
        /// </summary>
        private const string TestKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";

        /// <summary>
        /// The expected name count, I have 12 characters on my guild wars 2 account!
        /// </summary>
        private const int ExpectedNameCount = 12;

        public GetAccountCharacterNamesTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// The get account character names works.
        /// </summary>
        [Fact]
        public void GetAccountCharacterNamesWorks()
        {
            var response = this.SystemUnderTest.HandleRequest(TestKey);

            Assert.Equal(ExpectedNameCount, response.Data.Names.Count);
            Assert.True(response.Success);
        }

        /// <summary>
        /// Test to make sure get account character names fails gracefully on bad api key
        /// </summary>
        [Fact]
        public void GetAccountCharacterNamesFailsGracefullyOnInvalidApiKey()
        {
            var invalidKey = $"{TestKey}Invalid";

            var response = this.SystemUnderTest.HandleRequest(invalidKey);

            Assert.False(response.Success);
            Assert.NotEmpty(response.ErrorMessages);

            this.output.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}
