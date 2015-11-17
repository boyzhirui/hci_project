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

        public SearchGroupQueryModel Queries { get; set; }

        public void Search(SearchGroupQueryModel queries, string userName)
        {
            Queries = queries;
            Groups = new List<Group>();
            var user = Context.Users.Include("GroupMemberships").Where(x => x.name == userName).First();
            var groupIDs = user.GroupMemberships.Select(x => x.group_id).ToList();
            UserID = user.id;

            if (!queries.IsAdvancedSearch)
            {
                string keyword = Queries.GeneralSearchKeyword;
                if (string.IsNullOrEmpty(keyword))
                {
                    Groups = Context.Groups.Include("Owner")
                                  .Include("RelGroupsStudyfields.StudyField")
                                  .Include("Meetings")
                                  .Include("GroupMemberships")
                                  .Where(x => !groupIDs.Contains(x.id))
                                  .ToList();
                }
                else
                {
                    Groups = Context.Groups.Include("Owner")
                                  .Include("RelGroupsStudyfields.StudyField")
                                  .Include("Meetings")
                                  .Include("GroupMemberships")
                                  .Where(x => !groupIDs.Contains(x.id) && (x.course_no.Contains(keyword)
                                      || x.name.Contains(keyword)
                                      || x.Owner.name.Contains(keyword)
                                      || x.RelGroupsStudyfields.Any(s => s.StudyField.name.Contains(keyword))
                                      || x.description.Contains(keyword)
                                      || x.course_no.Contains(keyword)))
                                  .ToList();
                }
            }
            else
            {
                if (Queries.QueryList != null)
                {
                    QueryCombiner queryCombiner = new QueryCombiner();
                    IList<IList<IExecutableQuery>> queryOrBundles = queryCombiner.Combine(Queries.QueryList);

                    //A naive implementation for OR boolean operation
                    foreach (IList<IExecutableQuery> bundle in queryOrBundles)
                    {
                        IEnumerable<Group> groups = null;
                        foreach (var query in bundle)
                        {
                            if (groups == null)
                            {
                                groups = GetGroup(query);
                            }
                            else
                            {
                                groups = GetGroup(query, groups);
                            }
                        }

                        foreach (var group in groups)
                        {
                            Groups.Add(group);
                        }
                    }

                    Groups = Groups.Where(x=> !groupIDs.Contains(x.id)).Distinct(new GroupComparer()).ToList();

                }
            }

        }

        public int UserID { get; set; }
        public IList<Group> Groups
        {
            get;
            set;
        }

        private IEnumerable<Group> GetGroup(IExecutableQuery query)
        {
            return Context.Groups.Include("Owner")
                              .Include("RelGroupsStudyfields.StudyField")
                              .Include("GroupMemberships")
                              .Include("Meetings")
                              .Where(query.GetLambda());
        }
        private IEnumerable<Group> GetGroup(IExecutableQuery query, IEnumerable<Group> groups)
        {
            return groups.Where(query.GetLambda());
        }

    }

    
}