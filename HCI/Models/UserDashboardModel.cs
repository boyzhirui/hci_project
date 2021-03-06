﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HCI.Models;
using HCI.Models.Database;
namespace HCI.Models
{
    public class UserDashboardModel:ModelBase
    {
        public UserEventListModel EventModel { get; set; }
        public UserGroupListModel GroupModel { get; set; }

        public UserDashboardModel()
        {

        }

        public UserDashboardModel(HciDb ctx):base(ctx)
        {
            EventModel = new UserEventListModel(ctx);
            GroupModel = new UserGroupListModel(ctx);
        }

        public void Init(string userName, DateTime start, DateTime end)
        {
            EventModel.InitList(userName, start, end);
            GroupModel.InitList(userName);
            DateTime startDay,endDay;
            for(int i=0;i<EventModel.Events.Count;i++)
            {
               startDay=DateTime.Parse(EventModel.Events[i].Start);
               EventModel.Events[i].Start = String.Format("{0:MM/dd/yyyy HH:mm}", startDay);

               endDay = DateTime.Parse(EventModel.Events[i].End);
               EventModel.Events[i].End = String.Format("{0:HH:mm}", endDay);
            }
        }
    }
}