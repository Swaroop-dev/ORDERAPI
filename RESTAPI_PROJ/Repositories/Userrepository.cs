using Microsoft.EntityFrameworkCore;
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

        public  async Task<UserModel> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.id == id);
        }


    }
}
