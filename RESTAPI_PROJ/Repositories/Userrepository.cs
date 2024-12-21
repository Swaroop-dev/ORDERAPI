using RESTAPI_PROJ.Models;

namespace RESTAPI_PROJ.Repositories
{
    public class Userrepository: IUserrepository
    {
        private readonly AppDbContext _context;

        public Userrepository(AppDbContext context)
        {
            _context = context;
        }

        public  UserModel GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.id == id);
        }


    }
}
