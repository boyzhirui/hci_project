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

        public void Post(int userId, int groupId, string status)
        {
            using(HciDb ctx = new HciDb())
            {
                string aprvl = status;

                GroupMembership membership = ctx.GroupMemberships.Where(x => x.user_id == userId && x.group_id == groupId).FirstOrDefault();
                if (membership != null)
                {
                    membership.approval = aprvl;
                    ctx.SaveChanges();
                }
            }
        }

    }
}
