using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignal.Model.ServiceModel
{
    public class HttpClientRequestObject<T>
    {
        public string BaseUrl { get; set; }
        public string URL { get; set; }
        public string AuthToken { get; set; }
        public int RequestType { get; set; }
        public T Object { get; set; }
    }
}
