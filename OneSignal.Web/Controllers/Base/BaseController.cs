using OneSignal.Model.ResponseModel;
using OneSignal.Utility.Enums;
using OneSignal.Utility.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OneSignal.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        public JsonResult ErrorResponse<T>(ResponseObject<T> result, HttpStatusCode code = HttpStatusCode.BadRequest)
        {
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ErrorResponse<T>(string message, HttpStatusCode code = HttpStatusCode.BadRequest)
        {
            var result = new ResponseObject<T> { isSuccess = false, Message = message, Type = ResponseType.Error, StatusCode = (int)code };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SuccessResponse<T>(T resut, string message = "", string type = ResponseType.Success, HttpStatusCode code = HttpStatusCode.BadRequest)
        {
            var result = new ResponseObject<T> { Result = resut, isSuccess = true, Message = message == "" ? Enums.GetDescription(Messages.Operation_Successful_01) : message, Type = type, StatusCode = (int)code };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}