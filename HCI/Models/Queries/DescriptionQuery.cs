using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCI.Models.Queries
{
    public class DescriptionQuery : DirectQuery
    {
        public DescriptionQuery(SearchGroupQuery query)
            : base(query)
        {

        }


        public override string GetField(Group group)
        {
            return group.description;
        }
    }
}