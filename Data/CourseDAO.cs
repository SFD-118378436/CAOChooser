using CAOSelect.Helpers;
using CAOSelect.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Data

{
    public class CourseDAO
    {
        
        public  List<CAOSubject>  getCourse()
        {
            // code found at https://ucc.instructure.com/courses/39791/files/4107181?module_item_id=1199745
            //Getting db connection used before
            using (var db = DbHelper.GetConnection())
            {
                //creating a list 
               return this.EditableItems = db.Query<CAOSubject>("SELECT * FROM CAOSUBJECT ORDER BY ThirdLevelInstitute, COURSEID;").ToList();
            }
        }
        public List<CAOSubject> EditableItems { get; set; }


        public List<String> getThirdLevelInstitute()
        {
            using (var db = DbHelper.GetConnection())
            {
                //creating a list 
                return  db.Query<String>("SELECT DISTINCT ThirdLevelInstitute FROM CAOSUBJECT ORDER BY ThirdLevelInstitute;").ToList();
            }
        }

        //Creating a method to gather all courses within a college
        public List<CAOSubject> getCoursesByCollege(String tli)
        {
            //Getting all the course data
            List<CAOSubject> courses = getCourse();
            //store for specific courses
            List<CAOSubject> speccourses = new List<CAOSubject>();

            //looping through all courses and seeing if they match passed in string
            foreach(var c in courses)
            {
                if(c.ThirdLevelInstitute == tli)
                {
                    //adding course to list
                    speccourses.Add(c);
                }
            }
            //returning list
            return speccourses;

        }
    }
}

