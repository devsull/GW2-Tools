// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Character.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The raw character object received from the GW2 API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.GW2ApiRawObjects
{
    /// <summary>
    /// The raw character object received from the GW2 API.
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        public string Created { get; set; }

        /// <summary>
        /// Gets or sets the race.
        /// </summary>
        public string Race { get; set; }

        /// <summary>
        /// Gets or sets the profession.
        /// </summary>
        public string Profession { get; set; }
    }
}
