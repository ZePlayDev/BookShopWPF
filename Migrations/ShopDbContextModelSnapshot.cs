﻿// <auto-generated />
using System;
using BookShopWPF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookShopWPF.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookShopWPF.Administrator", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AdminID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AdminID");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("BookShopWPF.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BookShopWPF.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ClientID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ClientID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BookShopWPF.Manager", b =>
                {
                    b.Property<int>("ManagerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ManagerID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ManagerID");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("BookShopWPF.Manufacturer", b =>
                {
                    b.Property<int>("ManufactererID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ManufactererID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ManufactererID");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("BookShopWPF.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductID"));

                    b.Property<string>("CategoryID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CategoryID1")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ManufacturerID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("integer");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID1");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BookShopWPF.ProductPhoto", b =>
                {
                    b.Property<int>("ProductPhotoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductPhotoID"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductID1")
                        .HasColumnType("integer");

                    b.HasKey("ProductPhotoID");

                    b.HasIndex("ProductID1");

                    b.ToTable("ProductPhotos");
                });

            modelBuilder.Entity("BookShopWPF.Product", b =>
                {
                    b.HasOne("BookShopWPF.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryID1");
                });

            modelBuilder.Entity("BookShopWPF.ProductPhoto", b =>
                {
                    b.HasOne("BookShopWPF.Product", "Product")
                        .WithMany("ProductPhotos")
                        .HasForeignKey("ProductID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BookShopWPF.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BookShopWPF.Product", b =>
                {
                    b.Navigation("ProductPhotos");
                });
#pragma warning restore 612, 618
        }
    }
}
