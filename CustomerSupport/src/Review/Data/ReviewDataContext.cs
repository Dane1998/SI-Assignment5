using Microsoft.EntityFrameworkCore;

namespace Review.Data
{
    public class ReviewDataContext : DbContext
    {
        public ReviewDataContext(DbContextOptions<ReviewDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.UseSerialColumns();
        }

        public DbSet<Reviews> Reviews { get; set; }

    }
}
