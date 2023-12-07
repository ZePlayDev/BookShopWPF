using Npgsql;
using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Windows;

namespace BookShopWPF
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
	/// 

	//Вы долбаебы? нахуя энтити фреймворк тогда, если вы так хардкодите
    public partial class AddWindow : Window
	{
		public AddWindow()
		{
			InitializeComponent();
		}

		public AddWindow(Product selectedProduct)
		{
			InitializeComponent();
			NameBox.Text = selectedProduct.Name;
			DescriptionBox.Text = selectedProduct.Description;
			PriceBox.Text = selectedProduct.Price.ToString();
			QuantityBox.Text = selectedProduct.StockQuantity.ToString();
			CategoryIDBox.Text = selectedProduct.CategoryID.ToString();
			ManufacturerBox.Text = selectedProduct.ManufacturerID.ToString();
		}

		public void AddProduct(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(NameBox.Text)||
				string.IsNullOrEmpty(DescriptionBox.Text)||
				string.IsNullOrEmpty(PriceBox.Text)||
				string.IsNullOrEmpty(QuantityBox.Text)||
				string.IsNullOrEmpty(CategoryIDBox.Text)||
				string.IsNullOrEmpty(ManufacturerBox.Text)
				)
			{
				MessageBox.Show("Заполните все поля");
				return;
			}

			//string connectionString = "Host=localhost;Port=5432;Database=ShopDB;Username=postgres;Password=OlgaK+15;";
			string author = ManufacturerBox.Text; 
			string name = NameBox.Text;

			if (!IsProductUnique(author, name))
			{
				MessageBox.Show("Продукт с таким автором и названием уже существует.");
				return;
			}
			//string sql = "INSERT INTO \"Products\" ( \"Name\", \"Description\", \"Price\", \"StockQuantity\", \"CategoryID\", \"ManufacturerID\") VALUES ( @Name, @Description, @Price, @Quantity, @CategoryID, @Manufacturer);";

			//using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
			//{
			//	connection.Open();
			//	using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
			//	{
			//		command.Parameters.AddWithValue("@Name", (string)NameBox.Text);
			//		command.Parameters.AddWithValue("@Description", DescriptionBox.Text);
			//		command.Parameters.AddWithValue("@Price", decimal.Parse(PriceBox.Text)); // Предполагая, что цена - это decimal
			//		command.Parameters.AddWithValue("@Quantity", int.Parse(QuantityBox.Text));
			//		command.Parameters.AddWithValue("@CategoryID", (string)CategoryIDBox.Text);
			//		command.Parameters.AddWithValue("@Manufacturer", (string)ManufacturerBox.Text);

			//		command.ExecuteNonQuery();
			//	}
			//}
			//MainWindow mainWindow = new MainWindow();
			//mainWindow.Show();
			Product item = new Product()
			{
				Name = NameBox.Text,
				Description = DescriptionBox.Text,
				Price = decimal.Parse(PriceBox.Text),
				StockQuantity = int.Parse(QuantityBox.Text),
				CategoryID = CategoryIDBox.Text,
				ManufacturerID = ManufacturerBox.Text
			};
			ShopDbContext.Instance.Products.Add(item);
			ShopDbContext.Instance.SaveChanges();
			MainWindow.StaticItems.Add(new TableRow() {        
					ProductID = item.ProductID.ToString(),
					Name = item.Name,
					Description = item.Description,
					CategoryID= item.CategoryID,
					ManufacturerID= item.ManufacturerID,
					Price = item.Price.ToString(),
					StockQuantity=item.StockQuantity.ToString()
				});
			this.Close();
		}
		public bool IsProductUnique(string author, string name)
		{
			string connectionString = "Host=localhost;Port=5432;Database=ShopDB;Username=postgres;Password=OlgaK+15;";
			string sql = "SELECT COUNT(*) FROM \"Products\" WHERE \"ManufacturerID\" = @Manufacturer AND \"Name\" = @Name";

			using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
			{
				connection.Open();
				using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@Manufacturer", author);
					command.Parameters.AddWithValue("@Name", name);
	
					int count = Convert.ToInt32(command.ExecuteScalar());
					return count == 0;
				}
			}
		}

		public void Cancel(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
