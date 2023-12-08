using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BookShopWPF
{
	/// <summary>
	/// Логика взаимодействия для CartWindow.xaml
	/// </summary>
	public partial class CartWindow : Window
	{
		public decimal finalCostOfCart;

		public ObservableCollection<TableRow> Items = new();
	
		public CartWindow()
		{
			InitializeComponent();   
			LoadCart();
		}


		public void LoadCart()
		{
			finalCostOfCart = 0;
			var cart = ShopDbContext.Instance.Cart.Where(x => x.UserID == ShopDbContext.Instance.activeUserID).FirstOrDefault();
			foreach(int product in cart.ProductID)
			{
				var item = ShopDbContext.Instance.GetProducts().First(x => x.ProductID == product);
				finalCostOfCart += item.Price;
				Items.Add(new TableRow()
				{
					ProductID = item.ProductID,
					Name = item.Name,
					Description = item.Description,
					CategoryID = item.CategoryID,
					ManufacturerID = item.ManufacturerID,
					Price = item.Price,
					StockQuantity = item.StockQuantity
				});
			}
			dataGrid.ItemsSource = Items;
			TotalCostText.Text = $"Итого к оплате: {finalCostOfCart}";
		}

		public void RemoveFromCarts(object sender, EventArgs e)
		{
			if (dataGrid.SelectedItem == null) return;
			var item = dataGrid.SelectedItem as TableRow;
			var cart = ShopDbContext.Instance.Cart.Where(x => x.UserID == ShopDbContext.Instance.activeUserID).FirstOrDefault();
			cart.ProductID.Remove(item.ProductID);
			LoadCart();
		}

		public void CloseCart(object sender, EventArgs e)
		{
			Close();
		}

		public void BuyProducts(object sender, EventArgs e)
		{
			MessageBox.Show("Покупка прошла успешно");
			var cart = ShopDbContext.Instance.Cart.Where(x => x.UserID == ShopDbContext.Instance.activeUserID).FirstOrDefault();
			cart.ProductID.Clear();
			LoadCart();
		}

	}
}
