// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Gw2CoreContainerRegistration.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   The Guild Wars 2 core container registration, only needed for some tests.
//   TODO: Fix why this exists.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Core
{
    using InventorySummary;

    using ShortStack.Core;

    /// <summary>
    /// The Guild Wars 2 core container registration, only needed for some tests.
    /// TODO: Fix why this exists.
    /// </summary>
    public static class Gw2CoreContainerRegistration
    {
        /// <summary>
        /// The configure.
        /// </summary>
        public static void Configure()
        {
            var registerApi = new Gw2Api.Core.ContainerRegistration();
            registerApi.Configure();

            ShortStack.Container.Register<IInventorySummary, InventorySummary.InventorySummary>();
        }
    }
}
