using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HCI.Utils;

namespace HCI.Controllers
{
    public class GroupMembershipWebAPIController : ApiController
    {

        public string Post(int userId, int groupId)
        {
            string retStr = "success";
            using(HciDb ctx = new HciDb())
            {
                string aprvl = Consts.ApprovalValue.Yes;
                Group group = ctx.Groups.Where(x => x.id == groupId).FirstOrDefault();
                if (group.is_closed == Utils.YesNo.Yes)
                {
                    aprvl = Consts.ApprovalValue.Pending;
                    retStr = "waiting";
                }

                GroupMembership membership = ctx.GroupMemberships.Where(x => x.user_id == userId && x.group_id == groupId).FirstOrDefault();
                if (membership == null)
                {
                    ctx.GroupMemberships.Add(new GroupMembership { group_id = groupId, user_id = userId, approval = aprvl });
                    ctx.SaveChanges();
                }
                else
                {
                    membership.approval = aprvl;
                    ctx.SaveChanges();
                }
            }
            return retStr;
        }

        public string Delete(int userId, int groupId)
        {
            string retStr = "success";
            using(HciDb ctx = new HciDb())
            {

                GroupMembership membership = ctx.GroupMemberships.Where(x => x.user_id == userId && x.group_id == groupId).FirstOrDefault();
                if (membership != null)
                {
                    ctx.GroupMemberships.Remove(membership);
                    ctx.SaveChanges();
                }
            }
            return retStr;
        }
    }
}
