using Fox.Model.Config;
using Fox.Model.ViewModel.Error;
using System.Web.Mvc;

namespace Fox.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        /// <summary>
        /// Default Error Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Message()
        {
            //取得temp
            IModelResult modelResult = TempData["error"] as IModelResult;
            // 若 TempData 沒有錯誤訊息，回到預設錯誤頁
            if (modelResult == null)
            {
                return RedirectToAction("Index");
            }// 若 TempData 中之 ModelResult 沒有錯誤訊息，回到預設錯誤頁
            else if (string.IsNullOrEmpty(modelResult.Message))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ErrorVM errorVM = new ErrorVM()
                {
                    Message = modelResult.Message,
                    DisplayCode = modelResult.DisplayCode
                };
                return View(errorVM);
            }
        }
    }
}