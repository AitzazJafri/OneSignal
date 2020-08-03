using OneSignal.Model.ResponseModel;
using OneSignal.Model.ServiceModel;
using OneSignal.Utility.Enums;
using OneSignal.Utility.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace OneSignal.WebService
{
    public class BaseOneSignal
    {
        public HttpClientRequestObject<T> MakeRequestObject<T>(T obj,RequestTypes RequestType = RequestTypes.post,string url = "" )
        {
            var requestObject = new HttpClientRequestObject<T>
            {
                Object = obj,
                AuthToken = WebConfigurationManager.AppSettings["OneSignalAuthKey"],
                BaseUrl = WebConfigurationManager.AppSettings["OneSignalBaseURL"],
                RequestType = (int)RequestType,
                URL = url
            };
            return requestObject;
        }
        public HttpClientResponseModel<T> ErrorResponse<T>(string message, HttpStatusCode code = HttpStatusCode.BadRequest)
        {
            return new HttpClientResponseModel<T> { success = false, message = message, type = ResponseType.Error, code = (int)code };
        }
        public HttpClientResponseModel<T> SuccessResponse<T>(T resut, string message = "", HttpStatusCode code = HttpStatusCode.OK)
        {
            return new HttpClientResponseModel<T> { result = resut, success = true, message = message == "" ? Enums.GetDescription(Messages.Operation_Successful_01) : message, type = ResponseType.Success, code = (int)code };
        }
    }
}
