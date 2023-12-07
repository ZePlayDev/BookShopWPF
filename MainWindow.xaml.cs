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
		public string ProductID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Price { get; set; }
		public string StockQuantity { get; set; }
		public string CategoryID { get; set; }
		public string ManufacturerID { get; set; }

	}

	public partial class MainWindow : Window
    {
		public ObservableCollection<TableRow> Items { get; set; }

        public static ObservableCollection<TableRow> StaticItems;

		public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
			var context = ShopDbContext.Instance;
            Items = new();
            StaticItems = Items;

           // MessageBox.Show(context.GetProducts().Count.ToString());

			foreach(var item in context.GetProducts())
            {
                Items.Add(new TableRow()
                {
                    ProductID = item.ProductID.ToString(), 
                    Name = item.Name, 
                    Description = item.Description, 
                    CategoryID= item.CategoryID, 
                    ManufacturerID= item.ManufacturerID, 
                    Price = item.Price.ToString(), 
                    StockQuantity=item.StockQuantity.ToString()
                });
              //  MessageBox.Show("Добавлен");
            }
            dataGrid.ItemsSource = Items;

			//dataGrid.ItemsSource = context.GetProducts();
        }
        public void AddProduct(object sender, EventArgs e)
        {
            AddWindow addWindow = new AddWindow();

            addWindow.ShowDialog();
           // Close();
        }

        public void EditProduct(object sender, EventArgs e)
        {
			if (dataGrid.SelectedItem != null)
			{
                //MessageBox.Show(Items[dataGrid.SelectedIndex].Price);
                Product selectedProduct = new Product(){
                    ProductID = int.Parse(Items[dataGrid.SelectedIndex].ProductID),
                    Name = Items[dataGrid.SelectedIndex].Name,
                    Description = Items[dataGrid.SelectedIndex].Description,
                    StockQuantity = int.Parse(Items[dataGrid.SelectedIndex].StockQuantity),
                    ManufacturerID = Items[dataGrid.SelectedIndex].ManufacturerID,
                    Price = int.Parse(Items[dataGrid.SelectedIndex].Price),
                    CategoryID = Items[dataGrid.SelectedIndex].CategoryID
                };
				AddWindow addWindow = new AddWindow(selectedProduct);
				addWindow.ShowDialog();
			}
		}

		private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}

