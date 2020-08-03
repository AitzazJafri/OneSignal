using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSignal.Utility.Enums
{
    public enum Messages
    {

        [Description("There is some issue. Please contact system admin.")]
        GeneralError_01 = 001,
        [Description("Invalid request.")]
        ParamtersRequired_01 = 002,
        [Description("Operation Successful.")]
        Operation_Successful_01 = 003,
        [Description("Data Saved Successfully.")]
        Save_Successful_01 = 004,
        [Description("Data Updated Successfully.")]
        Update_Successful_01 = 005,
    }
}
