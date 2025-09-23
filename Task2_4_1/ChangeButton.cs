using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Task2_4_1
{
    class ChangeButton : Button
    {
        public static readonly DependencyProperty ChangeColorProperty =
            DependencyProperty.Register(
                nameof(ChangeColorProperty),
                typeof(bool),
                typeof(ChangeButton),
                new FrameworkPropertyMetadata(false,
                    FrameworkPropertyMetadataOptions.None,
                    IsToggled));
        public bool ChangeColor
        {
            get { return (bool)GetValue(ChangeColorProperty); }
            set { SetValue(ChangeColorProperty, value); }
        }

        private static void IsToggled(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = (ChangeButton)d;
            bool value = (bool)e.NewValue;
            if (value == true)
            {
                button.Background = new SolidColorBrush(Colors.Green);
                button.Content = "ON";
            }
            else
            {
                button.Background = new SolidColorBrush(Colors.Red);
                button.Content = "OFF";
            }


        }

        public ChangeButton()
        {
            Background= new SolidColorBrush(Colors.Red);
            Content = "OFF";
            Click+= (sender,e) => ChangeColor = !ChangeColor;
        }

    }
}
