using MVC_APP.Models;
using Microsoft.EntityFrameworkCore;
using MVC_APP.Models;

namespace MVC_APP.Data
{
    public class MovieRentalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<RentalMovie> RentalMovies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\local;Initial Catalog=[Movie-Rental-Store];Integrated Security=True;");
        }
    }
}
