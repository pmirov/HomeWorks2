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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task2_1_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            int maxWidth = Convert.ToInt32(MainGrid.ActualWidth - Button.ActualWidth);
            int maxHeight = Convert.ToInt32(MainGrid.ActualHeight - Button.ActualHeight);
            Random random = new Random();
            Button.Margin = new Thickness(random.Next(1, maxWidth), random.Next(1, maxHeight), 0, 0);
        }
    }
}
