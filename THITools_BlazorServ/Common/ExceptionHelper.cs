using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THITools.Common
{
    public class ExceptionHelper
    {
        Exception ex {get; set;}
        string user { get; set; }
        string customMessage { get; set; }
        DateTime exceptionTime { get; set; }
        bool logged { get; set; }

        public ExceptionHelper()
        {
            Exception ex = new Exception();
            string user = ""; //TODO: Add user for error logging
            string customMessage = "";  //TODO: Add custom message for error logging
            DateTime exceptionTime = DateTime.Now;
            bool logged;
        }

        public ExceptionHelper(Exception e)
        {
            Exception ex = e;
            string user = ""; //TODO: Add user for error logging
            string customMessage = ""; //TODO: Add custom message for error logging
            DateTime exceptionTime = DateTime.Now;
            bool logged;
        }

        public bool LogException()
        {
            //TODO: implement LogException logic - add error log record
            return false;
        }
    }
}
