﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RESTAPI_PROJ.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string emailid { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string  lastname { get; set; }   

        //public bool isresturantowner { get; set; }   
        
        //public bool isdelieverypartner { get; set; }
        public string phonenum { get;set; }
       



    }
}