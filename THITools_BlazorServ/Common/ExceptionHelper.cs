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
        string environment { get; set; }
        string customMessage { get; set; }
        DateTime exceptionTime { get; set; }
        bool logged { get; set; }

        public ExceptionHelper()
        {
            Exception ex = new Exception();
            string user = ""; //TODO: Add user for error logging
            string environment = ""; //TODO: Add environment info
            string customMessage = "";  //TODO: Add custom message for error logging
            DateTime exceptionTime = DateTime.Now;
            bool logged;
        }

        public ExceptionHelper(Exception e)
        {
            Exception ex = e;
            string user = ""; //TODO: Add user for error logging
            string environment = ""; //TODO: Add environment info
            string customMessage = ""; //TODO: Add custom message for error logging
            DateTime exceptionTime = DateTime.Now;
            bool logged;
        }

        public bool LogException()
        {
            try
            {
                //TODO: implement LogException logic - add error log record
                //
                return true; //return true if error log is written to DB 
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
    }
}
