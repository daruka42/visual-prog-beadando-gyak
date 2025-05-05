using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace VisualProgBeadandoGyak.Utilities
{
    public static class WatermarkHelper
    {
        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached(
                "Watermark",
                typeof(string),
                typeof(WatermarkHelper),
                new FrameworkPropertyMetadata(string.Empty, OnWatermarkChanged));

        public static string GetWatermark(DependencyObject obj)
            => (string)obj.GetValue(WatermarkProperty);

        public static void SetWatermark(DependencyObject obj, string value)
            => obj.SetValue(WatermarkProperty, value);

        private static void OnWatermarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.GotFocus += RemoveWatermark;
                textBox.LostFocus += ShowWatermark;
                if (!textBox.IsFocused) ShowWatermark(textBox, null);
            }
        }

        private static void RemoveWatermark(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == GetWatermark(textBox))
            {
                textBox.Text = string.Empty;
                textBox.Foreground = SystemColors.ControlTextBrush;
            }
        }

        private static void ShowWatermark(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = GetWatermark(textBox);
                textBox.Foreground = Brushes.Gray;
            }
        }
    }
}
