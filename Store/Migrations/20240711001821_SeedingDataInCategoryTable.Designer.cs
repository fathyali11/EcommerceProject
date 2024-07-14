


#nullable disable



namespace WebStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240711001821_SeedingDataInCategoryTable")]
    partial class SeedingDataInCategoryTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebStore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            CategoryOrder = 2,
                            Name = "Racing"
                        },
                        new
                        {
                            Id = 3,
                            CategoryOrder = 3,
                            Name = "Fitting"
                        },
                        new
                        {
                            Id = 4,
                            CategoryOrder = 4,
                            Name = "Funny"
                        });
                });
#pragma warning reWebStore 612, 618
        }
    }
}
