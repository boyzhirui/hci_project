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

        [HttpGet]
        public ActionResult ScheduleMeeting(string groupId)
        {
            ScheduleMeetingModel model;
            using (HciDb ctx = new HciDb())
            {
                model = new ScheduleMeetingModel(ctx);
                if (groupId == null)
                    groupId = "4";
                int gid = Int32.Parse(groupId);
                model.Init(gid);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult ScheduleMeeting(ScheduleMeetingModel model)
        {
            bool success = false;
            Exception e = null;

            try
            {
                using (HciDb ctx = new HciDb())
                {
                    //model.Save(ctx);
                }
                success = true;
            }
            catch (Exception ex)
            {
                e = ex;
            }

            ScheduleMeetingResultModel rstModel = new ScheduleMeetingResultModel
            {
                Success = success,
                GroupName = model.GroupName,
                Title = model.Title,
                ErrorMessage = success ? string.Empty : e.ToString()
            };

            return RedirectToAction("ScheduleMeetingResult", rstModel);

        }

        [HttpGet]
        public ActionResult ScheduleMeetingResult(ScheduleMeetingResultModel model)
        {
            return View(model);
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

        public ActionResult Dashboard()
        {

            string userName = User.Identity.Name;


            UserDashboardModel model;
            DateTime start,end;
            start=DateTime.Now.Date;
            end=start.AddMonths(1);
            using (HciDb ctx = new HciDb())
            {
                model = new UserDashboardModel(ctx);
                model.Init(userName,start,end,7);
            }

            return View(model);
        }
        
        public ActionResult GroupDetail(int ID=0)
        {
            UserGroupDetailModel model;
           using(HciDb ctx = new HciDb())
           {
               model = new UserGroupDetailModel(ctx);
               DateTime start, end;
               start = DateTime.Now.Date;
               end = start.AddMonths(1);
               model.InitLiset(ID,start,end,7);
           }
            return View(model);
        }
    }
}