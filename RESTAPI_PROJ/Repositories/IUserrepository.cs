using RESTAPI_PROJ.Models;

namespace RESTAPI_PROJ.Repositories
{
    public interface IUserrepository
    {
        Task<UserModel> GetUserById(int id);
        Task<bool> RegisterUser(UserModel user);
        Task<bool> IsusernameTaken(string username);
        Task<bool> Isemailtaken(string email);
    }
}
