using BotafeMVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotafeMVC.Application.Errors
{
    public class EnrollmentError : IError
    {
        public EnrollmentError(string message) 
        {
            Message = message;
        }
        public string Message { get; }
    }
}
