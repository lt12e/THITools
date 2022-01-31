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
            _db.LoadData<ErrorLogModel, dynamic>(storedProcedure: "dbo.spErrorLog_GetAll", new { });

        public async Task<ErrorLogModel?> GetErrorLog(int id)
        {
            var results = await _db.LoadData<ErrorLogModel, dynamic>(storedProcedure: "dbo.spErrorLog_Get", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertErrorLog(ErrorLogModel error) =>
            _db.SaveData(storedProcedure: "dbo.spErrorLog_Insert", new { error.ModuleId, error.ErrorTimestamp, error.ErrorUser, error.ErrorMsg, error.ErrorSeverity, error.ErrorState });

        public Task UpdateErrorLog(ErrorLogModel error) =>
            _db.SaveData(storedProcedure: "dbo.spErrorLog_Update", error);

        public Task DeleteErrorLog(int id) =>
            _db.SaveData(storedProcedure: "dbo.spErrorLog_Delete", new { Id = id });


    }
}
