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
            viewModel.AddStudentVM.SetCourseItems(CourseRepository.GetAll());
            viewModel.AddStudentVM.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.AddStudentVM.Courses = new List<Course>();

            foreach (var id in studentVM.AddStudentVM.SelectedCourseIds)
                studentVM.AddStudentVM.Courses.Add(CourseRepository.Get(id));

            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    FirstName = studentVM.AddStudentVM.FirstName,
                    LastName = studentVM.AddStudentVM.LastName,
                    GPA = (decimal)studentVM.AddStudentVM.GPA,
                    Major = MajorRepository.Get(studentVM.AddStudentVM.MajorId),
                    Courses = studentVM.AddStudentVM.Courses,
                    Address = new Address()
                };
                StudentRepository.Add(student);
                return RedirectToAction("List");
            }
            else
            {
                return View(studentVM);
            }

            

        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var student = StudentRepository.Get(id);
            var viewModel = new StudentVM();

            viewModel.AddStudentVM.StudentId = student.StudentId;
            viewModel.AddAddressVM.StudentId = student.StudentId;
            viewModel.AddStudentVM.FirstName = student.FirstName;
            viewModel.AddStudentVM.LastName = student.LastName;
            viewModel.AddStudentVM.GPA = student.GPA;
            viewModel.AddAddressVM.Address = student.Address;
            viewModel.AddStudentVM.MajorId = student.Major.MajorId;

            viewModel.AddStudentVM.Courses = student.Courses;


            viewModel.AddStudentVM.SetCourseItems(CourseRepository.GetAll());
            viewModel.AddStudentVM.SetMajorItems(MajorRepository.GetAll());
            viewModel.AddAddressVM.SetStateItems(StateRepository.GetAll());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditStudent(AddStudentVM addStudentVM)
        {
            var studentVM = new StudentVM();
            studentVM.AddStudentVM.SelectedCourseIds = addStudentVM.SelectedCourseIds;

            studentVM.AddStudentVM.Courses = new List<Course>();
            foreach (var id in studentVM.AddStudentVM.SelectedCourseIds)
                studentVM.AddStudentVM.Courses.Add(CourseRepository.Get(id));



            var student = new Student
            {
                StudentId = addStudentVM.StudentId,
                FirstName = addStudentVM.FirstName,
                LastName = addStudentVM.LastName,
                GPA = (decimal)addStudentVM.GPA,
                Major = MajorRepository.Get(addStudentVM.MajorId),
                Courses = studentVM.AddStudentVM.Courses
            };
            StudentRepository.Edit(student);
            return RedirectToAction("List");


        }



        [HttpPost]
        public ActionResult EditAddress(AddAddressVM addAddressVM)
        {

            var studentVM = new StudentVM();
            studentVM.AddStudentVM.StudentId = addAddressVM.StudentId;
            studentVM.AddAddressVM.StudentId = addAddressVM.StudentId;

            var student = StudentRepository.Get(addAddressVM.StudentId);
            studentVM.AddStudentVM.FirstName = student.FirstName;
            studentVM.AddStudentVM.LastName = student.LastName;
            studentVM.AddStudentVM.GPA = student.GPA;
            studentVM.AddStudentVM.MajorId = student.Major.MajorId;
            studentVM.AddStudentVM.Courses = new List<Course>();
            studentVM.AddStudentVM.Courses = student.Courses;
            studentVM.AddStudentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.AddStudentVM.SetMajorItems(MajorRepository.GetAll());
            studentVM.AddAddressVM.SetStateItems(StateRepository.GetAll());
            studentVM.AddAddressVM.Address = addAddressVM.Address;

            StudentRepository.SaveAddress(studentVM.AddAddressVM.StudentId, studentVM.AddAddressVM.Address);
            return RedirectToAction("List");

        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var student = StudentRepository.Get(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
    }

}
