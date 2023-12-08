using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace BookShopWPF
{
	public class TableRow
	{
		public int ProductID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int StockQuantity { get; set; }
		public string CategoryID { get; set; }
		public string ManufacturerID { get; set; }

	}

	public partial class MainWindow : Window
    {
		public ObservableCollection<TableRow> Items { get; set; }

        public static MainWindow instance;

		public MainWindow()
        {
            InitializeComponent();
            instance= this;
            LoadData();
        }

        public void LoadData()
        {
			var context = ShopDbContext.Instance;
            Items = new();

           // MessageBox.Show(context.GetProducts().Count.ToString());

			foreach(var item in context.GetProducts())
            {
                Items.Add(new TableRow()
                {
                    ProductID = item.ProductID, 
                    Name = item.Name, 
                    Description = item.Description, 
                    CategoryID= item.CategoryID, 
                    ManufacturerID= item.ManufacturerID, 
                    Price = item.Price, 
                    StockQuantity=item.StockQuantity
                });
              //  MessageBox.Show("Добавлен");
            }
            dataGrid.ItemsSource = Items;

			//dataGrid.ItemsSource = context.GetProducts();
        }
        public void AddProduct(object sender, EventArgs e)
        {
			if (!ShopDbContext.Instance.CanGetAccess(AccessLevels.Admin))
			{
				MessageBox.Show("нету прав");
				return;
			}
			AddWindow addWindow = new AddWindow();

            addWindow.ShowDialog();
           // Close();
        }

		public void AddToCart(object sender, EventArgs e)
		{
			if (dataGrid.SelectedItem == null) return;
			var item = dataGrid.SelectedItem as TableRow;

			var cart = ShopDbContext.Instance.Cart.Where(x => x.UserID == ShopDbContext.Instance.activeUserID).FirstOrDefault();

			if (cart == null)
			{
				cart = new Cart()
				{
					UserID = ShopDbContext.Instance.activeUserID,
					ProductID = new()
				};
				if (!cart.ProductID.Contains(item.ProductID))
				{
					cart.ProductID.Add(item.ProductID);
					ShopDbContext.Instance.Cart.Add(cart);
					ShopDbContext.Instance.SaveChanges();
				}
				else MessageBox.Show("Этот продукт уже добавлен в вашу корзину");
				
				return;
			}
			if (!cart.ProductID.Contains(item.ProductID))
			{
				cart.ProductID.Add(item.ProductID);
				ShopDbContext.Instance.Cart.Add(cart);
				ShopDbContext.Instance.SaveChanges();
			}
			else MessageBox.Show("Этот продукт уже добавлен в вашу корзину");
		}

		public void OpenCart(object sender, EventArgs e)
		{
			CartWindow cart = new CartWindow();
			cart.ShowDialog();
		}


		public void EditProduct(object sender, EventArgs e)
		{
			if (!ShopDbContext.Instance.CanGetAccess(AccessLevels.Manager))
			{
				MessageBox.Show("нету прав");
				return;
			}

			if (dataGrid.SelectedItem == null) return;

			var item = dataGrid.SelectedItem as TableRow;

			//MessageBox.Show(Items[dataGrid.SelectedIndex].Price);
			Product selectedProduct = new Product()
			{
				ProductID = item.ProductID,
				Name = item.Name,
				Description = item.Description,
				StockQuantity = item.StockQuantity,
				ManufacturerID = item.ManufacturerID,
				Price = item.Price,
				CategoryID = item.CategoryID
			};
			AddWindow addWindow = new AddWindow(selectedProduct, dataGrid.SelectedIndex);
			addWindow.ShowDialog();
		}

		public void DeleteProduct(object sender, EventArgs e)
		{
			if (!ShopDbContext.Instance.CanGetAccess(AccessLevels.Admin))
			{
				MessageBox.Show("нету прав");
				return;
			}
			if (dataGrid.SelectedItem == null) return;
			var item = dataGrid.SelectedItem as TableRow;

			Product selectedProduct = ShopDbContext.Instance.Products.FirstOrDefault(x => x.ProductID == item.ProductID);
			ShopDbContext.Instance.Products.Remove(selectedProduct);
			ShopDbContext.Instance.SaveChanges();
			LoadData();
		}

		private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}

