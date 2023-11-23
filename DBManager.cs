using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;

namespace BookShopWPF
{
	public partial class ShopDB : DbContext
	{
		public DbSet<Client> Clients { get; set; }
		

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=laptop-npjv5e48;Database=ShopDB;Trusted_Connection=True;");
		}
	}
}
