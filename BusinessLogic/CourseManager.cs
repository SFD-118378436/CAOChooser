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
    }
}
