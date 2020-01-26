using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperApp.Shell.Controls
{
    public class TextBoxHelper
    {
        public static double GetWaterMarkFontSize(DependencyObject obj)
        {
            return (double)obj.GetValue(WaterMarkFontSizeProperty);
        }
        public static void SetWaterMarkFontSize(DependencyObject obj, double value)
        {
            obj.SetValue(WaterMarkFontSizeProperty, value);
        }
        public static readonly DependencyProperty WaterMarkFontSizeProperty = DependencyProperty.RegisterAttached("WaterMarkFontSize", typeof(double), typeof(TextBoxHelper), new PropertyMetadata(12d));


        public static string GetWaterMark(DependencyObject obj)
        {
            return (string)obj.GetValue(WaterMarkProperty);
        }
        public static void SetWaterMark(DependencyObject obj, string value)
        {
            obj.SetValue(WaterMarkProperty, value);
        }
        public static readonly DependencyProperty WaterMarkProperty = DependencyProperty.RegisterAttached("WaterMark", typeof(string), typeof(TextBoxHelper), new PropertyMetadata(string.Empty));

    }
}
