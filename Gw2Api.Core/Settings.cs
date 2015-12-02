// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core
{
    using System.Configuration;

    /// <summary>
    /// The settings.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        public Settings()
        {
            this.ApiRootUrl = ConfigurationManager.AppSettings["ApiRootUrl"];
            this.ApiVersion = ConfigurationManager.AppSettings["ApiVersion"];
        }

        /// <summary>
        /// Gets the GW2 API root url.
        /// </summary>
        public string ApiRootUrl { get; private set; }

        /// <summary>
        /// Gets the GW2 API version.
        /// </summary>
        public string ApiVersion { get; private set; }
    }
}
