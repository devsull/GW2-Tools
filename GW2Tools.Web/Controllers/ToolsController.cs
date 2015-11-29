using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GW2Tools.Core;

namespace GW2Tools.Web.Controllers
{
    public class ToolsController : Controller
    {
        private readonly ICharacterBirthdays getCharacterBirthdays;

        public ToolsController(ICharacterBirthdays getCharacterBirthdays)
        {
            this.getCharacterBirthdays = getCharacterBirthdays;
        }
        
        [HttpGet]
        public ActionResult Birthdays(string apiKey)
        {
            var birthdays = getCharacterBirthdays.GetBirthdays(apiKey);

            var jsonResult = Json(birthdays, JsonRequestBehavior.AllowGet);
            
            return jsonResult;
        }
    }
}