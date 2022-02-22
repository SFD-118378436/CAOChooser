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

        public void DeleteCourse(String CourseID)
        {
            using (var db = DbHelper.GetConnection())
            {
                //creating a list 
                String query = "DELETE FROM CAOSUBJECT WHERE COURSEID='" + CourseID + "';";
                 db.Query(query);
            }
        }

        public void AddCourse(CAOSubject course)
        {
            using(var db = DbHelper.GetConnection()){

                String query = "INSERT INTO CAOSUBJECT (COURSEID,COURSENAME,COURSEDESCRIPTION,LEVEL,ThirdLevelInstitute,creative,problemsolving,analytical,interpersonal) " +
                    "VALUES('" + course.CourseID + "','" + course.CourseName + "','" + course.CourseDescription + "'," + course.Level + ",'" + course.ThirdLevelInstitute + "',"
                    + course.creative + "," + course.problemsolving + "," + course.analytical + "," + course.interpersonal + ");";
                db.Query(query);
            }
        }

        public void EditCourse(String id, CAOSubject course)
        {
            using (var db = DbHelper.GetConnection())
            {

                String q2 = "UPDATE CAOSUBJECT SET COURSEID='" + course.CourseID + "', COURSENAME='" + course.CourseName + "', COURSEDESCRIPTION='" + course.CourseDescription +
                     "',LEVEL=" + course.Level + ",ThirdLevelInstitute='" + course.ThirdLevelInstitute + "',creative=" + course.creative + ",problemsolving=" + course.problemsolving +
                     ",analytical=" + course.analytical + ",interpersonal=" + course.interpersonal + "WHERE COURSEID='" + id + "';";

                db.Query(q2);
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

