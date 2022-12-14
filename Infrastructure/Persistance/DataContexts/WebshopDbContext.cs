using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.DataContexts
{
    /// <summary>
    /// Database entity configuration
    /// </summary>
    public class WebshopDbContext : DbContext
    {
        public WebshopDbContext(object createDbContextOptions)
        { 
        }

        public WebshopDbContext(DbContextOptions<WebshopDbContext> options) : base(options)
        {
        }

        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            CreateCustomerModel(modelBuilder);
            CreateShoppingCartModel(modelBuilder);
        }

        private void CreateCustomerModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Cart)

                .WithOne(sc => sc.Customer)
                .HasForeignKey<ShoppingCart>(b => b.CustomerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void CreateShoppingCartModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCart>()
                .HasMany(sc => sc.Items);

            modelBuilder.Entity<CartItem>()
                .HasIndex(ci => ci.ProductId);
        } 
    }
}
