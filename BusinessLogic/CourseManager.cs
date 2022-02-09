using CAOSelect.Data;
using CAOSelect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.BusinessLogic
{
    public class CourseManager
    {
        CourseDAO courseData = new CourseDAO();
        

        public CAOSubject getCoursebyID(String courseID)
        {
            List<CAOSubject> courses = courseData.getCourse();
           

            CAOSubject subject = new CAOSubject();

            foreach(var c in courses)
            {
                if(c.CourseID == courseID)
                {
                    subject = c;
                }
            }

            return subject;
        }


        public List<CAOSubject> getSimilarCourses(CAOSubject c)
        {
            //Getting Ratio Values
            int analytical = c.analytical;
            int interpersonal = c.interpersonal;
            int creative = c.creative;
            int problemsolving = c.problemsolving;

            //Getting CaoCourses
            List<CAOSubject> courses = courseData.getCourse();

            //remove course brought in
            //https://stackoverflow.com/questions/22901225/how-to-remove-a-specific-object-from-a-listt
            courses.RemoveAll(x => x.CourseID == c.CourseID);

            //Creating an empty list
            List<CAOSubject> bestcourses = new List<CAOSubject>();

            //variables to hold top three similar courses
            CAOSubject first = new CAOSubject();
            CAOSubject second = new CAOSubject();
            CAOSubject third = new CAOSubject();

            //variable to hold the values for each of these courses
            int firstdiff = 0;
            int seconddiff = 0;
            int thirddiff = 0;

            //Looping through all courses
            foreach(var course in courses)
            {
                //finding values for total compared to original figure
                int a = Math.Abs(course.analytical - analytical);
                int i = Math.Abs(course.interpersonal - interpersonal);
                int p = Math.Abs(course.problemsolving - problemsolving);
                int cr = Math.Abs(course.creative - creative);

                int total = a + i + p + cr - 1;
                //Setting the top three courses

                if (total < firstdiff || firstdiff == 0)
                {
                    firstdiff = total;
                    first = course;
                }else if (total < seconddiff || seconddiff == 0)
                {
                    seconddiff = total;
                    second = course;
                } else if(total < thirddiff || thirddiff == 0) 
                    { 
                    thirddiff = total;
                    third = course;
                }
                
            }

            //Adding values into list
            bestcourses.Add(first);
            bestcourses.Add(second);
            bestcourses.Add(third);

            return bestcourses;
        }
     
    }
}
