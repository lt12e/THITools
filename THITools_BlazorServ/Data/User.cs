using THITools_BlazorServ.DbAccess;
using THITools_BlazorServ.Models;

namespace THITools_BlazorServ.Data
{
    public class User : IUser
    {
        private readonly ISqlDataAccess _db;

        public User(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<UserModel>> GetUsers() =>
            _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.crud_User_Get", new { });

        public async Task<UserModel?> GetUser(int id)
        {
            var results = await _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.crud_User_Get", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertUser(UserModel user) =>
            _db.SaveData(storedProcedure: "dbo.crud_User_Insert", new { user.User, user.Inactive, user.PBIUsername, user.GPUsername });

        public Task UpdateUser(UserModel user) =>
            _db.SaveData(storedProcedure: "dbo.crud_User_Update", new { user.User, user.Inactive, user.PBIUsername, user.GPUsername });

        /* Currently no need to delete user records via application. Update inactive flag to 1 instead. */
        //public Task DeleteUser(int id) =>
        //    _db.SaveData(storedProcedure: "dbo.crud_User_Delete", new { Id = id });
    }
}
