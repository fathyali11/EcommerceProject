



namespace WebStore.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser  >
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
                    OldPrice = 49.99,
                    NewPrice = 45.99,
                    CategoryId = 1,
                    ImageName=""
                },
                new Product
                {
                    Id = 2,
                    Name = "Mechanical Keyboard",
                    Description = "Mechanical keyboard with RGB lighting",
                    Author = "Corsair",
                    OldPrice = 99.99,
                    NewPrice = 89.99,
                    CategoryId = 1,
                    ImageName=""
                },
                new Product
                {
                    Id = 3,
                    Name = "Gaming Chair",
                    Description = "Comfortable gaming chair with lumbar support",
                    Author = "DXRacer",
                    OldPrice = 199.99,
                    NewPrice = 179.99,
                    CategoryId = 2,
                    ImageName=""
                },
                new Product
                {
                    Id = 4,
                    Name = "4K Monitor",
                    Description = "27-inch 4K UHD monitor with HDR",
                    Author = "Samsung",
                    OldPrice = 399.99,
                    NewPrice = 379.99,
                    CategoryId = 1,
                    ImageName=""
                },
                new Product
                {
                    Id = 5,
                    Name = "Gaming Headset",
                    Description = "Surround sound gaming headset with microphone",
                    Author = "HyperX",
                    OldPrice = 79.99,
                    NewPrice = 74.99,
                    CategoryId = 1,
                    ImageName=""
                }
            });
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser  > ApplicationUsers  { get; set; }
    }
}
