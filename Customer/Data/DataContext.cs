using Microsoft.EntityFrameworkCore;

namespace Customer.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.UseSerialColumns();
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
