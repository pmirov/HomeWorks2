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

namespace Task2_1_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int count = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Color red = Color.FromRgb(255, 0, 0);
            Color yellow = Color.FromRgb(255, 255, 0);
            Color green = Color.FromRgb(0, 128, 0);
            Color gray = Color.FromRgb(179, 179, 179);
            switch (count)
            {
                case 0:
                    Ellipse1.Fill = new SolidColorBrush(red);
                    Ellipse2.Fill = new SolidColorBrush(gray);
                    Ellipse3.Fill = new SolidColorBrush(gray);
                    break;
                case 1:
                    Ellipse2.Fill = new SolidColorBrush(yellow);
                    Ellipse1.Fill = new SolidColorBrush(gray);
                    Ellipse3.Fill = new SolidColorBrush(gray);
                    break;
                case 2:
                    Ellipse3.Fill = new SolidColorBrush(green);
                    Ellipse1.Fill = new SolidColorBrush(gray);
                    Ellipse2.Fill = new SolidColorBrush(gray);
                    break;

            }
            count++;
            if (count == 3) count = 0;

        }
    }
}
