﻿using HCI.Models.Database;
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
            Groups = new List<Group>();
            var user = Context.Users.Include("GroupMemberships").Where(x => x.name == userName).First();
            UserID = user.id;

            if (!queries.IsAdvancedSearch)
            {
                
                string keyword = Queries.GeneralSearchKeyword;
                Groups = Context.Groups.Include("Owner")
                              .Include("RelGroupsStudyfields.StudyField")
                              .Include("Meetings")
                              .Include("GroupMemberships")
                              .Where(x => x.course_no.Contains(keyword) 
                                  || x.name.Contains(keyword) 
                                  || x.Owner.name.Contains(keyword)
                                  || x.RelGroupsStudyfields.Any(s=>s.StudyField.name.Contains(keyword))
                                  || x.description.Contains(keyword)
                                  || x.course_no.Contains(keyword))
                              .ToList();
            }
            else
            {
                if (Queries.QueryList != null)
                {
                    IList<IList<SearchGroupQuery>> queryOrBundles = new List<IList<SearchGroupQuery>>();
                    IList<SearchGroupQuery> queryBundle = new List<SearchGroupQuery>();

                    foreach (var query in Queries.QueryList)
                    {
                        if (query.CombineType == "And")
                        {
                            queryBundle.Add(query);
                        }
                        else
                        {
                            queryOrBundles.Add(queryBundle);
                            queryBundle = new List<SearchGroupQuery>();
                            queryBundle.Add(query);
                        }
                    }
                    if (queryBundle.FirstOrDefault() != null)
                    {
                        queryOrBundles.Add(queryBundle);
                    }

                    foreach (IList<SearchGroupQuery> bundle in queryOrBundles)
                    {
                        IEnumerable<Group> groups = null;
                        foreach (SearchGroupQuery query in bundle)
                        {
                            if (string.IsNullOrEmpty(query.SearchValue))
                                continue;

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

                    Groups = Groups.Distinct(new GroupComparer()).ToList();

                }
            }

        }

        public int UserID { get; set; }
        public IList<Group> Groups
        {
            get;
            set;
        }

        private IEnumerable<Group> GetGroup(SearchGroupQuery query)
        {
            return Context.Groups.Include("Owner")
                              .Include("RelGroupsStudyfields.StudyField")
                              .Include("Meetings")
                              .Where(GetLambda(query));
        }

        private IEnumerable<Group> GetGroup(SearchGroupQuery query, IEnumerable<Group> groups)
        {
            return groups.Where(GetLambda(query));
        }

        private Func<Group, bool> GetLambda(SearchGroupQuery query)
        {
            Func<Group, bool> expr = (x=>true);

            if (query.SearchType == "Group Name")
            {
                if (query.SearchVerbType == "Equals")
                {
                    expr = x => x.name.Equals(query.SearchValue, StringComparison.InvariantCultureIgnoreCase);
                }
                else if (query.SearchVerbType == "Not Equals")
                {
                    expr = x => !(x.name.Equals(query.SearchValue, StringComparison.InvariantCultureIgnoreCase));
                }
                else if (query.SearchVerbType == "Contains")
                {
                    expr = x => x.name.Contains(query.SearchValue);
                }
                else if (query.SearchVerbType == "Not Contains")
                {
                    expr = x => !(x.name.Contains(query.SearchValue));
                }
            }
            else if (query.SearchType == "Study Field")
            {
                if (query.SearchVerbType == "Equals")
                {
                    expr = x => x.RelGroupsStudyfields.Any(y => y.StudyField.name.Equals(query.SearchValue, StringComparison.InvariantCultureIgnoreCase));
                }
                else if (query.SearchVerbType == "Not Equals")
                {
                    expr = x => !(x.RelGroupsStudyfields.Any(y => y.StudyField.name.Equals(query.SearchValue, StringComparison.InvariantCultureIgnoreCase)));
                }
                else if (query.SearchVerbType == "Contains")
                {
                    expr = x => x.RelGroupsStudyfields.Any(y => y.StudyField.name.Contains(query.SearchValue));
                }
                else if (query.SearchVerbType == "Not Contains")
                {
                    expr = x => !(x.RelGroupsStudyfields.Any(y => y.StudyField.name.Contains(query.SearchValue)));
                }

                
            }
            else if (query.SearchType == "Course ID")
            {
                if (query.SearchVerbType == "Equals")
                {
                    expr = x => x.course_no.Equals(query.SearchValue, StringComparison.InvariantCultureIgnoreCase);
                }
                else if (query.SearchVerbType == "Not Equals")
                {
                    expr = x => !(x.course_no.Equals(query.SearchValue, StringComparison.InvariantCultureIgnoreCase));
                }
                else if (query.SearchVerbType == "Contains")
                {
                    expr = x => x.course_no.Contains(query.SearchValue);
                }
                else if (query.SearchVerbType == "Not Contains")
                {
                    expr = x => !(x.course_no.Contains(query.SearchValue));
                }
            }
            else if (query.SearchType == "Description")
            {
                if (query.SearchVerbType == "Equals")
                {
                    expr = x => x.description.Equals(query.SearchValue, StringComparison.InvariantCultureIgnoreCase);
                }
                else if (query.SearchVerbType == "Not Equals")
                {
                    expr = x => !(x.description.Equals(query.SearchValue, StringComparison.InvariantCultureIgnoreCase));
                }
                else if (query.SearchVerbType == "Contains")
                {
                    expr = x => x.description.Contains(query.SearchValue);
                }
                else if (query.SearchVerbType == "Not Contains")
                {
                    expr = x => !(x.description.Contains(query.SearchValue));
                }

            }
            else if (query.SearchType == "Group Owner")
            {
                if (query.SearchVerbType == "Equals")
                {
                    expr = x => x.Owner.name.Equals(query.SearchValue, StringComparison.InvariantCultureIgnoreCase);
                }
                else if (query.SearchVerbType == "Not Equals")
                {
                    expr = x => !(x.Owner.name.Equals(query.SearchValue, StringComparison.InvariantCultureIgnoreCase));
                }
                else if (query.SearchVerbType == "Contains")
                {
                    expr = x => x.Owner.name.Contains(query.SearchValue);
                }
                else if (query.SearchVerbType == "Not Contains")
                {
                    expr = x => !(x.Owner.name.Contains(query.SearchValue));
                }
            }

            return expr;
        }
    }

    public class GroupComparer : IEqualityComparer<Group>
    {

        public bool Equals(Group x, Group y)
        {
            return x.id == y.id;
        }

        public int GetHashCode(Group obj)
        {
            return obj.id;
        }
    }
}