using CAOSelect.BusinessLogic;
using CAOSelect.Data;
using CAOSelect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewCourses()
        {
            //Getting the course data from databases
            CourseDAO courseData = new CourseDAO();
            List<CAOSubject> courses = courseData.getCourse();
            //Getting list of all colleges
            List<String> colleges = courseData.getThirdLevelInstitute();

            //Adding colleges and courses to viewbag
            ViewBag.colleges = colleges;
            ViewBag.courses = courses;
            return View();
        }

        public IActionResult Search(String searchString, string college, string level)
        {
            //Getting all course data from Database
            CourseDAO courseData = new CourseDAO();
            List<CAOSubject> courses = courseData.getCourse();

            List<CAOSubject> subjects = new List<CAOSubject>();
            List<String> colleges = courseData.getThirdLevelInstitute();

            //Lists of items from different filters
            List<CAOSubject> searchSubjects = new List<CAOSubject>();
            List<CAOSubject> levelSubjects = new List<CAOSubject>();
            List<CAOSubject> collegesubjects = new List<CAOSubject>();

            int lvl = 0;

            //parsing string to int
            if (level != null) {
                lvl = Int32.Parse(level);
            }


            //If the action is search
            if (searchString != null)
            {

                foreach (var c in courses)
                {
                    //Seeing if course contains the searchString
                    if (c.CourseName.Contains(searchString))
                    {
                        searchSubjects.Add(c);
                    }
                }

            }
            else
            {
                searchSubjects = courses;
            }

            //What to do if action is college

            if (college != null)
            {
                //Checking to see if subject list has any items in it

                foreach (var c in courses)
                {
                    //Checking to see if courses college equal to the searchstring value
                    if (c.ThirdLevelInstitute.Equals(college))
                    {
                        collegesubjects.Add(c);
                    }
                }
            }
            else
            {
                collegesubjects = courses;
            }


            if (level != null)
            {

                foreach (var c in courses)
                {
                    //Checking to see if courses college equal to teh searchstring value
                    if (c.Level == lvl)
                    {
                        levelSubjects.Add(c);
                    }
                }
            }
            else
            {
                levelSubjects = courses;
            }

            //Checking all subjects
            //https://social.msdn.microsoft.com/Forums/en-US/4b3fc81f-8e8d-478f-8fa5-2bb2c18fdf3d/compare-list-of-string-c?forum=aspcsharp
            subjects = searchSubjects.Intersect(collegesubjects).Intersect(levelSubjects).ToList();


            //Adding subject list and search item to string
            ViewBag.colleges = colleges;
            ViewBag.subjects = subjects;
            ViewBag.search = searchString;
            return View();
        }

        //Using an individual course
        [HttpGet]
        public IActionResult ViewIndividualCourse(String CourseID) {

            //calling a coursemanager to find individual course
            CourseManager cmang = new CourseManager();

            //finding the subject by ID
            CAOSubject course = cmang.getCoursebyID(CourseID);

            //Getting good similar courses
            List<CAOSubject> best = cmang.getSimilarCourses(course);

            ViewBag.best = best;

            return View(course);
        }



       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
