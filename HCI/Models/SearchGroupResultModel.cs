using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace HCI.Models
{
    public class SearchGroupResultModel:ModelBase
    {
        public SearchGroupResultModel()
        {

        }

        public SearchGroupResultModel(HciDb ctx):base(ctx)
        {

        }

        public SearchGroupQueryModel Queries { get; set; }

        public void Search(SearchGroupQueryModel queries, string userName)
        {
            Queries = queries;
            if (!queries.IsAdvancedSearch)
            {
                var groupIDs = Context.Users.Where(x => x.name == userName).SelectMany(x => x.GroupMemberships).Select(x => x.group_id);
                string keyword = Queries.GeneralSearchKeyword;
                Groups = Context.Groups.Include("Owner")
                              .Include("RelGroupsStudyfields.StudyField")
                              .Include("Meetings")
                              .Where(x => !groupIDs.Contains(x.id) && (x.course_no.Contains(keyword) 
                                  || x.name.Contains(keyword) 
                                  || x.Owner.name.Contains(keyword)
                                  || x.RelGroupsStudyfields.Any(s=>s.StudyField.name.Contains(keyword))
                                  || x.description.Contains(keyword)))
                              .ToList();
            }

            if (Groups == null)
            {
                Groups = new List<Group>();
            }
        }


        public IList<Group> Groups
        {
            get;
            set;
        }

    }
}