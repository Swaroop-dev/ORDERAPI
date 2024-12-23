using System.Net.WebSockets;
using RESTAPI_PROJ.DTOs;
using RESTAPI_PROJ.Models;
using RESTAPI_PROJ.Repositories;

namespace RESTAPI_PROJ.Services
{
    public class Orderservice : IOrderservice
    {
        private readonly IOrderRepository _repository;
        public Orderservice(IOrderRepository repository) {
            _repository = repository;
        }

        public async Task<List<Order>> GetAllOrder(int userid)
        {
            if (userid == 0)
            {
                throw new ArgumentNullException("userId can't be 0");
            }

            var orderList = await _repository.GetAllOrders(userid);

            return orderList;
        }

        public async Task<OrderDetails> GetOrderDetailsById(int orderId)
        {
            if (orderId == 0)
            {
                throw new ArgumentNullException("orderId can't be 0");

            }

            var orderDetails = await _repository.GetorderDetailsByid(orderId);
            if (orderDetails.restuarant_id == 0)
            {
                throw new ArgumentException();
            }
            var resturantDetails = await _repository.GetResturantDetails(orderDetails.restuarant_id);
            AddressModel address = new AddressModel();
            if (orderDetails.address != 0)
            {
                address = await _repository.GetAddressDetails(orderDetails.address);
            }
            OrderDetails orderDetails1 = new OrderDetails();
            //Map resturant address and resurat details into corresponding DTO's
            orderDetails1.Address=MapToAddressDTO(address);
            orderDetails1.ResturantDetails=MapToResturantDTO(resturantDetails);


            return orderDetails1;

        }

        //unused
        private Order MapToOrderDTO(OrderModel order) {
            Order order1 = new Order();
            if (order.id == null)
            {
                order1.OrderId = order.id;
            }
            if (!String.IsNullOrEmpty(order.order_status))
            {
                order1.OrderStatus = order.order_status;
            }

            if (order.total_price != null && order.total_price != 0)
            {
                order1.TotalPrice = order.total_price;
            }

            return order1;

        }
        private Address MapToAddressDTO(AddressModel address) {

            Address address1 = new Address();
            if (String.IsNullOrEmpty(address.line1))
            {
                address1.Address_line_1 = address.line1;

            }

            if (String.IsNullOrEmpty(address.line2)) {
                address1.Address_line_2 = address.line2;

            }
            if (String.IsNullOrEmpty(address.state))
            {
                address1.State = address.state;
            }

            if (String.IsNullOrEmpty(address.city)) {
                address1.City = address.city;
            }
            return address1;
        }


        private ResturantDetails MapToResturantDTO(ResturantModel resturant)
        {
            ResturantDetails resturant1=new ResturantDetails();

            if (String.IsNullOrEmpty(resturant.state))
            {
                resturant1.State= resturant.state;  

            }

            if (String.IsNullOrEmpty(resturant.name))
            {
                resturant1.Name= resturant.name;    
            }

            return resturant1;
        }


    }
}
