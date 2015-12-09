// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gw2AuthApiRequestValidation.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The guild wars 2 authenticated API request validation helpers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Core.Validators
{
    using System.Linq;

    /// <summary>
    /// The guild wars 2 authenticated API request validation helpers.
    /// </summary>
    public static class Gw2AuthApiRequestValidation
    {
        /// <summary>
        /// Checks that the API key passed looks like a GW2 API key (follows a length pattern between delimiters and is alpha numeric).
        /// </summary>
        /// <param name="possibleKey">
        /// The possible API key.
        /// </param>
        /// <returns>
        /// True if the possibleKey looks like a valid GW2 API key.
        /// </returns>
        public static bool LookLikeAValidGuildWarsTwoApiKey(string possibleKey)
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