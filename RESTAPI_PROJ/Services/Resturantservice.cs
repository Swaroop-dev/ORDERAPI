using RESTAPI_PROJ.Models;
using RESTAPI_PROJ.Repositories;

namespace RESTAPI_PROJ.Services
{
    public class Resturantservice:IResturantservice
    {
        private readonly IResturantRepository _resturantRepository;

        public Resturantservice(IResturantRepository resturantRepository)
        {
            _resturantRepository = resturantRepository;
        }

        public async Task<List<ResturantModel>> GetAllResturants(int pagenNo, int pageSize) { 

            return await _resturantRepository.GetAll(pagenNo, pageSize);
        }
    }
}
