using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignal.Model.ServiceModel
{
    public class HttpClientResponseModel<T>
    {
        public int code { get; set; }
        public bool success { get; set; }
        public string type { get; set; }
        public string message { get; set; }
        public T result { get; set; }

    }
}
