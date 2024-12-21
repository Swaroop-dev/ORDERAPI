using RESTAPI_PROJ.Models;

namespace RESTAPI_PROJ.Repositories
{
    public interface IUserrepository
    {
        Task<UserModel> GetUserById(int id);
    }
}
