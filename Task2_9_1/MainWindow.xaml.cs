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

namespace Task2_9_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public SolidColorBrush CurrentColor { get; set; }
        private Stack<Brush> _colorHistory = new Stack<Brush>();
        private Brush _currentColor;
        public Brush CurrentColor
        {
            get => _currentColor;
            set
            {
                _currentColor = value;
                if (_colorHistory.Count == 0 || _colorHistory.Peek() != value)
                {
                    _colorHistory.Push(value);
                }
                GridBgrd.Background = _currentColor;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            CurrentColor = new SolidColorBrush(Colors.White);
        }

        private void ChangedColor(object sender, ExecutedRoutedEventArgs e)
        {
            var random = new Random();

            CurrentColor = new SolidColorBrush(Color.FromRgb(
               (byte)random.Next(256),
               (byte)random.Next(256),
               (byte)random.Next(256)));
            GridBgrd.Background= CurrentColor;
        }

        private void UndoExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (_colorHistory.Count > 1)
            {
                _colorHistory.Pop();
                CurrentColor = _colorHistory.Pop();
               
            }
        }

        private void UndoCanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
           e.CanExecute = _colorHistory.Count > 1;
        }
    }
}
