using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Task2_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentFileName = "Безымянный.txt";
        private string path;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.WindowStyle = WindowStyle.ToolWindow;
            aboutWindow.Owner = this; 
            aboutWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            aboutWindow.ShowDialog();
            
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Status.Text = "Открытие файла";
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
                path = openFileDialog.FileName;
                Status.Text = $"Открыт файл: {path}";
            }
            currentFileName = System.IO.Path.GetFileName(openFileDialog.FileName);
           
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Status.Text = "Сохранение файла";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.FileName = currentFileName;
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
                currentFileName = System.IO.Path.GetFileName(saveFileDialog.FileName);
                path= saveFileDialog.FileName;
                Status.Text = $"Файл сохранен: {path}";
            }
        }

        private void textBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(path!=null) 
            Status.Text = $"Открыт файл: {path}";
            else
                Status.Text = "Готов";
        }
    }
}
