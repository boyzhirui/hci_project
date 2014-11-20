using HCI.Models.Database;
using HCI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCI.Models
{
    public class MailModel :ModelBase
    {
        public MailModel()
        {

        }

        public MailModel(HciDb ctx):base(ctx)
        {

        }

        public IList<UserMail> MailList { get; set; }

        public void GetMails(string userName)
        {
            MailList = new List<UserMail>();

            User user = Context.Users.Where(x=>x.name == userName).FirstOrDefault();
            if (user != null)
            {
                MailList = GenerateUserMail(Context.Mails
                                        .Include("Sender")
                                        .Include("Receiver")
                                        .Where(x => x.receiver_id == user.id)
                                        .OrderByDescending(x => x.send_time));
            }
        }

        private IList<UserMail> GenerateUserMail(IEnumerable<Mail> mails)
        {
            List<UserMail> list = new List<UserMail>();

            foreach(var mail in mails)
            {
                UserMail userMail = new UserMail
                {
                    MailID = mail.id,
                    Sender = mail.Sender.name,
                    Content = mail.content ?? string.Empty,
                    Readed = mail.readed,
                    Subject = mail.subject,
                    SenderID = mail.sender_id,
                    MailType = mail.mail_type,
                    SendingTime = mail.send_time.ToString("yyyy-MM-dd hh:mm:ss tt")
                    
                };

                if (mail.mail_type == MailType.JoinRequest)
                {
                    userMail.GroupMembershipID = mail.related_id_01;

                    GroupMembership groupMembership = Context.GroupMemberships.Include("Group").Where(x => x.id == mail.related_id_01).FirstOrDefault();
                    if (groupMembership != null)
                    {
                        userMail.GroupID = groupMembership.Group.id;
                        userMail.GroupName = groupMembership.Group.name;
                    }
                }
                else if(mail.mail_type == MailType.MeetingRequest)
                {
                    userMail.MeetingId = mail.related_id_01;
                    Meeting mtg = Context.Meetings.Include("Group").Where(x => x.id == mail.related_id_01).FirstOrDefault();
                    if (mtg != null)
                    {
                        userMail.MeetingTitle = mtg.name;
                        Group group = mtg.Group;
                        if (group != null)
                        {
                            userMail.GroupID = group.id;
                            userMail.GroupName = group.name;
                        }
                    }
                }


                list.Add(userMail);
            }

            return list;
        }
    }

    public class UserMail
    {
        public int MailID {get; set;}
        public string Subject { get; set; }
        public string Sender { get; set; }
        public int SenderID { get; set; }
        public string Content { get; set; }
        public string SendingTime { get; set; }
        public MailType MailType { get; set; }
        public YesNo Readed { get; set; }

        public int GroupID { get; set; }
        public string GroupName { get; set; }

        public int MeetingId { get; set; }
        public string MeetingTitle { get; set; }
        public int GroupMembershipID { get; set; }
    }
}