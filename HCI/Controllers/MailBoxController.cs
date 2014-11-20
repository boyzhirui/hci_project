using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCI.Controllers
{
    public class MailBoxController : Controller
    {
        // GET: MailBox
        public ActionResult Index()
        {
            return View();
        }
    }
}