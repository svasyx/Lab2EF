// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab2EF.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221227192456_AddedTable5")]
    partial class AddedTable5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bill", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("DiscCardID")
                        .HasColumnType("int");

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfPay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateofPay")
                        .HasColumnType("datetime2");

                    b.Property<float?>("discValue")
                        .HasColumnType("real");

                    b.Property<int>("finalPrice")
                        .HasColumnType("int");

                    b.Property<int?>("pharmacistID")
                        .HasColumnType("int");

                    b.Property<string>("shopperphoneNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("pharmacistID");

                    b.HasIndex("shopperphoneNum");

                    b.ToTable("Bill", t =>
                        {
                            t.HasCheckConstraint("finalPrice", "[finalPrice] > 0");
                        });
                });

            modelBuilder.Entity("GoodsInStorage", b =>
                {
                    b.Property<int>("place")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("place"));

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.HasKey("place");

                    b.ToTable("GoodsInStorage");
                });

            modelBuilder.Entity("Medicine", b =>
                {
                    b.Property<float>("Article")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.Property<DateTime>("expDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("goodsInStorageplace")
                        .HasColumnType("int");

                    b.Property<int>("producerID")
                        .HasColumnType("int");

                    b.Property<bool>("receipeneed")
                        .HasColumnType("bit");

                    b.Property<float>("temperature")
                        .HasColumnType("real");

                    b.HasKey("Article");

                    b.HasIndex("goodsInStorageplace");

                    b.HasIndex("producerID");

                    b.ToTable("Medicine", t =>
                        {
                            t.HasCheckConstraint("count", "[count] > 0");
                        });
                });

            modelBuilder.Entity("MedicinemedicineList", b =>
                {
                    b.Property<float>("listifmedlistsArticle")
                        .HasColumnType("real");

                    b.Property<int>("medicineListsID")
                        .HasColumnType("int");

                    b.HasKey("listifmedlistsArticle", "medicineListsID");

                    b.HasIndex("medicineListsID");

                    b.ToTable("ListToList", (string)null);
                });

            modelBuilder.Entity("Pharmacist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Pharmacist");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pharmacist");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Producer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("licenseNum")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("Producer");
                });

            modelBuilder.Entity("Recipe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("billID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("billID")
                        .IsUnique()
                        .HasFilter("[billID] IS NOT NULL");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("Shopper", b =>
                {
                    b.Property<string>("phoneNum")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ID_discountcard")
                        .HasColumnType("int");

                    b.Property<float?>("discountValue")
                        .HasMaxLength(12)
                        .HasColumnType("real");

                    b.HasKey("phoneNum");

                    b.ToTable("Shopper", t =>
                        {
                            t.HasCheckConstraint("discountValue", "[discountValue] <= 1");
                        });
                });

            modelBuilder.Entity("medicineList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("billID")
                        .HasColumnType("int");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<string>("unitOfMeasurement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("billID")
                        .IsUnique();

                    b.ToTable("medicineList", t =>
                        {
                            t.HasCheckConstraint("count", "[count] > 0")
                                .HasName("count1");

                            t.HasCheckConstraint("price", "[price] > 0");
                        });
                });

            modelBuilder.Entity("Admin", b =>
                {
                    b.HasBaseType("Pharmacist");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Bill", b =>
                {
                    b.HasOne("Pharmacist", "pharmacist")
                        .WithMany("bills")
                        .HasForeignKey("pharmacistID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shopper", "shopper")
                        .WithMany("bills")
                        .HasForeignKey("shopperphoneNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pharmacist");

                    b.Navigation("shopper");
                });

            modelBuilder.Entity("Medicine", b =>
                {
                    b.HasOne("GoodsInStorage", "goodsInStorage")
                        .WithMany("medicines")
                        .HasForeignKey("goodsInStorageplace")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Producer", "producer")
                        .WithMany("medicines")
                        .HasForeignKey("producerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("goodsInStorage");

                    b.Navigation("producer");
                });

            modelBuilder.Entity("MedicinemedicineList", b =>
                {
                    b.HasOne("Medicine", null)
                        .WithMany()
                        .HasForeignKey("listifmedlistsArticle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("medicineList", null)
                        .WithMany()
                        .HasForeignKey("medicineListsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Recipe", b =>
                {
                    b.HasOne("Bill", null)
                        .WithOne("recipe")
                        .HasForeignKey("Recipe", "billID");
                });

            modelBuilder.Entity("medicineList", b =>
                {
                    b.HasOne("Bill", null)
                        .WithOne("medicineList")
                        .HasForeignKey("medicineList", "billID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bill", b =>
                {
                    b.Navigation("medicineList")
                        .IsRequired();

                    b.Navigation("recipe");
                });

            modelBuilder.Entity("GoodsInStorage", b =>
                {
                    b.Navigation("medicines");
                });

            modelBuilder.Entity("Pharmacist", b =>
                {
                    b.Navigation("bills");
                });

            modelBuilder.Entity("Producer", b =>
                {
                    b.Navigation("medicines");
                });

            modelBuilder.Entity("Shopper", b =>
                {
                    b.Navigation("bills");
                });
#pragma warning restore 612, 618
        }
    }
}
