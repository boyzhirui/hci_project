using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HCI.Models;
using HCI.Models.Database;

namespace HCI.Models
{
    public class UserGroupDetailModel:ModelBase
    {

        //1.get all group member
        public IList<User> UserModel { get; set; }
        
        //2.get all group events
        public IList<Meeting> MeetingModel { get; set; }

        public UserEventListModel EventModel { get; set; }
        public Group Group;
        public UserGroupDetailModel()
        {

        }

        public UserGroupDetailModel(HciDb ctx): base(ctx)
        {
            EventModel=new UserEventListModel(ctx);
        }

        public void InitLiset(int groupID,DateTime start,DateTime end)
        {
            Group group = Context.Groups
                                .Include("GroupMemberships")
                                .Include("GroupMemberShips.User")
                                .Include("GroupMemberships.Group")
                                .Include("GroupMemberships.Group.Owner")
                                .Include("GroupMemberships.Group.RelGroupsStudyfields")
                                .Include("GroupMemberships.Group.RelGroupsStudyfields.StudyField")
                                .Where(x => x.id == groupID).FirstOrDefault();
            if(group!=null)
            {
                Group = group;
                if (group.Meetings != null)
                {
                    MeetingModel = group.Meetings.ToList();
                    EventModel.InitGroupMeetingList(MeetingModel, start, end);
                    DateTime startDay, endTime;
                    for (int i = 0; i < EventModel.Events.Count; i++)
                    {
                        startDay = DateTime.Parse(EventModel.Events[i].Start);
                        EventModel.Events[i].Start = String.Format("{0:MM/dd/yyyy HH:mm}", startDay);
                        endTime = DateTime.Parse(EventModel.Events[i].End);
                        EventModel.Events[i].End = String.Format("{0:HH:mm}", endTime);
                    }
                }
                else
                {
                    MeetingModel = new List<Meeting>();
                }


                if (group.GroupMemberships != null)
                {
                    UserModel = group.GroupMemberships.Select(x => x.User).ToList();
                }
                else
                {
                    UserModel = new List<User>();
                }
            }
            else
            {
                Group = new Group();
            }     
        }
    }
}