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

        public async Task<List<OrderModel>> GetAllOrders(int userId)
        {
            if (userId == 0) {
                throw new ArgumentNullException("userId cant be 0");
            }

            var orderslist = _appDbContext.Orders.Where(x => x.user_id == userId).ToList();

            return orderslist;


        }

        //public async Task<OrderDetails> GetorderDetailsByid(int id)
        //{
        //    return
        //}
    }
}
