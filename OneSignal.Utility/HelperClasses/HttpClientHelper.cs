using Newtonsoft.Json;
using OneSignal.Model.ServiceModel;
using OneSignal.Utility.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace OneSignal.Utility.HelperClasses
{
    public class HttpClientHelper : IDisposable
    {
       
        private HttpClient client;
        public HttpClientHelper()
        {
            client = new HttpClient();
        }
        public  async Task<K> CallGetRequest<T, K>(HttpClientRequestObject<T> requestObject)
        {
            
            client.DefaultRequestHeaders.Add("User-Agent", "OneSignalApp");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", requestObject.AuthToken);
            HttpResponseMessage response = await client.GetAsync(requestObject.BaseUrl + requestObject.URL);
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();

            K result = JsonConvert.DeserializeObject<K>(resp);

            return result;
        }

        public async Task<K> CallPostRequest<T, K>(HttpClientRequestObject<T> requestObject)
        {
            var json = JsonConvert.SerializeObject(requestObject.Object);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "OneSignalApp");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", requestObject.AuthToken);
            HttpResponseMessage response = await client.PostAsync(requestObject.BaseUrl + requestObject.URL, data);
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            K result = JsonConvert.DeserializeObject<K>(resp);
            return result;
        }

        public async Task<K> CallRequest<T, K>(HttpClientRequestObject<T> requestObject)
        {

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "OneSignalApp");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", requestObject.AuthToken);
            HttpResponseMessage response;
            if (requestObject.RequestType == (int)RequestTypes.post)
            {
                var json = JsonConvert.SerializeObject(requestObject.Object, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(requestObject.BaseUrl + requestObject.URL, data);
            }
            else if (requestObject.RequestType == (int)RequestTypes.put)
            {
                var json = JsonConvert.SerializeObject(requestObject.Object, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PutAsync(requestObject.BaseUrl + requestObject.URL, data);
            }
            else
            {
                response = await client.GetAsync(requestObject.BaseUrl + requestObject.URL);
            }
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            K result = JsonConvert.DeserializeObject<K>(resp);
            return result;

        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
