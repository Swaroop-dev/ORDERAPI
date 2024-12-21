using RESTAPI_PROJ.Models;

namespace RESTAPI_PROJ.Repositories
{
    public interface IUserrepository
    {
        UserModel GetUserById(int id);
    }
}
