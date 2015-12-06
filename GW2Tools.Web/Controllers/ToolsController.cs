// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolsController.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Defines the ToolsController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Core.Birthdays;

    using Gw2Api.Core.EndPoints.CharacterInformation;

    using GW2Tools.Core.AccountInventory;
    using GW2Tools.Core.Objects;

    using ShortStack.Core.Commands;

    /// <summary>
    /// The tools controller.
    /// TODO: Implement a way to handle errors gracefully when calls into GW2Tools.Core fail
    /// </summary>
    public class ToolsController : Controller
    {
        /// <summary>
        /// The get account inventory command.
        /// </summary>
        private readonly BaseCommand<GetAccountInventoryRequest, List<ItemSummary>> getAccountInventoryCommand;

        /// <summary>
        /// The get birthdays command.
        /// </summary>
        private readonly BaseCommand<GetBirthdaysRequest, List<CharacterInformation>> getBirthdaysCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolsController"/> class.
        /// </summary>
        /// <param name="getInventorySummary">
        /// The get inventory summary.
        /// </param>
        /// <param name="getBirthdaysCommand">
        /// The get Birthdays Command.
        /// </param>
        public ToolsController(BaseCommand<GetAccountInventoryRequest, List<ItemSummary>> getInventorySummary, BaseCommand<GetBirthdaysRequest, List<CharacterInformation>> getBirthdaysCommand)
        {
            this.getAccountInventoryCommand = getInventorySummary;
            this.getBirthdaysCommand = getBirthdaysCommand;
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
            var request = new GetAccountInventoryRequest { GuildWars2ApiKey = apiKey };
            var response = this.getAccountInventoryCommand.Execute(request);

            return this.RespondWithJson(response.Result);
        }

        /// <summary>
        /// The get birthdays.
        /// </summary>
        /// <param name="apiKey">
        /// The api key.
        /// </parama
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult GetBirthdays(string apiKey)
        {
            var request = new GetBirthdaysRequest { GuildWars2ApiKey = apiKey };
            var response = this.getBirthdaysCommand.Execute(request);

            return this.RespondWithJson(response.Result);
        }

        /// <summary>
        /// The respond with json.
        /// </summary>
        /// <param name="objectToMakeJson">
        /// The object to make json.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        private ActionResult RespondWithJson(object objectToMakeJson)
        {
            var jsonResult = this.Json(objectToMakeJson, JsonRequestBehavior.AllowGet);

            return jsonResult;
        }
    }
}