namespace RESTAPI_PROJ.Models
{
    public class ResturantModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public int owner_id { get; set; }   

        public string address_line_1 { get; set; }  
        public string address_line_2 { get; set; }

        public string state { get; set; }   

        public string phonenum {  get; set; }
    }
}
