using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using HCI.Models.Queries;

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


        public void Fill(GeneralSearchGroupQueryModel queries, string userName)
        {
            AdvancedSearchResult = false;
            GeneralSearchGroupQuery = queries;
            var user = Context.Users.Include("GroupMemberships").Where(x => x.name == userName).First();
            var joinedGroupIDs = user.GroupMemberships.Select(x => x.group_id).ToList();
            UserID = user.id;

            string keyword = queries.Keyword;
            if (string.IsNullOrEmpty(keyword))
            {
                Groups = Context.Groups.Include("Owner")
                              .Include("RelGroupsStudyfields.StudyField")
                              .Include("Meetings")
                              .Include("GroupMemberships")
                              .Where(x => !joinedGroupIDs.Contains(x.id))
                              .ToList();
            }
            else
            {
                Groups = Context.Groups.Include("Owner")
                              .Include("RelGroupsStudyfields.StudyField")
                              .Include("Meetings")
                              .Include("GroupMemberships")
                              .Where(x => !joinedGroupIDs.Contains(x.id) && (x.course_no.Contains(keyword)
                                  || x.name.Contains(keyword)
                                  || x.Owner.name.Contains(keyword)
                                  || x.RelGroupsStudyfields.Any(s => s.StudyField.name.Contains(keyword))
                                  || x.description.Contains(keyword)
                                  || x.course_no.Contains(keyword)))
                              .ToList();
            }
        }

        public void Fill(AdvancedSearchGroupQueryModel queries, string userName)
        {
            Groups = new List<Group>();
            AdvancedSearchGroupQuery = queries;
            AdvancedSearchResult = true;
            var user = Context.Users.Include("GroupMemberships").Where(x => x.name == userName).First();
            var joinedGroupIDs = user.GroupMemberships.Select(x => x.group_id).ToList();
            UserID = user.id;

            if (queries.QueryList != null)
            {
                QueryCombiner queryCombiner = new QueryCombiner();
                IList<IList<IExecutableQuery>> queryOrBundles = queryCombiner.Combine(queries.QueryList);

                //A naive implementation for OR boolean operation
                foreach (IList<IExecutableQuery> bundle in queryOrBundles)
                {
                    IEnumerable<Group> groups = null;
                    foreach (var query in bundle)
                    {
                        if (groups == null)
                        {
                            groups = GetGroup(query, joinedGroupIDs);
                        }
                        else
                        {
                            groups = GetGroup(query, groups, joinedGroupIDs);
                        }
                    }

                    foreach (var group in groups)
                    {
                        Groups.Add(group);
                    }
                }

                Groups = Groups.Distinct(new GroupComparer()).ToList();

            }
        }


        public bool AdvancedSearchResult { get; set; }

        public GeneralSearchGroupQueryModel GeneralSearchGroupQuery { get; set; }
        public AdvancedSearchGroupQueryModel AdvancedSearchGroupQuery { get; set; }

        public int UserID { get; set; }
        public IList<Group> Groups
        {
            get;
            set;
        }

        private IEnumerable<Group> GetGroup(IExecutableQuery query, IEnumerable<int> joinedGroupIDs)
        {
            return Context.Groups.Include("Owner")
                              .Include("RelGroupsStudyfields.StudyField")
                              .Include("GroupMemberships")
                              .Include("Meetings")
                              .Where(query.GetLambda())
                              .Where(x => !joinedGroupIDs.Contains(x.id));
        }
        private IEnumerable<Group> GetGroup(IExecutableQuery query, IEnumerable<Group> groups, IEnumerable<int> joinedGroupIDs)
        {
            return groups.Where(query.GetLambda()).Where(x => !joinedGroupIDs.Contains(x.id));
        }
    }

    
}