using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<CategoryType> categoryTypes { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Size> sizes { get; set; }
        public DbSet<Color> colors { get; set; }

        public DbSet<Product> products { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<ProductImage> productImages { get; set; }
        public DbSet<ProductColor> productColors { get; set; }

        public DbSet<ProductSize> productSizes { get; set; }
        public DbSet<Promotion> promotion { get; set; }
        public DbSet<UserPromotion> userPromotion { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> ordersItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryType>()
               .HasMany(ct => ct.Categories)
               .WithOne()
               .HasForeignKey(c => c.CategoryTypeId);
            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Product>()
                .HasMany(c => c.ProductImages)
                .WithOne()
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Product>()
                .HasMany(c => c.ProductSizes)
                .WithOne()
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Product>()
                .HasMany(c => c.ProductColors)
                .WithOne()
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Product>()
                .HasMany(c => c.Comments)
                .WithOne()
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<ProductSize>()
                .HasOne(c => c.Size)
                .WithMany()
                .HasForeignKey(p => p.SizeId);
            modelBuilder.Entity<ProductColor>()
                .HasOne(c => c.Color)
                .WithMany()
                .HasForeignKey(p => p.ColorId);
            modelBuilder.Entity<Cart>()
                .HasOne(c=>c.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Order>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Order>()
                .HasMany(c => c.OrderItems)
                .WithOne()
                .HasForeignKey(p => p.OrderId);
            modelBuilder.Entity<OrderItem>()
                .HasOne(c => c.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Promotion>()
                .HasMany(c => c.UserPromotions)
                .WithOne()
                .HasForeignKey(p => p.PromotionId);
            modelBuilder.Entity<UserPromotion>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShippingStatus)
                .HasDefaultValue("Chưa chuyển")
                .IsRequired();
            modelBuilder.Entity<Order>()
                .Property(o => o.PaymentStatus)
                .HasDefaultValue("Chưa thanh toán")
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(o => o.Role)
                .HasDefaultValue("User")
                .IsRequired();
            modelBuilder.Entity<Order>()
                .Property(o => o.Discount)
                .HasDefaultValue(0m)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(o => o.Sell)
                .HasDefaultValue(0)
                .IsRequired();
            modelBuilder.Entity<Promotion>()
                .Property(o => o.Status)
                .HasDefaultValue(true)
                .IsRequired();
        }
    }
}
