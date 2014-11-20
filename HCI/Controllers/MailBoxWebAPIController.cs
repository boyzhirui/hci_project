using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HCI.Controllers
{
    public class MailBoxWebAPIController : ApiController
    {
        public int Get(string userName)
        {
            int unreadCnt = 0;
            using (HciDb ctx = new HciDb())
            {
                User user = ctx.Users.Where(x => x.name == userName).FirstOrDefault();
                if (user != null)
                {
                    unreadCnt = ctx.Mails.Where(x => x.receiver_id == user.id && x.readed == Utils.YesNo.No).Count();
                }
            }
            return unreadCnt;
        }
    }
}
