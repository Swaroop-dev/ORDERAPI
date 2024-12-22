using RESTAPI_PROJ.Models;

namespace RESTAPI_PROJ.Services
{
    public interface IUserservice
    {
        Task<UserModel> GetUserbyid(int id);
        Task<bool> Registeruser(UserModel user);
    }
}
