using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
            
            if(studentVM.Student.Courses.Count == 0)
            {
                ModelState.AddModelError("Courses", "Please enter at least one course");
            }

            if(ModelState.IsValid)
            {         
                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }

            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                return View("Add", studentVM);
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = new StudentVM();
            viewModel.Student = StudentRepository.Get(id);
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

       [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            if (studentVM.Student.Courses.Count == 0)
            {
                ModelState.AddModelError("Courses", "Please enter at least one course");
            }


            if (ModelState.IsValid)
            {
                StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address); //now it works?
                StudentRepository.Edit(studentVM.Student); // edit works

                return RedirectToAction("List");
            }

            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                return View("Edit", studentVM);
            }
                
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var viewModel = new StudentVM();
            viewModel.Student = StudentRepository.Get(id);
            //viewModel.SetCourseItems(CourseRepository.GetAll());
            //viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(StudentVM student) // works, but can't delete original 3 bc list is readonly
        {
            StudentRepository.Delete(student.Student.StudentId);

            return RedirectToAction("List");
        }
    }
}