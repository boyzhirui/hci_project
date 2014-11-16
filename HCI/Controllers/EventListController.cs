using HCI.Models;
using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HCI.Controllers
{
    public class EventListController : ApiController
    {
        public IList<UserEvent> Get(string start, string end, string userName)
        {

            DateTime startDt = DateTime.ParseExact(start, "yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
            DateTime endDt = DateTime.ParseExact(end, "yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo) + TimeSpan.FromSeconds(3600 * 24 - 1);

            UserEventListModel model;
            using (HciDb ctx = new HciDb())
            {
                model = new UserEventListModel(ctx);
                model.InitList(userName, startDt, endDt);
            }
            
            //List<UserEvent> eventList = new List<UserEvent>();

            //eventList.Add(new UserEvent { Title = "title 1", Start = "2014-11-15T09:00:00", End = "2014-11-15T12:00:00" });
            //eventList.Add(new UserEvent { Title = "title 2", Start = "2014-11-16T09:00:00", End = "2014-11-16T12:00:00" });
            return model.Events;
        }
    }

}
