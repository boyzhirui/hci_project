using HCI.Models;
using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCI.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        // GET: SearchTeam
        public ActionResult GeneralSearchGroup()
        {
            SearchGroupQueryModel model = new SearchGroupQueryModel();
            return View(model);
        }

        public ActionResult AdvancedSearchGroup()
        {
            SearchGroupQueryModel model = new SearchGroupQueryModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult SearchGroupResult(SearchGroupQueryModel queryModel)
        {
            SearchGroupResultModel model = null;
            using (HciDb ctx = new HciDb())
            {
                model = new SearchGroupResultModel(ctx);
                model.Search(queryModel, User.Identity.Name);
            }

            return View(model);
        }
    }
}