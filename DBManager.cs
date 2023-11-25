using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookShopWPF
{
	public partial class ShopDB : DbContext
	{
		public DbSet<Client> Clients { get; set; }
		public DbSet<Product> Products  { get; set; }
		public DbSet<Category> Categories  { get; set; }
		public DbSet<Manufacturer> Manufacturers  { get; set; }
		public DbSet<ProductPhoto> ProductPhotos  { get; set; }
		public DbSet<Orders> Orders  { get; set; }
		public DbSet<OrderDetails> OrderDetails  { get; set; }
		public DbSet<PickupPoint> PickupPoints  { get; set; }
		public DbSet<OrderPickup> OrderPickups { get; set; }
		public DbSet<Staff> Staff  { get; set; }
		

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-FSQ68S6\SQLEXPRESS;Database=ShopDB;Trusted_Connection=True;");
		}

        public List<Client> GetClients()
        {
            return Clients.ToList();
        }

        public List<Product> GetProducts()
        {
            return Products.ToList();
        }

        public List<Category> GetCategories()
        {
            return Categories.ToList();
        }

        public List<Manufacturer> GetManufacturers()
        {
            return Manufacturers.ToList();
        }

        public List<ProductPhoto> GetProductPhotos()
        {
            return ProductPhotos.ToList();
        }

        public List<Orders> GetOrders()
        {
            return Orders.ToList();
        }

        public List<OrderDetails> GetOrderDetails()
        {
            return OrderDetails.ToList();
        }

        public List<PickupPoint> GetPickupPoints()
        {
            return PickupPoints.ToList();
        }

        public List<OrderPickup> GetOrderPickups()
        {
            return OrderPickups.ToList();
        }

        public List<Staff> GetStaff()
        {
            return Staff.ToList();
        }
    }
}
