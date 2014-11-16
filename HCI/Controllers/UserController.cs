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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult GetGroups()
        {
            string userName = User.Identity.Name;

            UserGroupListModel model;
            using (HciDb ctx = new HciDb())
            {
                model = new UserGroupListModel(ctx);
                model.InitList(userName);
            }
            return View(model);
        }

        public ActionResult GetMeetings()
        {
            string userName = User.Identity.Name;

            return View();
        }

        [HttpPost]
        public ActionResult ScheduleMeeting()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QuitGroup()
        {
            return View();
        }


        public ActionResult UserInfo()
        {
            string userName = User.Identity.Name;

            UserInfoModel model;
            using (HciDb ctx = new HciDb())
            {
                model = new UserInfoModel(ctx);
                model.getUserInfo(userName);
            }
            return View(model);

        }
        [HttpPost]
        public ActionResult UserUpdateInfo(string phone="",string address="")
        {
            string userName = User.Identity.Name;

            UserInfoModel model;
            using (HciDb ctx = new HciDb())
            {
                model = new UserInfoModel(ctx);
                model.getUserInfo(userName);
                model.updateUserInfo(phone, address);
                ctx.SaveChanges();
            }
            return UserInfo();

        }
    }
}