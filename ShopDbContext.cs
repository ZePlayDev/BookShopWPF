using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookShopWPF;


// ЧТОБЫ СОЗДАТЬ ТАБЛИЦЫ В БД POSTGRESQL НАДО
// 1. СРЕДСТВА -> ДИСПЕТЧЕР ПАКЕТОВ -> КОНСОЛЬ
// 2. Scaffold-DbContext "Ваша строка подключения" Npgsql.EntityFrameworkCore.PostgreSQL
// 3. Add-Migration meow
// 4. Update-Database

public partial class ShopDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
	public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<ProductPhoto> ProductPhotos { get; set; }

    public ShopDbContext()
    {
    }

    public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ShopDB;Username=postgres;Password=OlgaK+15");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public List<Client> GetClients() => Clients.ToList();

    public List<Manager> GetManagers() => Managers.ToList();

    public List<Administrator> GetAdministrators => Administrators.ToList();

    public List<Product> GetProducts() => Products.ToList();

    public List<Category> GetCategories() => Categories.ToList();

    public List<Manufacturer> GetManufacturers() => Manufacturers.ToList();

    public List<ProductPhoto> GetProductPhotos() => ProductPhotos.ToList();

}
