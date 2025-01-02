using RESTAPI_PROJ.Models;

namespace RESTAPI_PROJ.Repositories
{
    public interface IResturantRepository
    {
        Task<List<ResturantModel>> GetAll(int pageno, int pageSize);    
    }
}
