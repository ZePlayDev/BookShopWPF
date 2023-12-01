using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookShopWPF
{
	/// <summary>
	/// Логика взаимодействия для AddWindow.xaml
	/// </summary>
	public partial class AddWindow : Window
	{
		public AddWindow()
		{
			InitializeComponent();
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

			string connectionString = "Host=localhost;Port=5432;Database=ShopDB;Username=postgres;Password=OlgaK+15;";
			string author = ManufacturerBox.Text; // Предполагаем, что AuthorBox - это ваш TextBox для автора
			string name = NameBox.Text; // Предполагаем, что NameBox - это ваш TextBox для названия

			if (!IsProductUnique(author, name))
			{
				MessageBox.Show("Продукт с таким автором и названием уже существует.");
				return;
			}
			string sql = "INSERT INTO \"Products\" ( \"Name\", \"Description\", \"Price\", \"StockQuantity\", \"CategoryID\", \"ManufacturerID\") VALUES ( @Name, @Description, @Price, @Quantity, @CategoryID, @Manufacturer);";

			using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
			{
				connection.Open();
				using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@Name", (string)NameBox.Text);
					command.Parameters.AddWithValue("@Description", DescriptionBox.Text);
					command.Parameters.AddWithValue("@Price", decimal.Parse(PriceBox.Text)); // Предполагая, что цена - это decimal
					command.Parameters.AddWithValue("@Quantity", int.Parse(QuantityBox.Text));
					command.Parameters.AddWithValue("@CategoryID", (string)CategoryIDBox.Text);
					command.Parameters.AddWithValue("@Manufacturer", (string)ManufacturerBox.Text);

					command.ExecuteNonQuery();
				}
			}
		}
		public bool IsProductUnique(string author, string name)
		{
			string connectionString = "Host=localhost;Port=5432;Database=ShopDB;Username=postgres;Password=OlgaK+15;";
			string sql = "SELECT COUNT(*) FROM Products WHERE Manufacturer = @Manufacturer AND Name = @Name";

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
