using Microsoft.EntityFrameworkCore;
using RESTAPI_PROJ.Models;

namespace RESTAPI_PROJ.Repositories
{
    public class Userrepository: IUserrepository
    {
        private readonly AppDbContext _context;

        public Userrepository(AppDbContext context)
        {
           this. _context = context;
        }

        public  async Task<UserModel> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<bool> RegisterUser(UserModel user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<bool> Isemailtaken(string email)
        {

            var res = await _context.Users.Where(x => x.emailid == email).Select(x => x.id).AnyAsync();

            return res;
        }

        public async Task<bool> IsusernameTaken(string username)
        {
            return await _context.Users.AnyAsync(x=>x.username == username);    
        }


    }
}
