using Microsoft.EntityFrameworkCore;
using RESTAPI_PROJ.DTOs;
using RESTAPI_PROJ.Models;

namespace RESTAPI_PROJ.Repositories
{
    public class OrderRepository: IOrderRepository
    {
       
        private readonly AppDbContext _appDbContext;


        public OrderRepository(AppDbContext context) { 
           
            _appDbContext = context;
        }

        public async Task<List<Order>> GetAllOrders(int userId)
        {
            if (userId == 0) {
                throw new ArgumentNullException("userId cant be 0");
            }

            //var orderslist = _appDbContext.Orders.Where(x => x.user_id == userId).ToList();
            var res = (from order in _appDbContext.Orders
                       join rest in _appDbContext.Resturants on order.restuarant_id equals rest.id
                       where order.user_id==userId
                       select
                       new Order
                       {
                           OrderId = order.id,
                           ResturantName = rest.name,
                           OrderStatus = order.order_status,
                           TotalPrice = order.total_price
                       });
            return  res.ToList();


        }

        public async Task<OrderModel> GetorderDetailsByid(int id)
        {
            var orderDetail= await _appDbContext.Orders.FirstOrDefaultAsync(x=>x.id==id);
            return orderDetail ;
        }

        public async Task<ResturantModel>GetResturantDetails(int id)
        {
            var resturantDetails=await _appDbContext.Resturants.FirstOrDefaultAsync(x=>x.id==id);

            return resturantDetails;
        }

        public async Task<AddressModel> GetAddressDetails(int id)
        {
            var usersavedaddress=await _appDbContext.Address.FirstOrDefaultAsync(x=>x.id==id);

            return usersavedaddress;
        }
    }
}
