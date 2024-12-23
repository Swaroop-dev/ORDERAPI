using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RESTAPI_PROJ.Models
{
   
   

    public class AppDbContext : DbContext
    {
        //private readonly IConfiguration configuration;
        public DbSet<UserModel> Users { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<AddressModel> Address { get; set; }
        public DbSet<ResturantModel> Resturants { get; set; }   


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("users");
            modelBuilder.Entity<OrderModel>().ToTable("orders");
            modelBuilder.Entity<AddressModel>().ToTable("usersaved_address");
            modelBuilder.Entity<ResturantModel>().ToTable("resturant");

        }



    }

}
