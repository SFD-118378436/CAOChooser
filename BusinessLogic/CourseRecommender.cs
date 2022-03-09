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
            //declaring variable to be used in loop
            int absoluteworst = 0;

            //finding the worst values
            int[] numbers = new int[] { a, p, c, inter };

            foreach(var n in numbers)
            {
                if(n < 0)
                {
                    int differenceworst = numbers.Min();

                     absoluteworst = Math.Abs(differenceworst);
                  
                }
            }


            //adding absolute worst to each
            p += absoluteworst;
            a += absoluteworst;
            c += absoluteworst;
            inter += absoluteworst;

            //adding up all values of the values of the items
            int totalvalue = a + p + c + inter;

            //https://stackoverflow.com/questions/661028/how-can-i-divide-two-integers-to-get-a-double
            //getting the proportional make up
            float analyticalproportion = (float)a / (float)totalvalue;
            float problemproportion = (float)p / (float)totalvalue;
            float creativeproportion = (float)c / (float)totalvalue;
            float interproportion = (float)inter / (float)totalvalue;

            //creating a course 
            CAOSubject bestcourse = new CAOSubject();

            //Variable to store difference
            float differenceBest = new float();

            //looping through all courses to find similar courses
            foreach (var course in courses)
            {
                //getting the proportion of each course
                float aprop = (float)course.analytical / (float)100;
                float pprop = (float)course.problemsolving / (float)100;
                float cprop = (float)course.creative / (float)100;
                float iprop = (float)course.interpersonal / (float)100;

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
