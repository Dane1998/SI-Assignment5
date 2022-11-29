using Microsoft.EntityFrameworkCore;

namespace Customer.Data
{
    public class CustomerDataContext : DbContext
    {

        public CustomerDataContext(DbContextOptions<CustomerDataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.UseSerialColumns();
        }
        public DbSet<User> Users { get; set; }


    }
}
