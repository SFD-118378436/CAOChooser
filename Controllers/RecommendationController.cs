using CAOSelect.BusinessLogic;
using CAOSelect.Data;
using CAOSelect.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CAOSelect.Controllers
{
    public class RecommendationController : Controller
    {

        //Gathering all subjects from DAO
        SubjectDAO subjectData = new SubjectDAO();
        List<LCSubject> subjects = new List<LCSubject>();

        //Creating a List of College Course
        List<CAOSubject> courses = new List<CAOSubject>();
        List<LCSubjectList> lists = new List<LCSubjectList>();


        //Creating an int to be accessed accross multiple actions 
        int nsubjects;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddSubjects()
        {
            subjects = subjectData.getSubjects();
            //Adding subjects to view
            ViewBag.subjects = subjects;
            return View();
        }

        public IActionResult LCSubjects(string numSubjects)
        {
            //Gathering all subjects from DAO
            subjects = subjectData.getSubjects();

            //converting String to integer
            nsubjects = Convert.ToInt32(numSubjects);
          
       
            //Adding subjects to viewbag
            ViewBag.subjects = subjects;
            ViewBag.num = nsubjects;
            return View();
        }

        public IActionResult YourRecommendedCourse(int creative, int problemsolving, int analytical, int interpersonal)
        {
            //Getting rid of negative figures
            if(creative < 0) {creative = 0;} 
            if(problemsolving < 0) { problemsolving = 0; }
            if (analytical < 0) { analytical = 0; }
            if (interpersonal < 0) { interpersonal = 0; }

            //Creating a prevention method to ensure that we do not get a dividde by zero error
            if (creative <= 0 && problemsolving <= 0 && analytical <=0 && interpersonal <= 0)
            {
                creative = 1;
            }

            //getting the list of random courses
            //https://bartwullems.blogspot.com/2020/03/aspnet-coreusing-tempdata-results-in.html
            //https://ucc.instructure.com/courses/39791/files/4107180?module_item_id=1199744
            List<CAOSubject> courses = JsonSerializer.Deserialize<List<CAOSubject>>(HttpContext.Session.GetString("courses") as String);
            //calling the course recommender class
            CourseRecommender crec = new CourseRecommender();
            CourseManager cman = new CourseManager();

            //Getting Subject from course recommender
            CAOSubject rcourse = crec.CourseRecommendation(analytical, problemsolving, creative, interpersonal, courses);

            //Getting good similar courses
            List<CAOSubject> best = cman.getSimilarCourses(rcourse);

            ViewBag.best = best;
            ViewBag.PerfCourse = rcourse;

            return View();

        }

        public IActionResult ChooseCourses(String subject1, String level1, String subject2, String level2, String subject3, String level3, String subject4, String level4, String subject5, String level5, String subject6, String level6, String subject7, String level7, String subject8, String level8, String subject9, String level9, String subject10, String level10, String subject11, String level11, String subject12, String level12)
        {

            //placing string into list
            LCSubjectList l1 = new LCSubjectList(subject1, level1);
            lists.Add(l1);

            LCSubjectList l2 = new LCSubjectList(subject2, level2);
            lists.Add(l2);

            LCSubjectList l3 = new LCSubjectList(subject3, level3);
            lists.Add(l3);

            LCSubjectList l4 = new LCSubjectList(subject4, level4);
            lists.Add(l4);

            LCSubjectList l5 = new LCSubjectList(subject5, level5);
            lists.Add(l5);

            LCSubjectList l6 = new LCSubjectList(subject6, level6);
            lists.Add(l6);

            LCSubjectList l7 = new LCSubjectList(subject7, level7);
            lists.Add(l7);

            LCSubjectList l8 = new LCSubjectList(subject8, level8);
            lists.Add(l8);

            LCSubjectList l9 = new LCSubjectList(subject9, level9);
            lists.Add(l9);

            LCSubjectList l10 = new LCSubjectList(subject10, level10);
            lists.Add(l10);

            LCSubjectList l11 = new LCSubjectList(subject11, level11);
            lists.Add(l11);

            LCSubjectList l12 = new LCSubjectList(subject12, level12);
            lists.Add(l12);

            CourseRemoval courseRemoval = new CourseRemoval();
            List<CAOSubject> subjects = courseRemoval.RemoveBySubjects(lists);
            
            //Calling the random class
            Random rnd = new Random();

            //creating a list to store randoms
            List<CAOSubject> rndcourses = new List<CAOSubject>();

            for(int i = 0; i < 20; i++) { 
                //Getting a random number from the list courses
                int index = rnd.Next(1,subjects.Count);
                //getting the relvant course at the random index
                CAOSubject rndcourse = subjects.ElementAt(index);
                //Adding to list
                rndcourses.Add(rndcourse);
            }

            ViewBag.Courses = rndcourses;

            try
            {
            //code found at http://www.binaryintellect.net/articles/8e64d05b-ab2e-45f6-b7f5-b8a90168915e.aspx
           //also uses https://ucc.instructure.com/courses/39791/files/4107180?module_item_id=1199744
                //TempData["courses"] = JsonSerializer.Serialize(subjects);
                HttpContext.Session.SetString("courses", JsonSerializer.Serialize(subjects));

                return View();

            } catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return View();
        }
    }
}
