using BlazorInputFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using THITools;
//using CsvHelper;

namespace THITools.RepComissions
{
    public class RSRSalesReport
    {
         
        public RSRSalesReportHeader header { get; set; }
        //public RSRSalesReportBody body {get; set;} //TODO: implement 



        public RSRSalesReport ()
        {
            header = new RSRSalesReportHeader();
            //body = new RSRSalesReportBody(); //TODO: implement 
        }

        public RSRSalesReport(string fileContents)
        {

        }

        public void SetReportFields(string fileContents, string reportUser)
        {
            string currentLine;
            //line = StringReader.ReadLine(fileContents);
            StringReader reader = new StringReader(fileContents);
            int lineCounter = 0;

            /* Read header rows */
            string title = "";
            string vendor = "";
            string company = "";
            DateTime runDateTime = new DateTime();
            DateTime runTime = new DateTime();
            string salesFor = "";
            DateTime salesFrom = new DateTime();
            DateTime salesTo = new DateTime();
            string runType = "";



            //currentLine = reader.ReadLine();

            while (fileContents != null && lineCounter <= 6) //Report has 7 header rows
            {
                currentLine = reader.ReadLine();
                lineCounter++;
                Console.WriteLine("Current line:" + currentLine);
                string[] splitLine = currentLine.Split(',');
                if (lineCounter == 1 && splitLine[0] == "Title:")
                {
                    title = splitLine[1];
                }
                else if (lineCounter == 2 && splitLine[0] == "Vendor:")
                {
                    vendor = splitLine[1];
                }
                else if (lineCounter == 3 && splitLine[0] == "Company:")
                {
                    company = "RSR Group, Inc.";
                    //company = splitLine[1];  //TODO: convert to using file data
                }
                else if (lineCounter == 4 && splitLine[0] == "Run Date:")
                {
                    runDateTime = DateTime.Parse(splitLine[1]);
                }
                else if (lineCounter == 5 && splitLine[0] == "Run Time:")
                {
                    runTime = DateTime.Parse(splitLine[1]);
                }
                else if (lineCounter == 6 && splitLine[0] == "Sales for:")
                {
                    salesFor = splitLine[1];
                }
                else if (lineCounter == 7 && splitLine[0] == "Sales from:")
                {
                    string year = splitLine[1].Substring(splitLine[1].Length - 2);
                    //salesFrom = DateTime.Parse(splitLine[1]);
                    string salesFromString = "";
                    switch (splitLine[1].Substring(0, 3).ToUpper())
                    {
                        case "JAN":
                            salesFromString = "1/1/";
                            break;
                        case "FEB":
                            salesFromString = "2/1/";
                            break;
                        case "MAR":
                            salesFromString = "3/1/";
                            break;
                        case "APR":
                            salesFromString = "4/1/";
                            break;
                        case "MAY":
                            salesFromString = "5/1/";
                            break;
                        case "JUN":
                            salesFromString = "6/1/";
                            break;
                        case "JUL":
                            salesFromString = "7/1/";
                            break;
                        case "AUG":
                            salesFromString = "8/1/";
                            break;
                        case "SEP":
                            salesFromString = "9/1/";
                            break;
                        case "OCT":
                            salesFromString = "10/1/";
                            break;
                        case "NOV":
                            salesFromString = "11/1/";
                            break;
                        case "DEC":
                            salesFromString = "12/1/";
                            break;
                        default:
                            //TODO: Add error message and logging
                            break;
                    }
                    salesFrom = DateTime.Parse(salesFromString + year);
                }
                else
                {
                    //TODO: throw error - unexpected file header data format 
                }

                    //currentLine = reader.ReadLine(); //read next line
                };
            runDateTime = runDateTime.Add(runTime.TimeOfDay);

            DateTime startOfMonth = new DateTime(salesFrom.Year, salesFrom.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);

            if (endOfMonth < runDateTime)
                salesTo = endOfMonth;
            else
                salesTo = runDateTime;

            TimeSpan reportPeriod = salesTo - salesFrom;
            runType = reportPeriod.Days > 45 ? "YTD" : "MTD";

            /* TODO: set runType and SalesTo vars */

            /* salesTo = end of start date month (if MTD) or report run date, whichever is earlier 
             salesTo = end of start date year (if YTD) or report run date, whichever is earlier 
             */

            header.SetFields(title, vendor, company, runDateTime, runType, salesFor, salesFrom, salesTo, WindowsIdentity.GetCurrent().Name, TraceInfo(), false );




            /* send the rest of reader to be processed as the report body */
            //string reportBody = reader.ReadToEnd();


            }


        public void SetHeader() { }
        public void SetBody() { }

        public string TraceInfo(
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        {
            return memberName + ", " + sourceLineNumber.ToString() + ", " + sourceFilePath;
        }
        
    }
}