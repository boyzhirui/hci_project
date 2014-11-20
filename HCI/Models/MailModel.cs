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
                MailList = GenerateUserMail(Context.Mails.Where(x => x.receiver_id == user.id).OrderByDescending(x => x.send_time));
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
                    MailType = mail.mail_type
                };
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

        public MailType MailType { get; set; }
        public YesNo Readed { get; set; }
    }
}