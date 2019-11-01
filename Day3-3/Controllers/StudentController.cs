using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day3_3.Models;

namespace Day3_3.Controllers
{
    public class StudentController : Controller
    {
        ITI38 db = new ITI38();
        // GET: Student
        public ActionResult Index()
        {
            List<Student> students = db.Students.Include("Department").ToList<Student>();
            return View(students);
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    ViewBag.id = 10;
        //    List<Department> depts = db.Departments.ToList<Department>();
        //    SelectList deptsl = new SelectList(depts, "DeptNo", "DeptName");
        //    ViewBag.deptno = deptsl;
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(Student std)
        //{
        //    db.Students.Add(std);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public ActionResult Create()
        {
            List<Department> Depts = db.Departments.ToList<Department>();
            SelectList deptsl = new SelectList(Depts, "DeptNo", "DeptName");
            ViewBag.DeptNo = deptsl;
            ViewBag.btntitle = "Create";
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="Id")]Student std)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(std);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Department> Depts = db.Departments.ToList<Department>();
            SelectList deptsl = new SelectList(Depts, "DeptNo", "DeptName",std.DeptNo);
            ViewBag.DeptNo = deptsl;
            ViewBag.btntitle = "Create";
            return View(std);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.btntitle = "Edit";

            Student std = db.Students.FirstOrDefault(a => a.Id == id);
            if (std == null)
                return HttpNotFound("Student does not exist");
            List<Department> depts = db.Departments.ToList<Department>();
            SelectList deptsl = new SelectList(depts, "DeptNo", "DeptName", std.DeptNo);
            ViewBag.DeptNo = deptsl;
            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(Student newStudent)
        {
            Student oldStd = db.Students.FirstOrDefault(a => a.Id == newStudent.Id);
            oldStd.Name = newStudent.Name;
            oldStd.Age = newStudent.Age;
            oldStd.DeptNo = newStudent.DeptNo;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult delete(int id)
        {
            Student std = db.Students.FirstOrDefault(a => a.Id == id);
            return View(std);
        }
        [HttpPost]
        public ActionResult delete([Bind(Include ="Id")]Student std)
        {
            Student dstd = db.Students.FirstOrDefault(a => a.Id == std.Id);
            db.Students.Remove(dstd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CheckUserName(string UserName,int? Id)
        {
           Student std= db.Students.FirstOrDefault(a => a.UserName == UserName);
            if (std == null){
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details(int id)
        {

            Student std = db.Students.FirstOrDefault(a => a.Id == id);

            return PartialView(std);
        }



        public ActionResult GetStudentByDept()
        {
            List<Department> Departments = db.Departments.ToList<Department>();
            SelectList depts = new SelectList(Departments, "DeptNo", "DeptName");

            ViewBag.DeptNo = depts;
           List<Student> Students = db.Students.ToList<Student>();

            return View(Students);
        }

        public ActionResult getstdindept(int? deptno)
        {
            List<Student> Students;
            if (deptno != null)
                Students = db.Students.Where(a => a.DeptNo == deptno).ToList<Student>();
            else
                Students = db.Students.ToList<Student>();

            return PartialView(Students);
        }

        public ActionResult GetAllDept()
        {
            ViewBag.DeptNo = new SelectList(db.Departments.ToList<Department>(), "DeptNo", "DeptName");

            return View();
        }
        public ActionResult getstbydept(int? id)
        {
            List<Student> Students = db.Students.Where(a => (a.DeptNo == id || a.DeptNo==null) ).ToList<Student>();

            return PartialView(Students);
        }
        [HttpPost]
        public ActionResult removefromdept(Dictionary<string,bool> dept,int DeptNo)
        {
            foreach(KeyValuePair<string,bool> kv in dept)
            {
                if (kv.Value == false)
                {
                    int id = int.Parse(kv.Key);
                   Student std= db.Students.FirstOrDefault(a => a.Id == id);
                    std.CPassword = std.Password;
                    std.DeptNo = null;
                    db.SaveChanges();
                }
                else
                {
                    int id = int.Parse(kv.Key);
                    Student std = db.Students.FirstOrDefault(a => a.Id == id);
                    std.CPassword = std.Password;
                    std.DeptNo = DeptNo;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("GetAllDept");
        }

    }
}