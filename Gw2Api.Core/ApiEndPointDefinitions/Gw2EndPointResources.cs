// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gw2EndPointResources.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Smart enum for guild wars 2 api resources.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Gw2Api.Core.ApiEndPointDefinitions
{
    /// <summary>
    /// Smart enum for guild wars 2 api resources.
    /// </summary>
    public static class Gw2EndPointResources
    {
        /// <summary>
        /// Gets the Inventory resource.
        /// </summary>
        public static string Inventory => "inventory";

        /// <summary>
        /// Gets the Bank resource.
        /// </summary>
        public static string Bank => "bank";

        /// <summary>
        /// Gets the Material resource.
        /// </summary>
        public static string Material => "materials";

        /// <summary>
        /// Gets the equipment resource.
        /// </summary>
        public static string Equipment => "equipment";
    }
}