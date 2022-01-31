﻿using THITools_BlazorServ.DbAccess;
using THITools_BlazorServ.Models;

namespace THITools_BlazorServ.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<UserModel>> GetUsers() =>
            _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });

        public async Task<UserModel?> GetUser(int id)
        {
            var results = await _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_Get", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertUser(UserModel user) =>
            _db.SaveData(storedProcedure: "dbo.spUser_Insert", new { user.FirstName, user.LastName });

        public Task UpdateUser(UserModel user) =>
            _db.SaveData(storedProcedure: "dbo.spUser_Update", user);

        public Task DeleteUser(int id) =>
            _db.SaveData(storedProcedure: "dbo.spUser_Delete", new { Id = id });
    }
}
