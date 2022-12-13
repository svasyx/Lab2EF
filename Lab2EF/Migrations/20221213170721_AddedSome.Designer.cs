﻿// <auto-generated />
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
    [Migration("20221213170721_AddedSome")]
    partial class AddedSome
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

                    b.Property<int>("producerID")
                        .HasColumnType("int");

                    b.Property<bool>("receipeneed")
                        .HasColumnType("bit");

                    b.Property<float>("temperature")
                        .HasColumnType("real");

                    b.HasKey("Article");

                    b.HasIndex("producerID");

                    b.ToTable("Medicine", t =>
                        {
                            t.HasCheckConstraint("count", "[count] > 0");
                        });
                });

            modelBuilder.Entity("Pharmacist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Pharmacist");
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

                    b.Property<int?>("BillID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BillID")
                        .IsUnique()
                        .HasFilter("[BillID] IS NOT NULL");

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

                    b.Property<float>("Article")
                        .HasColumnType("real");

                    b.Property<int>("billID")
                        .HasColumnType("int");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<string>("unitOfMeasurement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Article");

                    b.HasIndex("billID");

                    b.ToTable("medicineList", t =>
                        {
                            t.HasCheckConstraint("count", "[count] > 0")
                                .HasName("count1");

                            t.HasCheckConstraint("price", "[price] > 0");
                        });
                });

            modelBuilder.Entity("Bill", b =>
                {
                    b.HasOne("Pharmacist", "pharmacist")
                        .WithMany()
                        .HasForeignKey("pharmacistID");

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
                    b.HasOne("Producer", "producer")
                        .WithMany()
                        .HasForeignKey("producerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("producer");
                });

            modelBuilder.Entity("Recipe", b =>
                {
                    b.HasOne("Bill", null)
                        .WithOne("recipe")
                        .HasForeignKey("Recipe", "BillID");
                });

            modelBuilder.Entity("medicineList", b =>
                {
                    b.HasOne("Medicine", "article")
                        .WithMany()
                        .HasForeignKey("Article")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bill", "bill")
                        .WithMany()
                        .HasForeignKey("billID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("article");

                    b.Navigation("bill");
                });

            modelBuilder.Entity("Bill", b =>
                {
                    b.Navigation("recipe");
                });

            modelBuilder.Entity("Shopper", b =>
                {
                    b.Navigation("bills");
                });
#pragma warning restore 612, 618
        }
    }
}
