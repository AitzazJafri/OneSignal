using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignal.Model.ResponseModel
{
    public class ResponseObject<T>
    {
        public int StatusCode { get; set; }
        public bool isSuccess { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
