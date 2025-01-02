using Microsoft.EntityFrameworkCore;
using RESTAPI_PROJ.Models;

namespace RESTAPI_PROJ.Repositories
{
    public class ResturantRepository: IResturantRepository
    {
        private readonly AppDbContext _appDbContext;
        public ResturantRepository(AppDbContext dbcontext) {
            _appDbContext = dbcontext;  

        }

        public async Task<List<ResturantModel>> GetAll(int pageno, int pagesize) {
            //get the total no of records
            var norecords = await _appDbContext.Resturants.CountAsync();
            //offset the records
            return await _appDbContext.Resturants.Skip((pageno-1)*pagesize).Take(pagesize).ToListAsync();   
           
        }
    }
}
