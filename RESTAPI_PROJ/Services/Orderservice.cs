using RESTAPI_PROJ.DTOs;
using RESTAPI_PROJ.Models;
using RESTAPI_PROJ.Repositories;

namespace RESTAPI_PROJ.Services
{
    public class Orderservice: IOrderservice
    {
        private readonly IOrderRepository _repository;
        public Orderservice(IOrderRepository repository) { 
            _repository = repository;
        }   

        public async Task<List<Order>> GetAllOrder(int userid)
        {
            if (userid==0)
            {
                throw new ArgumentNullException("userId can't be 0");
            }

            var orderList = await _repository.GetAllOrders(userid);
          
            return orderList;
        }

        //unused
        private Order MapToOrderDTO(OrderModel order) { 
            Order order1 = new Order();
            if (order.id==null)
            {
                order1.OrderId = order.id;
            }
            if (!String.IsNullOrEmpty(order.order_status))
            {
                order1.OrderStatus = order.order_status;
            }

            if(order.total_price!=null && order.total_price != 0)
            {
                order1.TotalPrice= order.total_price;
            }

            return order1;

        }

    }
}
