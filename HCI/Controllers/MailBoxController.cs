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
    public class MailBoxController : Controller
    {
        // GET: MailBox
        public ActionResult Index()
        {
            MailModel model = null;

            using (HciDb ctx = new HciDb())
            {
                model = new MailModel(ctx);

                model.GetMails(User.Identity.Name);
            }
            return View(model);
        }
    }
}