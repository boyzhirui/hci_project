using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCI.Models
{
    public class UserGroupListModel : IDisposable
    {
        [NonSerialized]
        private HciDb context = null;
        [NonSerialized]
        private bool contextInited = false;
        [NonSerialized]
        private bool needDispose = false;
        private bool ContextInited
        {
            get { return contextInited; }
            set { contextInited = value; }
        }
        private HciDb Context
        {
            get
            {
                if(!ContextInited)
                {
                    context = new HciDb();
                    needDispose = true;
                }
                return context;
            }

            set
            {
                ContextInited = true;
                context = value;

            }
        }
        public UserGroupListModel()
        {

        }

        public UserGroupListModel(HciDb ctx)
        {
            Context = ctx;
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
                                .Include("GroupMemberships.Group.Owner")
                                .Include("GroupMemberships.Group.RelGroupsStudyfields")
                                .Include("GroupMemberships.Group.RelGroupsStudyfields.StudyField")
                                .Where(x => x.name == userName).First();

            Groups = user.GroupMemberships.Select(x=>x.Group).ToList();
        }

        ~UserGroupListModel()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (needDispose)
            {
                Context.Dispose();
            }
        }
    }

}