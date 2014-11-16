using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HCI.Models.Database;

namespace HCI.Models
{
    public class UserEventListModel : ModelBase
    {
        
        public UserEventListModel()
        {

        }

        public UserEventListModel(HciDb ctx)
            : base(ctx)
        {
        }

        public void InitList(string userName)
        {
            User user = Context.Users
                                .Include("GroupMemberships")
                                .Include("GroupMemberships.Group")
                                .Include("GroupMemberships.Group.Owner")
                                .Include("GroupMemberships.Group.RelGroupsStudyfields")
                                .Include("GroupMemberships.Group.RelGroupsStudyfields.StudyField")
                                .Where(x => x.name == userName).First();

        }
    }

    public class UserEvent
    {

    }
}