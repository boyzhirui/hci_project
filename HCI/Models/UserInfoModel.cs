using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCI.Models
{
    public class UserInfoModel: ModelBase
    {
        public UserInfoModel()
        {

        }
        public UserInfoModel(HciDb ctx):base(ctx)
        {

        }

        public User user
        {
            get;
            set;
        }

        public void getUserInfo(string userName)
        {
             user = Context.Users
                        .Include("Major")
                        .Include("DegreeLevel")
                        .Where(x => x.name == userName).First();          
        }

        public void getUserInfo(int userID)
        {
            user = Context.Users
                       .Include("Major")
                       .Include("DegreeLevel")
                       .Where(x => x.id == userID).First();
        }

        public User getUserInfo(string userName,int id)
        {
            user = Context.Users
                       .Include("Major")
                       .Include("DegreeLevel")
                       .Where(x => x.name == userName).First();
            return user;
        }
        public void updateUserInfo(string phone, string address)
        {
            if(phone!="")
            {
                user.phone = phone;
            }
            if(address!="")
            {
                user.addr = address;
            }

        }
    }
}