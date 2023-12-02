using System;
using System.Windows;
using System.Windows.Controls;

namespace BookShopWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            var context = ShopDbContext.Instance; 
           
            //dataGrid.ItemsSource = context.GetClients();

            // Если вы хотите загрузить данные продуктов, используйте следующую строку вместо предыдущей:
            dataGrid.ItemsSource = context.GetProducts();
        }
        public void AddProduct(object sender, EventArgs e)
        {
            AddWindow addWindow = new AddWindow();

            addWindow.Show();
            Close();
        }

		private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}

