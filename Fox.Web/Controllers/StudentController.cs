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
            IModelResult<IndexVM> reposResult = repository.SelectStudent();
            if (reposResult.IsOk)
            {
                return View(reposResult.ResultData);
            }
            else
            {
                //錯誤頁
                TempData["error"] = reposResult;
                return RedirectToAction("Message", "Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IndexVM vm)
        {
            IModelResult<IndexVM> reposResult;
            if (ModelState.IsValid)
            {
                reposResult = repository.SelectStudent(vm);
                if (reposResult.IsOk)
                {
                    return View(reposResult.ResultData);
                }
                else
                {
                    //錯誤頁
                    TempData["error"] = reposResult;
                    return RedirectToAction("Message", "Error");
                }
            }
            else
            {
                string msg = string.Join("/n", ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => string.Join("/n", x.Value.Errors.Select(y => y.ErrorMessage).ToList())));
                reposResult = new ModelResult<IndexVM>(SystemCodes.Codes.ModelValidError)
                {
                    SystemMessage = msg
                };
                TempData["error"] = reposResult;
                return RedirectToAction("Message", "Error");
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public ActionResult Insert()
        {
            InsertVM resVM = new InsertVM();
            return View(resVM);
        }
        [HttpPost]
        public ActionResult Insert(InsertVM vm)
        {
            IModelResult reposResult;
            if (ModelState.IsValid) {
                reposResult = repository.InsertStudent(vm);
                if (reposResult.IsOk)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //錯誤頁
                    TempData["error"] = reposResult;
                    return RedirectToAction("Message", "Error");
                }
            }
            else
            {
                string msg = string.Join("/n", ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => string.Join("/n", x.Value.Errors.Select(y => y.ErrorMessage).ToList())));
                reposResult = new ModelResult(SystemCodes.Codes.ModelValidError)
                {
                    SystemMessage = msg
                };
                TempData["error"] = reposResult;
                return RedirectToAction("Message", "Error");
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(string k)
        {
            IModelResult<SelectEditVM> reposResult;
            if (!string.IsNullOrEmpty(k.Trim()))
            {
                reposResult = repository.SelectStudent(k);
                if (reposResult.IsOk)
                {
                    return View(reposResult.ResultData);
                }
                else
                {
                    //錯誤頁
                    TempData["error"] = reposResult;
                    return RedirectToAction("Message", "Error");
                }
            }
            else
            {
                string msg = "無刪除目標值";
                reposResult = new ModelResult<SelectEditVM>(SystemCodes.Codes.ModelValidError)
                {
                    SystemMessage = msg
                };
                TempData["error"] = reposResult;
                return RedirectToAction("Message", "Error");
            }
        }
        [HttpPost]
        public ActionResult Edit(EditVM vm)
        {
            IModelResult reposResult;
            if (ModelState.IsValid)
            {
                reposResult = repository.UpdateStudent(vm);
                if (reposResult.IsOk)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //錯誤頁
                    TempData["error"] = reposResult;
                    return RedirectToAction("Message", "Error");
                }
            }
            else
            {
                string msg = string.Join("/n", ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => string.Join("/n", x.Value.Errors.Select(y => y.ErrorMessage).ToList())));
                reposResult = new ModelResult(SystemCodes.Codes.ModelValidError)
                {
                    SystemMessage = msg
                };
                TempData["error"] = reposResult;
                return RedirectToAction("Message", "Error");
            }
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public ActionResult Delete(string k)
        {
            IModelResult reposResult;
            if (!string.IsNullOrEmpty(k.Trim()))
            {
                reposResult = repository.DeleteStudent(k);
                if (reposResult.IsOk)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //錯誤頁
                    TempData["error"] = reposResult;
                    return RedirectToAction("Message", "Error");
                }
            }
            else
            {
                string msg = "無刪除目標值";
                reposResult = new ModelResult(SystemCodes.Codes.ModelValidError)
                {
                    SystemMessage = msg
                };
                TempData["error"] = reposResult;
                return RedirectToAction("Message", "Error");
            }
        }
    }
}