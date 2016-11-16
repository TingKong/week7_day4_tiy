using StudentApp.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace StudentApp.Controllers
{
    public class StudInfoController : Controller
    {
        SchoolAppEntities1 db = new SchoolAppEntities1();

        // GET: StudInfo
        public ActionResult Index()
        {
            //var studinfo = from stud_detail in db.Students
            //               join stuNcours in db.StuCourses on stud_detail.Id equals stuNcours.StudentID
            //               join cour_detail in db.Courses on stuNcours.CourseID equals cour_detail.ID
            //               select new StudentApp.Models.StudInfo
            //               {
            //                   SI = stud_detail

            //               };

            return View(db.Students.ToList());

        }

        public ActionResult Details(int? id)
        {
            var studentCourses = from stuNcours in db.StuCourses
                                 join cour_detail in db.Courses on stuNcours.CourseID equals cour_detail.ID
                                 where stuNcours.StudentID == id
                                 select cour_detail;

            var showStud = (from stud in db.Students
                            where stud.Id == id
                            select stud).FirstOrDefault();


            studentwCourses newDataInfo = new studentwCourses();
            newDataInfo.CID = studentCourses.ToList();
            newDataInfo.SID = showStud;

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Student studentinfo = db.Students.Find(id);
            //if (studentinfo == null)
            //{
            //    return HttpNotFound();
            //}
            return View(newDataInfo);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create([Bind(Include = "Id,StudentName")] Student studentinfo)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(studentinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentinfo);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student studentinfo = db.Students.Find(id);
            if (studentinfo == null)
            {
                return HttpNotFound();
            }

            return View(studentinfo);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,StudentName")] Student studentinfo)
        {
            if (ModelState.IsValid)
            {

                db.Entry(studentinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentinfo);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student studentinfo = db.Students.Find(id);
            if (studentinfo == null)
            {
                return HttpNotFound();
            }
            return View(studentinfo);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            Student studentinfo = db.Students.Find(id);
            db.Students.Remove(studentinfo);
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

