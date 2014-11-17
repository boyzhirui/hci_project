using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCI.Models
{
    public class ScheduleMeetingResultModel
    {
        public bool Success { get; set; }

        public string Title { get; set; }
        public string GroupName { get; set; }
        public string ErrorMessage { get; set; }

    }
}