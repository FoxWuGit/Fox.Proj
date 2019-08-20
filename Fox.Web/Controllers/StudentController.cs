using Fox.Model.ViewModel.Student;
using Fox.Repository.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fox.Web.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository repository = new StudentRepository();
        public ActionResult Index()
        {
            repository.SelectStudent();
            return View();
        }
        [HttpPost]
        public ActionResult Index(IndexReqVm vm)
        {
            repository.SelectStudent(vm);
            IndexReqVm resVM = new IndexReqVm();
            return View();
        }
    }
}