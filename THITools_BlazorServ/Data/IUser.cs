using THITools_BlazorServ.Models;

namespace THITools_BlazorServ.Data
{
    public interface IUser
    {
        Task<UserModel?> GetUser(int id);
        Task<IEnumerable<UserModel>> GetUsers();
        Task InsertUser(UserModel user);
        Task UpdateUser(UserModel user);
        //Task DeleteUser(int id);
    }
}