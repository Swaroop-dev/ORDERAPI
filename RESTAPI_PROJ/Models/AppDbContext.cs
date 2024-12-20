using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RESTAPI_PROJ.Models
{
   
   

    public class AppDbContext : DbContext
    {
        //private readonly IConfiguration configuration;
        public DbSet<UserModel> Users { get; set; }

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
        }


    }

}
