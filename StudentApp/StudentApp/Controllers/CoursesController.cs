using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentApp.Models;


namespace StudentApp.Controllers
{
    public class CoursesController : Controller
    {
        SchoolAppEntities1 db = new SchoolAppEntities1();

        // GET: Courses
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        public ActionResult Details(int? id)
        {
            var showStud = from stuNcours in db.StuCourses
                                 join stud_detail in db.Students on stuNcours.StudentID equals stud_detail.Id
                                 where stuNcours.CourseID == id
                                 select stud_detail;

            var showCour = (from cour_detail in db.Courses
                            where cour_detail.ID == id
                            select cour_detail).FirstOrDefault();


            CourseInfo newDataInfo = new CourseInfo();
            newDataInfo.SID = showStud.ToList();
            newDataInfo.CID = showCour;
        
            return View(newDataInfo);
        }

        public ActionResult Create()
        {
            return View();
        }
        // POST: CustomerHistory/Create
        [HttpPost]

        public ActionResult Create([Bind(Include = "ID,CourseName,CourseDesc")] Cours courseinfo)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(courseinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseinfo);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cours courseinfo = db.Courses.Find(id);
            if (courseinfo == null)
            {
                return HttpNotFound();
            }

            return View(courseinfo);
        }

        // POST: CustomerHistory/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,CourseName,CourseDesc")] Cours courseinfo)
        {
            if (ModelState.IsValid)
            {

                db.Entry(courseinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseinfo);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours courseinfo = db.Courses.Find(id);
            if (courseinfo == null)
            {
                return HttpNotFound();
            }
            return View(courseinfo);
        }

        // POST: CustomerHistory/Delete/5
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            Cours courseinfo = db.Courses.Find(id);
            db.Courses.Remove(courseinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }



}
