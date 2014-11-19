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
        private string searchType;
        public string SearchType
        {
            get
            {
                if (searchType == null) searchType = string.Empty; return searchType;
            }
            set
            {
                searchType = value;
            }
        }

        private string combineType;
        public string CombineType {
            get
            {
                if (combineType == null) combineType = string.Empty; return combineType;
            }
            set
            {
                combineType = value;
            }
        }

        private string searchVerbType;
        public string SearchVerbType
        {
            get
            {
                if (searchVerbType == null) searchVerbType = string.Empty; return searchVerbType;
            }
            set
            {
                searchVerbType = value;
            }
        }

        private string searchValue;
        public string SearchValue {
            get
            {
                if (searchValue == null) searchValue = string.Empty; return searchValue;
            }
            set
            {
                searchValue = value;
            }
        }
    }
}