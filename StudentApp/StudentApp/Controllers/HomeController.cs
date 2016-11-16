using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class HomeController : Controller
    {
        SchoolAppEntities1 db = new SchoolAppEntities1();

        // GET: Home
        public ActionResult Index()
        {
            var Schoolinfo = from stud_detail in db.Students
                           join stuNcours in db.StuCourses on stud_detail.Id equals stuNcours.StudentID
                           join cour_detail in db.Courses on stuNcours.CourseID equals cour_detail.ID
                           select new StudentApp.Models.School
                           {
                               SI = stud_detail,
                               CI = cour_detail

                           };

            return View(Schoolinfo);
        }

        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "Id", "StudentName");
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "CourseName");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,CourseID")] StuCourse schoolinfo)
        {
            if (ModelState.IsValid)
            {
                //schoolinfo.Misc = "1";
                db.StuCourses.Add(schoolinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

          
            return View(schoolinfo);
        }

    }
}