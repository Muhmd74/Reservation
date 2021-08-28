using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Application.Common.Response
{
    public static class ResponseMessages
    {
        public const string Failure = "your data is not suitable";
        public const string Success = "Data process successfully";
        public const string NotFound =
            "Please check your model as per as required parameters, no data found with this parameters";
        public const string Reservation =
            "You've Reservation before";

    }
}
