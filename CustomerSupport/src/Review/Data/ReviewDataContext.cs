using Customer.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace Review.Data
{
    public class ReviewDataContext : DbContext
    {
        public ReviewDataContext(DbContextOptions<ReviewDataContext> options) : base(options)
        {

        }
        public DbSet<Reviews> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.UseSerialColumns();

            modelbuilder.Entity<Reviews>().HasData(
                new Reviews()
                {
                    Id = 1,
                    CustomerId = 1,
                    CreatedDate = DateTime.UtcNow,
                    ReviewText = "This is good yes",
                    Rating = 4
                });

        }



    }
}
