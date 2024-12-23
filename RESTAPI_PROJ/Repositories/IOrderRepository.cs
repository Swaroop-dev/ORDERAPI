using System.Threading.Tasks;
using RESTAPI_PROJ.DTOs;
using RESTAPI_PROJ.Models;

namespace RESTAPI_PROJ.Repositories
{
    public interface IOrderRepository
    {
        //Task<OrderDetails> GetorderDetailsByid(int orderid);

        Task<List<Order>> GetAllOrders(int userid);

        Task<OrderModel> GetorderDetailsByid(int id);
        Task<AddressModel> GetAddressDetails(int id);
        Task<ResturantModel> GetResturantDetails(int id);
    }
}
