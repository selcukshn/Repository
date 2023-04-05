using Common;
using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder config)
        {
            if (!config.IsConfigured)
                config.UseSqlServer(StringConstant.SqlConnection);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(entity =>
            {
                entity.Property(x => x.Id).UseIdentityColumn();
                entity.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            });

            builder.Entity<Category>(entity =>
           {
               entity.Property(x => x.Id).UseIdentityColumn();
           });
            builder.Entity<ProductTag>(entity =>
           {
               entity.Property(x => x.Id).UseIdentityColumn();
               entity.HasIndex(x => new { x.ProductId, x.TagId }).IsUnique();
               entity.HasOne<Product>(x => x.Product).WithMany(x => x.ProductTags).HasForeignKey(x => x.ProductId);
               entity.HasOne<Tag>(x => x.Tag).WithMany(x => x.ProductTags).HasForeignKey(x => x.TagId);
           });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
    }
}