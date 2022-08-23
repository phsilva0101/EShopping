using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Product.API.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product{
                Id = 2,
                Name = "Iphone 12",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pharetra metus. Suspendisse p",
                CategoryName = "SmartPhones",
                Price = 5899.00M,
                ImageUrl = ""
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Iphone XR",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pharetra metus. Suspendisse p",
                CategoryName = "SmartPhones",
                Price = 2899.00m,
                ImageUrl = ""
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Iphone 8",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pharetra metus. Suspendisse p",
                CategoryName = "SmartPhones",
                Price = 2300.00m,
                ImageUrl = ""
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Samsumg Galaxy S21",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pharetra metus. Suspendisse p",
                CategoryName = "SmartPhones",
                Price = 3000.00M,
                ImageUrl = ""
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Xbox One",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pharetra metus. Suspendisse p",
                CategoryName = "Games",
                Price = 2699.00m,
                ImageUrl = ""
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Playstation 5",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pharetra metus. Suspendisse p",
                CategoryName = "Games",
                Price = 3800.00m,
                ImageUrl = ""
            });
        }
    }
}
