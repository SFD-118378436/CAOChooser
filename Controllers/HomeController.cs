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
            CourseDAO courseData = new CourseDAO();
            List<CAOSubject> courses = courseData.getCourse();
            List<String> colleges = courseData.getThirdLevelInstitute();

            ViewBag.colleges = colleges;
            ViewBag.courses = courses;
            return View();
        }

        public IActionResult Search(String searchString, string action)
        {
            //Getting all course data from Database
            CourseDAO courseData = new CourseDAO();
            List<CAOSubject> courses = courseData.getCourse();

            List<CAOSubject> subjects = new List<CAOSubject>();

            //If the action is search
            if (action == "search")
            {    
                foreach (var c in courses)
                {
                    //Seeing if course contains the searchString
                    if (c.CourseName.Contains(searchString))
                    {
                        subjects.Add(c);
                    }
                }
                //What to do if action is college
            } else if(action == "collegeFilter")
            {
                foreach (var c in courses)
                {
                    //Checking to see if courses college equal to teh searchstring value
                    if (c.ThirdLevelInstitute.Equals(searchString))
                    {
                        subjects.Add(c);
                    }
                }
            } 

            //Adding subject list and search item to string
            ViewBag.subjects = subjects;
            ViewBag.search = searchString;
            return View();
        }

        //Testing to use json and AJAX search bars
        public JsonResult searchbar(string searchString)
        {
            //Getting all course data from Database
            CourseDAO courseData = new CourseDAO();
            List<CAOSubject> courses = courseData.getCourse();

            List<CAOSubject> subjects = new List<CAOSubject>();

            foreach (var c in courses) {
                if (c.CourseName.Contains(searchString))
                {
                    subjects.Add(c);
                }
            }

            return Json(subjects);
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
