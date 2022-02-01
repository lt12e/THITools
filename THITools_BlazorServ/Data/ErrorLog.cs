using THITools_BlazorServ.DbAccess;
using THITools_BlazorServ.Models;

namespace THITools_BlazorServ.Data
{
    public class ErrorLog
    {
        

        private readonly ISqlDataAccess _db;

        public ErrorLog(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<IEnumerable<ErrorLogModel>> GetErrorLogs() =>
            _db.LoadData<ErrorLogModel, dynamic>(storedProcedure: "dbo.crud_ErrorLog_Select", new { });

        public async Task<ErrorLogModel?> GetErrorLog(int id)
        {
            var results = await _db.LoadData<ErrorLogModel, dynamic>(storedProcedure: "dbo.crud_ErrorLog_Select", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertErrorLog(ErrorLogModel error) =>
            _db.SaveData(storedProcedure: "dbo.crud_ErrorLog_Insert", new { error.ModuleId, error.ErrorTimestamp, error.ErrorUser, error.ErrorMsg, error.ErrorSeverity, error.ErrorState });

        /* Error log records do not need to be updated or deleted via the application at this time. */
        //public Task UpdateErrorLog(ErrorLogModel error) =>
        //    _db.SaveData(storedProcedure: "dbo.crud_ErrorLog_Update", error);

        //public Task DeleteErrorLog(int id) =>
        //    _db.SaveData(storedProcedure: "dbo.crud_ErrorLog_Delete", new { Id = id });


    }
}
