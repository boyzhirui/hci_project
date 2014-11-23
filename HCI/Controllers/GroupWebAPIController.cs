using HCI.Models;
using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HCI.Controllers
{
    public class GroupWebAPIController : ApiController
    {
        public GroupInfo Get(int groupID)
        {
            UserGroupDetailModel model;
            using (HciDb ctx = new HciDb())
            {
                model = new UserGroupDetailModel(ctx);

                model.InitGroup(groupID);
            }

            Group group = model.Group;
            return new GroupInfo
            {
                name = group.name,
                courseNo = group.course_no,
                maxMemberNumber = group.max_member_number.ToString(),
                description = group.description,
                studyFields = String.Join(",", group.RelGroupsStudyfields.Select(x => x.StudyField).Select(z => z.name))
            };
        }

        public class GroupInfo
        {
            public string name;
            public string description;
            public string studyFields;
            public string courseNo;
            public string maxMemberNumber;
        }
    }
}
