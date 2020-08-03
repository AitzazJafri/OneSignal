using Newtonsoft.Json;
using OneSignal.Model.OSResponseModel;
using OneSignal.Model.RequestModel;
using OneSignal.Model.ServiceModel;
using OneSignal.Utility.Enums;
using OneSignal.Utility.HelperClasses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneSignal.WebService.service
{
    public class OneSignal : BaseOneSignal, IDisposable //, IOneSignal
    {
        private HttpClientHelper client;
        public OneSignal()
        {
            client = new HttpClientHelper();
        }
        #region Create App
        public async Task<HttpClientResponseModel<AppResponseModel>> CreateApp(AppRequestModel requestObject)
        {
            try
            {
                var result = await client.CallRequest<AppRequestModel, AppResponseModel>(MakeRequestObject(requestObject, url: "/apps"));
                return SuccessResponse(result);
            }
            catch (Exception ex)
            {
                //We can do error logging here...
                return ErrorResponse<AppResponseModel>(Enums.GetDescription((Messages)Messages.GeneralError_01));
            }
        }

        #endregion
        #region ViewApps
        public async Task<HttpClientResponseModel<List<AppResponseModel>>> ViewApps()
        {
            try
            {
                var result = await client.CallRequest<bool, List<AppResponseModel>>(MakeRequestObject(true, RequestTypes.get, "/apps"));

                return SuccessResponse(result);
            }
            catch (Exception ex)
            {
                //We can do error logging here...
                return ErrorResponse<List<AppResponseModel>>(Enums.GetDescription((Messages)Messages.GeneralError_01));
            }
        }
        #endregion
        #region ViewApp
        public async Task<HttpClientResponseModel<AppResponseModel>> ViewApp(string ID)
        {
            try
            {
                var result = await client.CallRequest<bool, AppResponseModel>(MakeRequestObject(true, RequestTypes.get, "/apps/" + ID));

                return SuccessResponse(result);
            }
            catch (Exception ex)
            {
                //We can do error logging here...
                return ErrorResponse<AppResponseModel>(Enums.GetDescription((Messages)Messages.GeneralError_01));
            }
        }
        #endregion
        #region Update App
        public async Task<HttpClientResponseModel<AppResponseModel>> UpdateApp(AppRequestModel requestObject , string id)
        {
            try
            {
                var result = await client.CallRequest<AppRequestModel, AppResponseModel>(MakeRequestObject(requestObject,RequestTypes.put, url: "/apps/" + id));
                return SuccessResponse(result);
            }
            catch (Exception ex)
            {
                //We can do error logging here...
                return ErrorResponse<AppResponseModel>(Enums.GetDescription((Messages)Messages.GeneralError_01));
            }
        }

        #endregion

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
