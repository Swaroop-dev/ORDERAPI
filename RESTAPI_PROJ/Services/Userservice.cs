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

        public async Task<UserModel> GetUserbyid(int id)
        {
            if ( id == 0) { 
                
                throw new ArgumentNullException("id");
            }
            var user= await _userrepository.GetUserById(id);

            return user;
        }

        public async Task<bool> Registeruser(UserModel user)
        {
            if (await _userrepository.Isemailtaken(user.emailid))
            {
                throw new InvalidOperationException();
            }
            if (await _userrepository.IsusernameTaken(user.username))
            {
                throw new InvalidOperationException();
            }

            return await _userrepository.RegisterUser(user);

        }
    }
}
