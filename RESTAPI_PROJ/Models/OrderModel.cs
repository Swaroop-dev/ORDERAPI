namespace RESTAPI_PROJ.Models
{
    public class OrderModel
    {
        public int id { get; set; }

        public int total_price {get;set;}

        public string order_status {get; set;}  

        public int  user_id { get; set;}

        public int restuarant_id { get; set;}   
    }
}
