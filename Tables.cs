using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BookShopWPF
{
	public class Client
	{
        [Key] public int ClientID { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
	}

	public class Manager
	{
		[Key] public int ManagerID { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
	}

	public class Administrator
	{
		[Key] public int AdminID { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
	}

	
	public class Product
	{
		[Key]
        public int ProductID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int StockQuantity { get; set; }
		public string CategoryID { get; set; }
		public string ManufacturerID { get; set; }
		public ICollection<ProductPhoto> ProductPhotos { get; set; }
	}

	public class Category
	{
		[Key]
        public int CategoryID { get; set; }
		public string Name { get; set; }
		public ICollection<Product> Products { get; set; }
	}

	public class Manufacturer
	{
        [Key] public int ManufactererID { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string ContactInfo { get; set; }
	}

	public class ProductPhoto
	{
		public int ProductPhotoID { get; set; }
		public string ProductID { get; set; }
		public string FilePath { get; set; }
		public Product Product { get; set; }
	}

}
