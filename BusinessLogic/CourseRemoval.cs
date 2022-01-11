using CAOSelect.Data;
using CAOSelect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.BusinessLogic
{
    public class CourseRemoval
    {
        //Gathering the data from db
        RequiredSubjectDAO rData = new RequiredSubjectDAO();
        CourseDAO cData = new CourseDAO();

        //using course manager
        CourseManager cmang = new CourseManager();

        public List<CAOSubject> RemoveBySubjects(List<LCSubjectList> subjects)
        {

            //Getting a list of all courses
            List<CAOSubject> originalCourses = cData.getCourse();

            //List of Required Subjects Details
            List<RequiredSubject> reqSubjects = rData.getRequiredSubjects();

            //looping through the requirements for subjects
            foreach (var r in reqSubjects)
            {
                bool val = IsSubjectPresent(r, subjects);
                //if the method returns false than remove from the list
                if(val == false)
                {
                    CAOSubject course = cmang.getCoursebyID(r.course.CourseID);
                    //using linq to remove all courses with matching courseIDs.
                    //https://stackoverflow.com/questions/22901225/how-to-remove-a-specific-object-from-a-listt
                    originalCourses.RemoveAll(x => x.CourseID == course.CourseID); 
                }
            }
        
            //returning all remaining courses
            return originalCourses;
        }

    public bool IsSubjectPresent(RequiredSubject r, List<LCSubjectList> subjects)
        {
        //Looping through each subject to see if it can be found
        foreach(var s in subjects)
        {
            //if the subject is found in both lists return true
            if(r.subject.SubjectName == s.SubjectName)
            {
                    if (r.Level == s.Level)
                    {
                        return true;
                    } else if (r.Level  == ""){
                        return true;
                    }
            } 
        }
        return false;
        }

    }


}
