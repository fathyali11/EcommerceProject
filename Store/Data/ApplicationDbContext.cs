

using Store.Models;

namespace Store.Data
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
        }
        public DbSet<Category> Categories { get; set; }
    }
}
