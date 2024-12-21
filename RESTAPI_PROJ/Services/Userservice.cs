using RESTAPI_PROJ.Models;
using RESTAPI_PROJ.Repositories;

namespace RESTAPI_PROJ.Services
{
    public class Userservice: IUserservice
    {
        private readonly IUserrepository _userrepository;

        public Userservice (IUserrepository userrepository)
        {
            _userrepository = userrepository;
        }

        public UserModel GetUserbyid(int id)
        {
            return _userrepository.GetUserById(id);
        }



    }
}
