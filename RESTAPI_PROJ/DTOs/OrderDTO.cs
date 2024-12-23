using System.Diagnostics.Contracts;

namespace RESTAPI_PROJ.DTOs
{

    public class Address {
        public string City { get; set; }
        public string Address_line_1 {get;set;}
        public string Address_line_2 {get;set;} 
        public string State { get; set;}    

    }

    public class ResturantDetails
    {
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Name { get; set; } 
    }
    public class OrderDetails
    {
        public int orderId { get; set; }
        public Address Address { get; set; }    

        public string OrderStatus { get; set; }

        public ResturantDetails ResturantDetails { get; set; }

        public int TotalPrice { get; set; }    

    }

    public class Order
    {
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }

        public int TotalPrice { get; set; }

        public string ResturantName { get; set; }
    }
}
