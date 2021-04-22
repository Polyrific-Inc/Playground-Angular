using Microsoft.EntityFrameworkCore;
using Web.API.Category;
using Web.API.Product;

namespace Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductEntity>().HasOne(e => e.Category).WithMany().HasForeignKey(e => e.CategoryId);
        }
    }
}
