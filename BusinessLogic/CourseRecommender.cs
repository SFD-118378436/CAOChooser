using CAOSelect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.BusinessLogic
{
    public class CourseRecommender
    {
        public CAOSubject CourseRecommendation(int a, int p, int c, int inter, List<CAOSubject> courses)
        {
            //adding up all values of the values of the items
            int totalvalue = a + p + c + inter;


            //getting the proportional make up
            float analyticalproportion = a / totalvalue;
            float problemproportion = p / totalvalue;
            float creativeproportion = c / totalvalue;
            float interproportion = inter / totalvalue;

            //creating a course 
            CAOSubject bestcourse = new CAOSubject();

            //Variable to store difference
            float differenceBest = new float();

            //looping through all courses to find similar courses
            foreach (var course in courses)
            {
                //getting the proportion of each course
                float aprop = course.analytical / 100;
                float pprop = course.problemsolving / 100;
                float cprop = course.creative / 100;
                float iprop = course.interpersonal / 100;

                //finding the absolute differences between values
                float differenceAn = Math.Abs(analyticalproportion - aprop);
                float differencePr = Math.Abs(problemproportion - pprop);
                float differenceIn = Math.Abs(interproportion - iprop);
                float differenceCr = Math.Abs(creativeproportion - cprop);

                //Getting the total difference value
                float TotalDifference = differenceAn + differencePr + differenceIn + differenceCr;
                if (differenceBest != 0) { 
                //updating the best course to return
                    if (differenceBest > TotalDifference)
                    {
                        differenceBest = TotalDifference;
                        bestcourse = course;

                    }
                }
                else
                {
                    //Code to update if value is null
                    differenceBest = TotalDifference;
                    bestcourse = course;

                }
            }
            return bestcourse;
        }
    }
}
