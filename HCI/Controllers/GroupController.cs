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
            TempData["SearchGroupResultData"] = null;
            GeneralSearchGroupQueryModel model = new GeneralSearchGroupQueryModel();
            return View(model);
        }

        public ActionResult AdvancedSearchGroup()
        {
            TempData["SearchGroupResultData"] = null;
            AdvancedSearchGroupQueryModel model = new AdvancedSearchGroupQueryModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult GeneralSearchGroupResult(GeneralSearchGroupQueryModel queryModel)
        {
            
            SearchGroupResultModel model = null;
            using (HciDb ctx = new HciDb())
            {
                model = new SearchGroupResultModel(ctx);
                model.Fill(queryModel, User.Identity.Name);
            }

            TempData["SearchGroupResultData"] = model;

            return RedirectToAction("SearchGroupResult");
        }

        [HttpPost]
        public ActionResult AdvancedSearchGroupResult(AdvancedSearchGroupQueryModel queryModel)
        {
            SearchGroupResultModel model = null;
            using (HciDb ctx = new HciDb())
            {
                model = new SearchGroupResultModel(ctx);
                model.Fill(queryModel, User.Identity.Name);
            }

            TempData["SearchGroupResultData"] = model;

            return RedirectToAction("SearchGroupResult");
        }

        [HttpGet]
        public ActionResult SearchGroupResult()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateGroup()
        {
            CreateGroupModel model;
            using (HciDb ctx = new HciDb())
            {
                model = new CreateGroupModel();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateGroup(CreateGroupModel model)
        {
            string userName = User.Identity.Name;
            bool success = false;
            Exception e = null;
            try
            {

                using (HciDb ctx = new HciDb())
                {
                    model.Save(ctx, userName);
                }
                success = true;
            }
            catch (Exception ex)
            {
                e = ex;
            }

            CreateGroupResultModel rstModel = new CreateGroupResultModel
            {
                Success = success,
                GroupName = model.newGroup.name,
                ErrorMessage = success ? string.Empty : e.ToString()
            };

            return RedirectToAction("CreateGroupResult", rstModel);
        }

        [HttpGet]
        public ActionResult CreateGroupResult(CreateGroupResultModel model)
        {
            return View(model);
        }
    }
}