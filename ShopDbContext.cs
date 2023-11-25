using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookShopWPF;


// ЧТОБЫ СОЗДАТЬ ТАБЛИЦЫ В БД POSTGRESQL НАДО
// 1. СРЕДСТВА -> ДИСПЕТЧЕР ПАКЕТОВ -> КОНСОЛЬ
// 2. Add-Migration meow
// 3. Update-Database

public partial class ShopDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<ProductPhoto> ProductPhotos { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<PickupPoint> PickupPoints { get; set; }
    public DbSet<OrderPickup> OrderPickups { get; set; }
    public DbSet<Staff> Staff { get; set; }

    public ShopDbContext()
    {
    }

    public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ShopDB;Username=postgres;Password=1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public List<Client> GetClients() => Clients.ToList();

    public List<Product> GetProducts() => Products.ToList();

    public List<Category> GetCategories() => Categories.ToList();

    public List<Manufacturer> GetManufacturers() => Manufacturers.ToList();

    public List<ProductPhoto> GetProductPhotos() => ProductPhotos.ToList();

    public List<Orders> GetOrders() => Orders.ToList();

    public List<OrderDetails> GetOrderDetails() => OrderDetails.ToList();

    public List<PickupPoint> GetPickupPoints() => PickupPoints.ToList();

    public List<OrderPickup> GetOrderPickups() => OrderPickups.ToList();

    public List<Staff> GetStaff() => Staff.ToList();
}
