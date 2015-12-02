// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterInformation.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The character information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.EndPoints.CharacterInformation
{
    using System;

    /// <summary>
    /// The character information.
    /// </summary>
    public class CharacterInformation
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// Gets or sets the race.
        /// </summary>
        public string Race { get; set; }

        /// <summary>
        /// Gets or sets the profession.
        /// </summary>
        public string Profession { get; set; }

        /// <summary>
        /// Gets the days until birthday.
        /// </summary>
        public int DaysUntilBirthday
        {
            get
            {
                if (string.IsNullOrEmpty(this.Birthday))
                {
                    return -1;
                }

                var today = DateTime.Today;
                var birthdayParsed = DateTime.Parse(this.Birthday);
                var next = new DateTime(today.Year, birthdayParsed.Month, birthdayParsed.Day);

                if (next < today)
                {
                    next = next.AddYears(1);
                }

                return (next - today).Days;
            }
        }
    }
}