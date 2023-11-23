using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BookShopWPF
{
	public class Client
	{
		public int ClientID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public ICollection<Orders> Orders { get; set; }
	}

	public class Product
	{
		public int ProductID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int StockQuantity { get; set; }
		public int CategoryID { get; set; }
		public int ManufacturerID { get; set; }
		public Category Category { get; set; }
		public Manufacturer Manufacturer { get; set; }
		public ICollection<ProductPhoto> ProductPhotos { get; set; }
		public ICollection<OrderDetails> OrderDetails { get; set; }
	}

	public class Category
	{
		public int CategoryID { get; set; }
		public string Name { get; set; }
		public ICollection<Product> Products { get; set; }
	}

	public class Manufacturer
	{
		public int ManufactererID { get; set; }
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

	public class Orders
	{
		public int OrderID { get; set; }
		public int ClientsID { get; set; }
		public DateTime OrderData { get; set; }
		public decimal TotalAmount { get; set; }
		public Client Client { get; set; }
		public ICollection<OrderDetails> OrderDetails { get; set; }

		// Конструктор для инициализации коллекции
		public Orders()
		{
			OrderDetails = new HashSet<OrderDetails>();
		}
	}

	public class OrderDetails
	{
		public int OrderDetailsID { get; set; }

		public int OrderID { get; set; }
		public int ProductID { get; set; }
		public int Quantity { get; set; }
		public Orders Orders { get; set; }
		public Product Product { get; set; }
	} 

	public class PickupPoint
	{
		public int PickupPointID { get; set; }
		public string Address { get; set; }
		public string Description { get; set; }
	}

	public class OrderPickup
	{
		public int OrderPickupID { get; set; }
		public int OrderID { get; set; }
		public int PickupPointID { get; set; }
		public Orders Orders { get; set; }
		public PickupPoint PickupPoint { get; set; }
	}

	public class Staff
	{
		public int StaffID { get; set; }
		public string Name { get; set; }
		public string Position { get; set; }
		public string ContactInfo { get; set; }
	}
}
