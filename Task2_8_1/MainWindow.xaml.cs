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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task2_8_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> products = new ObservableCollection<Product>();

        public MainWindow()
        {
            InitializeComponent();
            products.Add(new Product()
            {
                ProductName = "Бананы",
                Price = 100,
                Category = Categories.Food,
                ImagePath = "images/banana.png"
            });
            products.Add(new Product()
            {
                ProductName = "Стиральная машина",
                Price = 20000,
                Category = Categories.Appliances,
                ImagePath = "images/laundry-machine.png"

            });
            products.Add(new Product()
            {
                ProductName = "Арбуз",
                Price = 300,
                Category = Categories.Food,
                ImagePath = "images/watermelon.png"
            });
            products.Add(new Product()
            {
                ProductName = "Микроволновая печь",
                Price = 6000,
                Category = Categories.Appliances,
                ImagePath = "images/microwave-oven.png"
            });
            listBox.ItemsSource = products;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            products.Add(new Product()
            {
                ProductName = "Макароны",
                Price = 100,
                Category = Categories.Food,
                ImagePath = "images/pasta.png"

            });
        }
    }
}
