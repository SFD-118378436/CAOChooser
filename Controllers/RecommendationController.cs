using CAOSelect.Data;
using CAOSelect.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Controllers
{
    public class RecommendationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddSubjects()
        {
            SubjectDAO subjectData = new SubjectDAO();
            List<LCSubject> subjects = subjectData.getSubjects();
    
            ViewBag.subjects = subjects;
            return View();
        }

        public IActionResult LCSubjects(string numSubjects)
        {
            SubjectDAO subjectData = new SubjectDAO();
            List<LCSubject> subjects = subjectData.getSubjects();

            int nsubjects = Convert.ToInt32(numSubjects);

            ViewBag.subjects = subjects;
            ViewBag.num = nsubjects;
            return View();
        }
    }
}
