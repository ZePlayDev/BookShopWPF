using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookShopWPF
{
    public partial class MainWindow : Window
    {
		public static ShopDB context = new ShopDB();
		public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
           
            // Предполагая, что вы хотите загрузить данные клиентов
            dataGrid.ItemsSource = context.GetAllClients();

            // Если вы хотите загрузить данные продуктов, используйте следующую строку вместо предыдущей:
            // dataGrid.ItemsSource = context.GetProducts();
        }
    }
}
