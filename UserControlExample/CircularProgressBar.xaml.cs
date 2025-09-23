using System;
using System.Windows;
using System.Windows.Controls;

namespace UserControlExample
{
    /// <summary>
    /// Логика взаимодействия для CircularProgressBar.xaml
    /// </summary> 
    public partial class CircularProgressBar : UserControl
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(0.0, OnValueChanged));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(
                nameof(Maximum),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(100.0, OnValueChanged));

        // Read-only Dependency Properties

        private static readonly DependencyPropertyKey ArcEndPointPropertyKey =
           DependencyProperty.RegisterReadOnly(nameof(ArcEndPoint), typeof(Point), typeof(CircularProgressBar), new PropertyMetadata(new Point(50, 5)));

        public static readonly DependencyProperty ArcEndPointProperty = ArcEndPointPropertyKey.DependencyProperty;

        private static readonly DependencyPropertyKey IsLargeArcPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(IsLargeArc), typeof(bool), typeof(CircularProgressBar), new PropertyMetadata(false));

        public static readonly DependencyProperty IsLargeArcProperty = IsLargeArcPropertyKey.DependencyProperty;

        private static readonly DependencyPropertyKey ProgressAnglePropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(ProgressAngle),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(0.0));

        public static readonly DependencyProperty ProgressAngleProperty = ProgressAnglePropertyKey.DependencyProperty;

        private static readonly DependencyPropertyKey PercentageTextPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(PercentageText),
                typeof(string),
                typeof(CircularProgressBar),
                new PropertyMetadata("0%"));

        public static readonly DependencyProperty PercentageTextProperty = PercentageTextPropertyKey.DependencyProperty;

        public Point ArcEndPoint
        {
            get => (Point)GetValue(ArcEndPointProperty);
            private set => SetValue(ArcEndPointPropertyKey, value);
        }

        public bool IsLargeArc
        {
            get => (bool)GetValue(IsLargeArcProperty);
            private set => SetValue(IsLargeArcPropertyKey, value);
        }
        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public double ProgressAngle
        {
            get => (double)GetValue(ProgressAngleProperty);
            private set => SetValue(ProgressAnglePropertyKey, value);
        }

        public string PercentageText
        {
            get => (string)GetValue(PercentageTextProperty);
            private set => SetValue(PercentageTextPropertyKey, value);
        }

        public CircularProgressBar()
        {
            InitializeComponent();
            UpdateProgress();
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var progressBar = (CircularProgressBar)d;
            progressBar.UpdateProgress();
        }

        private void UpdateProgress()
        {
            // Ограничиваем значения
            if (Value < 0) Value = 0;
            if (Value > Maximum) Value = Maximum;
            if (Maximum <= 0) Maximum = 100;

            // Вычисляем прогресс
            double percentage = Maximum == 0 ? 0 : (Value / Maximum);
 
            PercentageText = $"{(percentage * 100):F0}%";

            ProgressAngle = 360 * percentage;

            if (ProgressAngle >= 360)
            {
                ProgressAngle = 359;
            }
            IsLargeArc = ProgressAngle > 180;
            double angleRad = (Math.PI / 180) * (ProgressAngle - 90);
            double x = 50 + 45 * Math.Cos(angleRad);
            double y = 50 + 45 * Math.Sin(angleRad);
            ArcEndPoint = new Point(x, y);
        }
    }
}