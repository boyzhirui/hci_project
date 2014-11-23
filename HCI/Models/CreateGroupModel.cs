using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCI.Models;
using HCI.Models.Database;
namespace HCI.Models
{
    public class CreateGroupModel:ModelBase
    {
        public CreateGroupModel()
        {
            this.newGroup = new Group();
            this.groupMemberShip = new GroupMembership();
        }

        public CreateGroupModel(HciDb ctx):base(ctx)
        {
            this.newGroup = new Group();
            this.groupMemberShip = new GroupMembership();

        }

        public void Save(HciDb ctx,string userName)
        {
            User user = Context.Users.Where(x => x.name == userName).FirstOrDefault();
            isExist = false;
            List<Group> isExistGroup = Context.Groups.Where(x => x.name == this.newGroup.name).ToList();

            foreach (Group group in isExistGroup)
            {
                if (user.id == group.owner_id)
                {
                    isExist = true;
                    break;
                }
            }

            if (!isExist)
            {
                foreach(string FName in this.fieldName)
                {
                    if (FName != "None" && FName != "")
                    {
                        this.studyField = Context.StudyFields.Where(x => x.name == FName).FirstOrDefault();
                        this.groupStudyField=new RelGroupsStudyfield();
                        this.groupStudyField.group_id = this.newGroup.id;
                        this.groupStudyField.study_field_id = this.studyField.id;
                        ctx.RelGroupsStudyfields.Add(this.groupStudyField);
                    }
                }
             


                if (this.newGroup.max_member_number.ToString() == "")
                {
                    this.newGroup.max_member_number = 10;
                }


                this.newGroup.owner_id = user.id;

                this.groupMemberShip.group_id = this.newGroup.id;
                this.groupMemberShip.user_id = user.id;

                ctx.Groups.Add(this.newGroup);
                ctx.GroupMemberships.Add(this.groupMemberShip);
                ctx.SaveChanges();
            }
        }
        public Group newGroup { get; set; }
        public RelGroupsStudyfield groupStudyField { get; set; }
        public GroupMembership groupMemberShip { get; set; }
        public StudyField studyField { get; set; }

        public List<string> fieldName { get; set; }

        public bool isExist { get; set; }

    }
}