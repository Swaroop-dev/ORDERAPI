using RESTAPI_PROJ.DTOs;

namespace RESTAPI_PROJ.Services
{
    public interface IOrderservice
    {
        Task<List<Order>> GetAllOrder(int userid);
    }
}
