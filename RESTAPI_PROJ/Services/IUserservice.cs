using RESTAPI_PROJ.Models;

namespace RESTAPI_PROJ.Services
{
    public interface IUserservice
    {
        UserModel GetUserbyid(int id);
    }
}
