using RESTAPI_PROJ.Models;

namespace RESTAPI_PROJ.Services
{
    public interface IResturantservice
    {
        Task<List<ResturantModel>> GetAllResturants(int pagenNo, int pageSize);
    }
}
