// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolsController.cs" company="DMS">
//   For me by me
// </copyright>
// <summary>
//   Defines the ToolsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Web.Controllers
{
    using System.Web.Mvc;

    using Core.Birthdays;
    using Core.InventorySummary;

    /// <summary>
    /// The tools controller.
    /// </summary>
    public class ToolsController : Controller
    {
        /// <summary>
        /// The get character birthdays.
        /// </summary>
        private readonly ICharacterBirthdays getCharacterBirthdays;

        /// <summary>
        /// The get inventory summary.
        /// </summary>
        private readonly IInventorySummary getInventorySummary;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolsController"/> class.
        /// </summary>
        /// <param name="getCharacterBirthdays">
        /// The get character birthdays.
        /// </param>
        /// <param name="getInventorySummary">
        /// The get inventory summary.
        /// </param>
        public ToolsController(ICharacterBirthdays getCharacterBirthdays, IInventorySummary getInventorySummary)
        {
            this.getCharacterBirthdays = getCharacterBirthdays;
            this.getInventorySummary = getInventorySummary;
        }

        /// <summary>
        /// The birthdays.
        /// </summary>
        /// <param name="apiKey">
        /// The api key.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult Birthdays(string apiKey)
        {
            var birthdays = this.getCharacterBirthdays.GetBirthdays(apiKey);

            var jsonResult = this.Json(birthdays, JsonRequestBehavior.AllowGet);

            return jsonResult;
        }

        /// <summary>
        /// The account inventory.
        /// </summary>
        /// <param name="apiKey">
        /// The api key.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult AccountInventory(string apiKey)
        {
            var birthdays = this.getInventorySummary.SummarizeInventory(apiKey);

            var jsonResult = this.Json(birthdays, JsonRequestBehavior.AllowGet);

            return jsonResult;
        }
    }
}