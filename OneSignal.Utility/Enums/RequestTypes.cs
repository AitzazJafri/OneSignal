using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignal.Utility.Enums
{
    public enum RequestTypes
    {
        [Description("POST")]
        post = 1,

        [Description("GET")]
        get = 2,

        [Description("PUT")]
        put = 3,
    }
}
