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
    public class UserWebAPIController : ApiController
    {
        public UserInfo Get(int userID)
        {
            UserInfoModel model;

            using (HciDb ctx = new HciDb())
            {
                model = new UserInfoModel(ctx);

                model.getUserInfo(userID);
            }
            User user = model.user;

            return new UserInfo { userName = user.name, degree = user.DegreeLevel.degree_level_desc, email = user.name + "@ncsu.edu", phone = user.phone, major = user.Major.major_name };

        }

        public class UserInfo
        {
            public UserInfo()
            {

            }

            public string userName;
            public string degree;
            public string email;
            public string phone;
            public string major;
        }
    }
}
