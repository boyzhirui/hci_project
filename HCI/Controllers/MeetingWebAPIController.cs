using HCI.Models;
using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HCI.Controllers
{
    public class MeetingWebAPIController : ApiController
    {
        public MeetingInfo Get(int meetingID)
        {
            MeetingModel model = null;

            using (HciDb ctx = new HciDb())
            {
                model = new MeetingModel(ctx);
                model.InitMeeting(meetingID);
            }

            return model.MeetingInfo;
        }


        public void Delete(int eventID)
        {
            using (HciDb ctx = new HciDb())
            {
                Meeting mtg = ctx.Meetings.Where(x => x.id == eventID).FirstOrDefault();
                if (mtg != null)
                {
                    ctx.Meetings.Remove(mtg);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
