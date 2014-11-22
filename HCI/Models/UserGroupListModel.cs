using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCI.Models
{
    public class UserGroupListModel : ModelBase
    {
        
        public UserGroupListModel()
        {

        }

        public UserGroupListModel(HciDb ctx):base(ctx)
        {
        }

        public IList<Group> Groups
        {
            get;
            set;
        }

        public void InitList(string userName)
        {
            User user = Context.Users
                                .Include("GroupMemberships")
                                .Include("GroupMemberships.Group")
                                .Include("GroupMemberships.Group.Meetings")
                                .Include("GroupMemberships.Group.Owner")
                                .Include("GroupMemberships.Group.RelGroupsStudyfields")
                                .Include("GroupMemberships.Group.RelGroupsStudyfields.StudyField")
                                .Where(x => x.name == userName).First();

            if (user.GroupMemberships != null)
            {
                Groups = user.GroupMemberships.Select(x => x.Group).ToList();
            }
            else
            {
                Groups = new List<Group>();
            }
        }

        
    }

}