using SampleApp.DAL;
using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleApp.Controllers
{
    public class StudentController : Controller
    {
        StudentDAL studentDAL = new StudentDAL();
        // GET: Student
        public ActionResult List()
        {
            var data = studentDAL.GetStudents();
            return View(data);
        }
        public ActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewUser(StudentModel student)
        {
            if (studentDAL.InsertStudent(student))
            {
                TempData["InsertMsg"] = "Student registered successfully";
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErrorMsg"] = "This student is already registered ";
            }
            return View();
        }
        public ActionResult Details(int StudentId)
        {
            var data = studentDAL.GetStudents().Find(a => a.StudentId == StudentId);
            return View(data);
        }
        public ActionResult Edit(int StudentId)
        {
            var data = studentDAL.GetStudents().Find(a => a.StudentId == StudentId);
            return View(data);
        }



        
        [HttpPost]
        public ActionResult Edit(StudentModel student)
        {
            if (studentDAL.UpdateStudent(student))
            {
                TempData["UpdateMsg"] = "Student details updated successfully";
                return RedirectToAction("List");
            }
            else
            {
                TempData["UpdateErrorMsg"] = "Student details cannot be updated. This student already exists!";
            }
            return View();
        }


        public ActionResult Delete(int StudentId)
        {
            int r = studentDAL.DeleteStudent(StudentId);
            if (r>0)
            {
                TempData["DeleteMsg"] = "<script>alert('Student details deleted successfully')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["DeleteErrorMsg"] = "<script>alert('Student details not deleted')</script> ";
            }
            return View();
        }
        
    }
}