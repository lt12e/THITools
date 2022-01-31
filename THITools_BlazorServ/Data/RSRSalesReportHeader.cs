using BlazorInputFile;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using THITools;

namespace THITools.RepComissions
{
    public class RSRSalesReportHeader
    {
        public string title { get; set; }
        public string vendor { get; set; }
        public string company { get; set; }
        public DateTime runDateTime { get; set; }
        public string runType { get; set; }
        public string salesLocations { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
        protected bool inactive { get; set; }
        protected DateTime updateDateTime { get; set; }
        protected string updateUser { get; set; }
        protected string updateMethod { get; set; }


        public RSRSalesReportHeader()
        {
            title = "";
            vendor = "";
            company = "";
            runDateTime = DateTime.MinValue;
            runType = "";
            salesLocations = "";
            startDateTime = DateTime.MinValue;
            endDateTime = DateTime.MinValue;
            inactive = false;
            updateDateTime = DateTime.MinValue;
            updateUser = "";
            updateMethod = "THITools: RSRReportSalesHeader constructor";
        }

        public RSRSalesReportHeader(string reportTitle, string vendorName, string comapnyName, DateTime reportRunDateTime, string reportRunType, 
                                    string reportSalesLocations, DateTime reportStart, DateTime reportEnd, bool isInactive = false)
            //DateTime auditDateTime) //, 
                                    //string auditUser, string auditMethod, bool isInactive = false )
        {
            title = reportTitle;
            vendor = vendorName;
            company = comapnyName;
            runDateTime = reportRunDateTime;
            runType = reportRunType;
            salesLocations = reportSalesLocations;
            startDateTime = reportStart;
            endDateTime = reportEnd;
            inactive = isInactive;
            updateDateTime = DateTime.Now;
            updateUser = ""; //TODO: add user 
            updateMethod = "THITools: RSRReportSalesHeader constructor";
        }

        public void CreateHeader(string fileContents)
        {
            //set all attributes
        }
        //get/load

        //save

        //delete
        public void SetFields(string reportTitle, string vendorName, string comapnyName, DateTime reportRunDateTime, string reportRunType,
                                    string reportSalesLocations, DateTime reportStart, DateTime reportEnd, string reportUploadUser, 
                                    string reportUpdateMethod, bool isInactive = false)
        {
            title = reportTitle;
            vendor = vendorName;
            company = comapnyName;
            runDateTime = reportRunDateTime;
            runType = reportRunType;
            salesLocations = reportSalesLocations;
            startDateTime = reportStart;
            endDateTime = reportEnd;
            inactive = isInactive;
            updateDateTime = DateTime.Now;
            updateUser = reportUploadUser;      //"";
            updateMethod = reportUpdateMethod;   //"THITools: RSRReportSalesHeader constructor";
        }
    }
}
