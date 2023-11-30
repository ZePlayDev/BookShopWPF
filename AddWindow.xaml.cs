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

		public void AddProduct()
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


		}
		public void Cancel()
		{
			this.Close();
		}
	}
}
