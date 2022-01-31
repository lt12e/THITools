﻿namespace THITools_BlazorServ.Data
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }     
        public DateTime ErrorTimestamp { get; set; }    

        public string ErrorUser { get; set; }
        public string ErrorMsg { get; set; }
        public int ErrorSeverity { get; set; }
        public int ErrorState { get; set; }
    }
}
