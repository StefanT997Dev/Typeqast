using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountRule> DiscountRules { get; set; }
        public DbSet<Product> Products {get;set;}
        public DbSet<ProductDiscount> ProductDiscounts {get;set;}
        public DbSet<ShoppingBasketPair> ShoppingBasketPairs { get; set; }
        public DbSet<ShoppingBasket> ShoppingBaskets{get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductDiscount>(x => x.HasKey(pd => new {pd.ProductId,pd.DiscountId}));

            builder.Entity<ProductDiscount>()
                .HasOne(p => p.Product)
                .WithMany(d => d.Discounts)
                .HasForeignKey(pd => pd.ProductId);

            builder.Entity<ProductDiscount>()
                .HasOne(p => p.Discount)
                .WithMany(d => d.Products)
                .HasForeignKey(pd => pd.DiscountId);

            builder.Entity<ShoppingBasketPair>(x => x.HasKey(sb => new {sb.CustomerId,sb.ProductId}));

            builder.Entity<ShoppingBasketPair>()
                .HasOne(u => u.Customer)
                .WithMany(c => c.Products)
                .HasForeignKey(sb => sb.CustomerId);

            builder.Entity<ShoppingBasketPair>()
                .HasOne(u => u.Product)
                .WithMany(p => p.Customers)
                .HasForeignKey(sb => sb.ProductId);
        }
    }
}