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

        public ActionResult GetSchedules()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ScheduleMeeting()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QuitGroup(string modalGroupId)
        {
            int groupId = 0;
            Exception e = null;
            bool success = false;
            string groupName = string.Empty;
            try
            {
                if (Int32.TryParse(modalGroupId, out groupId))
                {
                    string userName = User.Identity.Name;
                    using (HciDb ctx = new HciDb())
                    {
                        var membership = ctx.GroupMemberships.Where(x => x.group_id == groupId && x.User.name == userName).FirstOrDefault();
                        if (membership != null)
                        {
                            groupName = membership.Group.name;
                            ctx.GroupMemberships.Remove(membership);
                            ctx.SaveChanges();
                        }
                    }
                    success = true;
                }
            }
            catch (Exception ex)
            {
                e = ex;
            }

            return RedirectToAction("QuitGroupResult", new QuitGroupResultModel { Success = success, GroupName = groupName, ErrorMessage = success ? string.Empty : e.ToString() });

        }

        public ActionResult QuitGroupResult(QuitGroupResultModel info)
        {
            return View(info);
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