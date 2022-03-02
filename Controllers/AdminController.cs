using CAOSelect.BusinessLogic;
using CAOSelect.Data;
using CAOSelect.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CAOSelect.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            CourseDAO cdao = new CourseDAO();

            ViewBag.colleges = cdao.getThirdLevelInstitute();
            return View();
        }

        public IActionResult Registration(string Username, string Password, string ThirdLevelInstitute)
        {
            //accessing admin login
            AdminLogin alogin = new AdminLogin();
            AdminDAO adData = new AdminDAO();

            byte[] salt = new byte[128 / 8];

            //https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-3.1
           // using (var rngCsp = new RNGCryptoServiceProvider())
            //{
             //   rngCsp.GetNonZeroBytes(salt);
           // }

            string hash = alogin.HashedPassword(Password, salt);


            //saving as new Admin

            Admin newAdmin = new Admin();
            newAdmin.Username = Username;
            newAdmin.PasswordHash = hash;
            //Translating from bytes to string
            newAdmin.UserSalt = Encoding.ASCII.GetString(salt);
            newAdmin.ThirdLevelInstitution = ThirdLevelInstitute;

            adData.insertAdmin(newAdmin);

            return RedirectToAction("Index");
        }

        public IActionResult ViewCourses()
        {
            //getting the list of random courses
            //https://bartwullems.blogspot.com/2020/03/aspnet-coreusing-tempdata-results-in.html
            //https://ucc.instructure.com/courses/39791/files/4107180?module_item_id=1199744
            Admin loggedadmin = JsonSerializer.Deserialize<Admin>(HttpContext.Session.GetString("admin") as String);
            //Getting CourseDAO
            CourseDAO cdata = new CourseDAO();
            List<CAOSubject> courses = cdata.getCoursesByCollege(loggedadmin.ThirdLevelInstitution);

            return View(courses);
        }


        public IActionResult Login(string Username, string Password)
        {

            AdminDAO addata = new AdminDAO();
            AdminLogin alogin = new AdminLogin();

            //getting admin by username
            Admin loginAdmin = addata.getAdminbyUsername(Username);

            //checking if the hashed passwords are the same
            string hash = alogin.HashedPassword(Password, Encoding.ASCII.GetBytes(loginAdmin.UserSalt));
            if (hash == loginAdmin.PasswordHash)
            {

                //code found at http://www.binaryintellect.net/articles/8e64d05b-ab2e-45f6-b7f5-b8a90168915e.aspx
                //also uses https://ucc.instructure.com/courses/39791/files/4107180?module_item_id=1199744

                HttpContext.Session.SetString("admin", JsonSerializer.Serialize(loginAdmin));

                return RedirectToAction("ViewCourses");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }


        // GET: AdministrationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdministrationController/Create
        public ActionResult CreateCourse()
        {
            return View();
        }

        // POST: AdministrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCourse([Bind("CourseID,CourseName,CourseDescription,Level,ThirdLevelInstitute,creative,problemsolving,analytical,interpersonal")] CAOSubject subject)
        {
            try
            {
                //Accessing courseData
                CourseDAO cdata = new CourseDAO();

                //Adding course to the the Db
                cdata.AddCourse(subject);
                //Returning to ViewCourses List
                return RedirectToAction(nameof(ViewCourses));
            }
            catch
            {
                return View();
            }
        }


        //[httppost]
        //public iactionresult createrequiredsubject([bind] requiredsubject rsubject)
        //{
        //    requiredsubjectdao rdata = new requiredsubjectdao();
        //    rdata.

        //}



        // GET: AdministrationController/Edit/5
        public ActionResult EditCourse(String id)
        {

            //calling a coursemanager to find individual course
            CourseManager cmang = new CourseManager();

            //finding the subject by ID
            CAOSubject course = cmang.getCoursebyID(id);
            return View(course);
        }

        // POST: AdministrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCourse(String CourseID, [Bind("CourseID,CourseName,CourseDescription,Level,ThirdLevelInstitute,creative,problemsolving,analytical,interpersonal")] CAOSubject subject)
        {
            try
            {
                CourseDAO cdata = new CourseDAO();

                cdata.EditCourse(CourseID,subject);
                return RedirectToAction(nameof(ViewCourses));
            }
            catch
            {
                CourseManager cmang = new CourseManager();

                //finding the subject by ID
                CAOSubject course = cmang.getCoursebyID(CourseID);
                return View(course);
            }
        }

        // GET: AdministrationController/Delete/5
        public ActionResult DeleteCourse(String id)
        {
            //calling a coursemanager to find individual course
            CourseManager cmang = new CourseManager();

            //finding the subject by ID
            CAOSubject course = cmang.getCoursebyID(id);
            return View(course);
        }

        // POST: AdministrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCourse(String id, [Bind("CourseID,CourseName,CourseDescription,Level,ThirdLevelInstitute,creative,problemsolving,analytical,interpersonal")] CAOSubject subject)
        {
            try
            {
                CourseDAO cdata = new CourseDAO();

                //finding the subject by ID
                cdata.DeleteCourse(id);

                return RedirectToAction(nameof(ViewCourses));
            }
            catch
            {
                return View();
            }
        }

    }
}
