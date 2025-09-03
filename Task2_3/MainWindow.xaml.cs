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

namespace Task2_3
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

        private void ChooseButton_Click(object sender, RoutedEventArgs e)
        {
            string saveType;


            var selectedBrand = BrandNameListView.SelectedItems
                .Cast<ListViewItem>()
                .Select(item => item.Content.ToString())
                .ToList();

            if (!(MailChecked.IsChecked == true || DownloadChecked.IsChecked == true))
            {
                MessageBox.Show("Ошибка: необходимо выбрать вариант сохранения семейства!", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (selectedBrand.Count == 0)
            {
                MessageBox.Show("Ошибка: не выбран бренд!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(FamilyName.Text))
            {
                MessageBox.Show("Ошибка: не введено название семейства!", "Ошибка", 
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Формирование сообщения
            string message = $"Семейство скачано!\n\n"
                             + $"Имя семейства: {FamilyName.Text}.rfa\n"
                             + $"Категория: {CategoryName.Text}\n"
                             + $"Бренд: {string.Join(",", selectedBrand)}\n"
                             + $"Вариант скачивания: {(MailChecked.IsChecked == true ? "На почту" : "На компьютер")}";

            MessageBox.Show(message, "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
