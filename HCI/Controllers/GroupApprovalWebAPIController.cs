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
    public class GroupApprovalWebAPIController : ApiController
    {

        public void Post(int membershipID, string status)
        {
            using(HciDb ctx = new HciDb())
            {
                string aprvl = status;

                GroupMembership membership = ctx.GroupMemberships.Where(x => x.id == membershipID).FirstOrDefault();
                if (membership != null)
                {
                    membership.approval = aprvl;
                    ctx.SaveChanges();
                }
            }
        }

    }
}
