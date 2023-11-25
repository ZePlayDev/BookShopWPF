using System;
using System.Collections.Generic;
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
			optionsBuilder.UseSqlServer(@"Server=laptop-npjv5e48;Database=ShopDB;Trusted_Connection=True;");
		}


	}
}
