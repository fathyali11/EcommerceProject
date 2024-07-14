﻿
#nullable disable

namespace WebStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240714023736_CreateProductTableAndSeedingData")]
    partial class CreateProductTableAndSeedingData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication_Models.Category", b =>
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

            modelBuilder.Entity("WebApplication_Models.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Logitech",
                            CategoryId = 1,
                            Description = "Ergonomic gaming mouse with customizable DPI",
                            ListPrice = 49.990000000000002,
                            Name = "Gaming Mouse",
                            Price = 45.990000000000002,
                            Price100 = 39.990000000000002,
                            Price50 = 43.990000000000002
                        },
                        new
                        {
                            Id = 2,
                            Author = "Corsair",
                            CategoryId = 1,
                            Description = "Mechanical keyboard with RGB lighting",
                            ListPrice = 99.989999999999995,
                            Name = "Mechanical Keyboard",
                            Price = 89.989999999999995,
                            Price100 = 79.989999999999995,
                            Price50 = 84.989999999999995
                        },
                        new
                        {
                            Id = 3,
                            Author = "DXRacer",
                            CategoryId = 2,
                            Description = "Comfortable gaming chair with lumbar support",
                            ListPrice = 199.99000000000001,
                            Name = "Gaming Chair",
                            Price = 179.99000000000001,
                            Price100 = 159.99000000000001,
                            Price50 = 169.99000000000001
                        },
                        new
                        {
                            Id = 4,
                            Author = "Samsung",
                            CategoryId = 1,
                            Description = "27-inch 4K UHD monitor with HDR",
                            ListPrice = 399.99000000000001,
                            Name = "4K Monitor",
                            Price = 379.99000000000001,
                            Price100 = 339.99000000000001,
                            Price50 = 359.99000000000001
                        },
                        new
                        {
                            Id = 5,
                            Author = "HyperX",
                            CategoryId = 1,
                            Description = "Surround sound gaming headset with microphone",
                            ListPrice = 79.989999999999995,
                            Name = "Gaming Headset",
                            Price = 74.989999999999995,
                            Price100 = 64.989999999999995,
                            Price50 = 69.989999999999995
                        });
                });

            modelBuilder.Entity("WebApplication_Models.Models.Product", b =>
                {
                    b.HasOne("WebApplication_Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
