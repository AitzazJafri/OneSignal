using System.Threading.Tasks;
using System.Web.Mvc;
using OneSignal.Model.RequestModel;
using OneSignal.Utility.Enums;
using OneSignal.Utility.HelperClasses;
using OneSignal.Web.Controllers.Base;

namespace OneSignal.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            return View();
        }
        #region ViewAppDetail
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ViewApp(string id = "")
        {
            if (id == "")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                using (WebService.service.OneSignal os = new WebService.service.OneSignal())
                {
                    var result = await os.ViewApp(id);
                    if (result.success)
                    {
                        return View(result.result);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
        }
        #endregion

        #region Create & Update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> EditApp(string id = "")
        {
            if (id == "")
            {
                AppRequestModel model = new AppRequestModel();
                return View(model);
            }
            else
            {
                using (WebService.service.OneSignal os = new WebService.service.OneSignal())
                {
                    var result = await os.ViewApp(id);

                    if (result.success)
                    {
                        AppRequestModel model = new AppRequestModel
                        {
                            apns_env = result.result.apns_env,
                            chrome_key = result.result.chrome_key,
                            chrome_web_default_notification_icon = result.result.chrome_web_default_notification_icon,
                            chrome_web_origin = result.result.chrome_web_origin,
                            chrome_web_sub_domain = result.result.chrome_web_sub_domain,
                            gcm_key = result.result.gcm_key,
                            //id = result.result.id,
                            name = result.result.name,
                            safari_icon_256_256 = result.result.safari_icon_256_256,
                            safari_site_origin = result.result.safari_site_origin
                        };
                        ViewBag.id = id;
                        return View(model);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditApp(AppRequestModel model, string AppID = "")
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (WebService.service.OneSignal os = new WebService.service.OneSignal())
            {
                //Update
                if (AppID != "")
                {
                    var result = await os.UpdateApp(model, AppID);
                    if (result.success)
                    {
                        TempData["Notification"] = Enums.GetDescription(Messages.Update_Successful_01);
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ModelState.AddModelError("", result.message);
                        return View(model);
                    }
                }
                //Create
                else
                {
                    var result = await os.CreateApp(model);
                    if (result.success)
                    {
                        TempData["Notification"] = Enums.GetDescription(Messages.Save_Successful_01);
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ModelState.AddModelError("", result.message);
                        return View(model);
                    }
                }
            }
        }

        #endregion

        #region Post & Get Requests

        /// <summary>
        /// Post Request For Geting App List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> ViewAppsList()
        {
            using (WebService.service.OneSignal os = new WebService.service.OneSignal())
            {
                var result = await os.ViewApps();
                if (result.success)
                {
                    return SuccessResponse(result.result);
                }
                else
                {
                    return ErrorResponse<bool>(result.message);
                }
            }
        }
        #endregion
    }
}