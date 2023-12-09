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
			Items = new();
			finalCostOfCart = 0;
			var cart = ShopDbContext.Instance.Cart.Where(x => x.UserID == ShopDbContext.Instance.activeUserID).FirstOrDefault();

			// Используйте словарь для отслеживания товаров
			Dictionary<int, TableRow> itemsDict = new Dictionary<int, TableRow>();

			foreach (int product in cart.ProductID)
			{
				var item = ShopDbContext.Instance.GetProducts().First(x => x.ProductID == product);

				// Проверьте, существует ли уже такой товар в словаре
				if (itemsDict.TryGetValue(item.ProductID, out TableRow existingItem))
				{
					// Увеличьте количество и общую стоимость
					existingItem.StockQuantity++;
					finalCostOfCart += item.Price;
				}
				else
				{
					// Добавьте новый товар
					var newItem = new TableRow()
					{
						ProductID = item.ProductID,
						Name = item.Name,
						Description = item.Description,
						CategoryID = item.CategoryID,
						ManufacturerID = item.ManufacturerID,
						Price = item.Price,
						StockQuantity = 1,
					};
					itemsDict.Add(item.ProductID, newItem);
					finalCostOfCart += item.Price;
				}
			}

			// Преобразуйте словарь обратно в список для отображения
			foreach (var item in itemsDict.Values)
				Items.Add(item);

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
