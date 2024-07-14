

namespace WebStore.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category{Id=1,Name="Action",CategoryOrder=1},
                new Category{Id=2,Name="Racing",CategoryOrder=2},
                new Category{Id=3,Name="Fitting",CategoryOrder=3},
                new Category{Id=4,Name="Funny",CategoryOrder=4}
            });

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product
                {
                    Id = 1,
                    Name = "Gaming Mouse",
                    Description = "Ergonomic gaming mouse with customizable DPI",
                    Author = "Logitech",
                    ListPrice = 49.99,
                    Price = 45.99,
                    Price50 = 43.99,
                    Price100 = 39.99,
                    CategoryId = 1,
                    ImageName=""
                },
                new Product
                {
                    Id = 2,
                    Name = "Mechanical Keyboard",
                    Description = "Mechanical keyboard with RGB lighting",
                    Author = "Corsair",
                    ListPrice = 99.99,
                    Price = 89.99,
                    Price50 = 84.99,
                    Price100 = 79.99,
                    CategoryId = 1,
                    ImageName=""
                },
                new Product
                {
                    Id = 3,
                    Name = "Gaming Chair",
                    Description = "Comfortable gaming chair with lumbar support",
                    Author = "DXRacer",
                    ListPrice = 199.99,
                    Price = 179.99,
                    Price50 = 169.99,
                    Price100 = 159.99,
                    CategoryId = 2,
                    ImageName=""
                },
                new Product
                {
                    Id = 4,
                    Name = "4K Monitor",
                    Description = "27-inch 4K UHD monitor with HDR",
                    Author = "Samsung",
                    ListPrice = 399.99,
                    Price = 379.99,
                    Price50 = 359.99,
                    Price100 = 339.99,
                    CategoryId = 1,
                    ImageName=""
                },
                new Product
                {
                    Id = 5,
                    Name = "Gaming Headset",
                    Description = "Surround sound gaming headset with microphone",
                    Author = "HyperX",
                    ListPrice = 79.99,
                    Price = 74.99,
                    Price50 = 69.99,
                    Price100 = 64.99,
                    CategoryId = 1,
                    ImageName=""
                }
            });
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
