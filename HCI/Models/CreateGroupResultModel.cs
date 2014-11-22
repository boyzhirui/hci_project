using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCI.Models
{
    public class CreateGroupResultModel
    {
        public bool Success { get; set; }

        public string GroupName { get; set; }
        public string ErrorMessage { get; set; }
    }
}