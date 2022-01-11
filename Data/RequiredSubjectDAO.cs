using CAOSelect.Helpers;
using CAOSelect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using CAOSelect.BusinessLogic;

namespace CAOSelect.Data
{
    public class RequiredSubjectDAO
    {

        public List<RequiredSubject> getRequiredSubjects()
        {
            //Getting the course & subject manager
            CourseManager cmang = new CourseManager();
            SubjectManager smang = new SubjectManager();

            //Creating a list of required subjects 
            List<RequiredSubject> req1Subjects = new List<RequiredSubject>();

            // code found at https://ucc.instructure.com/courses/39791/files/4107181?module_item_id=1199745
            //Getting db connection used before
            using (var db = DbHelper.GetConnection())
            {
                //creating a list 
                 this.EditableItems = db.Query<ReqSubjectforDAO>("SELECT * FROM ReqSubjects;").ToList();
            }

            foreach (var e in EditableItems)
            {
                //creating a required subject object
                RequiredSubject r = new RequiredSubject();
                
                //Finding a course by ID and adding to r
                CAOSubject course = cmang.getCoursebyID(e.CourseID);
                r.course = course;

                //Finding a subject by ID and adding to r
                LCSubject sub = smang.getSubjectbyID(e.SubjectID);
                r.subject = sub;

                //letting the level equal
                r.Level = e.SubjectLevel;

                //Adding the item to req1Subjects
                req1Subjects.Add(r);
            }

            //returning the lsit of req1Subjects
            return req1Subjects;

        }
        public List<ReqSubjectforDAO> EditableItems { get; set; }
    }

    public class ReqSubjectforDAO
    {
        public String CourseID { get; set; }
        public int SubjectID { get; set; }

        public String SubjectLevel { get; set; }
    }
    
}
