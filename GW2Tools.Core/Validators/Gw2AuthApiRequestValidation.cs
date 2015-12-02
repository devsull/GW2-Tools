// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GW2AuthApiRequestValidator.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The guild wars 2 auth API request validation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Core.Validators
{
    using System.Linq;

    /// <summary>
    /// The guild wars 2 auth API request validation.
    /// </summary>
    public static class Gw2AuthApiRequestValidation
    {
        /// <summary>
        /// Checks that the api key looks like a gw2 api key (follows a length pattern between delimiters and is alpha numeric).
        /// </summary>
        /// <param name="possibleKey">
        /// The possible api key.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool LooksLikeGuildWarsTwoAPIKey(string possibleKey)
        {
            const char Delimiter = '-';
            
            var expectedTokenLengths = new [] { 8, 4, 4, 4, 20, 4, 4, 4, 12 };
            
            var tokens = possibleKey.Split(Delimiter);

            var actualTokenLengths = tokens.Select(t => t.Length).ToArray();

            if (expectedTokenLengths.Length != actualTokenLengths.Length)
            {
                return false;
            }

            if (expectedTokenLengths.Where((t, index) => actualTokenLengths[index] != t).Any())
            {
                return false;
            }

            var allAlphaNumericChars = tokens.All(t => t.All(char.IsLetterOrDigit));

            return allAlphaNumericChars;
        }
    }
}