// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gw2AuthApiRequestValidationTests.cs" company="DMS">
//   Yop.
// </copyright>
// <summary>
//   The gw 2 auth api request validation tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Core.Tests.ValidationTests
{
    using Validators;

    using Xunit;

    /// <summary>
    /// The gw 2 auth api request validation tests.
    /// </summary>
    public class Gw2AuthApiRequestValidationTests
    {
        /// <summary>
        /// The valid key.
        /// </summary>
        private const string ValidKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B0214";
        
        [Fact]
        public void LookLikeAValidGuildWarsTwoApiKeyWorks()
        {
            var validation = Gw2AuthApiRequestValidation.LookLikeAValidGuildWarsTwoApiKey(ValidKey);
            Assert.True(validation);
        }
        
        [Fact]
        public void LooksLikeAnApiKeyReturnsFalseWhenTooLong()
        {
            var invalidKey = $"{ValidKey}Invalid";
            var validation = Gw2AuthApiRequestValidation.LookLikeAValidGuildWarsTwoApiKey(invalidKey);
            Assert.False(validation);
        }

        [Fact]
        public void LooksLikeAnApiKeyReturnsFalseWhenTooShort()
        {
            var invalidKey = "C10D3218-A187-F34F-A93E-0543601C299846C8C6FB-7FAC-492E-B89D-35E1669B021";
            var validation = Gw2AuthApiRequestValidation.LookLikeAValidGuildWarsTwoApiKey(invalidKey);
            Assert.False(validation);
        }

        [Fact]
        public void LooksLikeAnApiKeyReturnsFalseWhenNotAlphaNumeric()
        {
            var invalidKey = "C10D3/18-A187-F34F-A93E-0543601C299#46C8C6FB-7FAC-492E-B89D-35E1669B021@";
            var validation = Gw2AuthApiRequestValidation.LookLikeAValidGuildWarsTwoApiKey(invalidKey);
            Assert.False(validation);
        }
    }
}