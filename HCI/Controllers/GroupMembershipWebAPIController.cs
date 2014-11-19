using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HCI.Controllers
{
    public class GroupMembershipWebAPIController : ApiController
    {
        public string Put([FromBody]int userId, [FromBody]int groupId)
        {
            return "waiting";
        }

        public string Delete([FromBody]int userId, [FromBody]int groupId)
        {
            return "success";
        }
    }
}
