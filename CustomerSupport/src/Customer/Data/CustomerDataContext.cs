using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Customer.Data
{
    public class CustomerDataContext : DbContext
    {

        public CustomerDataContext(DbContextOptions<CustomerDataContext> options) : base(options)
        {
            
        }

        public DbSet<Customers> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.UseSerialColumns();

            modelbuilder.Entity<Customers>().HasData(
                new Customers()
                {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "Test",
                    EmailAddress = "test@test.com",
                    CreatedDate = DateTime.UtcNow
                });

            modelbuilder.Entity<Customers>().HasData(
                new Customers()
                {
                    Id = 2,
                    FirstName = "Thor",
                    LastName = "Tester",
                    EmailAddress = "test1@test.com",
                    CreatedDate = DateTime.UtcNow
                });
        }
        
        

    }
}
