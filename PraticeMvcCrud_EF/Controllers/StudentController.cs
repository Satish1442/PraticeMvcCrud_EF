using PraticeMvcCrud_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace PraticeMvcCrud_EF.Controllers
{
    public class StudentController : Controller
    {
        MyDbContext db=new MyDbContext();
        // GET: Student
        public ActionResult Index()
        {
            List<Student> students = new List<Student>();
            students=db.Students.ToList();
                ViewBag.Students = students;
            return View(students);
        }
        [HttpPost]
        public ActionResult AddStud(Student student )
        {
            if(ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                 return  RedirectToAction("Index");
            }
            return View(student);
          

        }

        public ActionResult AddStud() 
        {
            return View();
         }

        public ActionResult Edit(int id )
        {
            Student stu = db.Students.Find(id);
            return View(stu);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
          Student stu = db.Students.Find(student.Sno);
            if(ModelState.IsValid && stu != null)
            {
                stu.Name = student.Name;
                stu.Fee= student.Fee;
                db.Entry(stu).State=System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View(student);

        }

        public ActionResult Delete(int? id)
        {
            Student student = db.Students.Find( id);
            ViewBag.Message = "Do you Want to Delete the Student..?";
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Student stu=db.Students.Find(id);
            db.Students.Remove(stu);
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            Student student=db.Students.Find(id);
            return View(student);

        }

        [HttpPost]
        public ActionResult Details(int id)
        {
            // Get the student details from the database
            Student student = db.Students.Find(id);



            // Check if the model is valid
            if (ModelState.IsValid)
            {
                // Redirect to the Edit action with the student ID
                return RedirectToAction("Edit", new { id = id });
            }

            return View(student);
        }



    }


    }
