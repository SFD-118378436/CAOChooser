using CAOSelect.Data;
using CAOSelect.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAOSelect.Controllers
{
    public class PsychometricController : Controller
    {
        public IActionResult Index()
        {
            //Calling the Question Database and getting the list of Questions and Interests
            QuestionDAO qdata = new QuestionDAO();
            List<Question> questions = qdata.getQuestions();
            List<String> interests = qdata.getInterests();

            //Adding th equestions and Interests to a Viewbag
            ViewBag.questions = questions;
            ViewBag.interests = interests;

            return View();
        }

        public IActionResult Recommended(int R, int I, int A, int C, int S, int E)
        {

            //BiggestValue
            String max = "Realistic";

            //Comparing against others
            if(I > R)
            {
                max = "Investigative";
            }

            if (A > I)
            {
                max = "Artistic";
            }

            if (C > A)
            {
                max = "Conventional";
            }

            if (E > C)
            {
                max = "Enterprising";
            }

            if (S > E)
            {
                max = "Social";
            }

            CareerDAO careerdata = new CareerDAO();
            List<Career> careers = careerdata.getCareersByInterestArea(max);

            return View(careers);
        }
    }
}   
