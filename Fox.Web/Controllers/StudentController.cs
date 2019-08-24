using Fox.Model.Config;
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

        /// <summary>
        /// 首頁及查詢
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ModelResult model = new ModelResult(SystemCodes.Codes.DBError);
            repository.SelectStudent();

            IndexVM resVM = new IndexVM();
            return View(resVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IndexVM vm)
        {
            if (ModelState.IsValid)
            {

            }
            repository.SelectStudent(vm);
            IndexVM resVM = new IndexVM();
            return View(resVM);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public ActionResult Insert()
        {
            return View();
        }
    }
}