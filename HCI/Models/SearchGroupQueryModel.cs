using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCI.Models
{
    public class SearchGroupQueryModel
    {
        public SearchGroupQueryModel()
        {
            QueryList = new List<SearchGroupQuery>();
            GeneralSearchKeyword = string.Empty;
            IsAdvancedSearch = false;
        }

        public Boolean IsAdvancedSearch { get; set; }
        public string GeneralSearchKeyword { get; set; }
        public IList<SearchGroupQuery> QueryList { get; set; }
    }

    public class SearchGroupQuery
    {
        public string SearchType { get; set; }
        public string CombineType { get; set; }

        public string SearchValue { get; set; }
    }
}