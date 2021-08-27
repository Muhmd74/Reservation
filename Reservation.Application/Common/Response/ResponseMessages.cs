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

        public const string LoginSuccess = "User login successfully";
        public const string LoginFailure = "User credintials error";
        //Repeat Phone Number
        public const string ErrorPassword = "Password is not correct  ";
        public const string RepeatName = "Name is not exist  ";
    }
}
