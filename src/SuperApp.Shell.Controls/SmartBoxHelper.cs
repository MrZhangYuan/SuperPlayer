using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SuperApp.Shell.Controls
{
        public static class SmartBoxHelper
        {
                public static object GetLeftContent(DependencyObject obj)
                {
                        return (object)obj.GetValue(LeftContentProperty);
                }
                public static void SetLeftContent(DependencyObject obj, object value)
                {
                        obj.SetValue(LeftContentProperty, value);
                }
                public static readonly DependencyProperty LeftContentProperty = DependencyProperty.RegisterAttached("LeftContent", typeof(object), typeof(SmartBoxHelper), new PropertyMetadata(null));


                public static Visibility GetLeftPageVisibility(DependencyObject obj)
                {
                        return (Visibility)obj.GetValue(LeftPageVisibilityProperty);
                }
                public static void SetLeftPageVisibility(DependencyObject obj, Visibility value)
                {
                        obj.SetValue(LeftPageVisibilityProperty, value);
                }
                public static readonly DependencyProperty LeftPageVisibilityProperty = DependencyProperty.RegisterAttached("LeftPageVisibility", typeof(Visibility), typeof(SmartBoxHelper), new PropertyMetadata(Visibility.Visible));




                public static object GetRightContent(DependencyObject obj)
                {
                        return (object)obj.GetValue(RightContentProperty);
                }
                public static void SetRightContent(DependencyObject obj, object value)
                {
                        obj.SetValue(RightContentProperty, value);
                }
                public static readonly DependencyProperty RightContentProperty = DependencyProperty.RegisterAttached("RightContent", typeof(object), typeof(SmartBoxHelper), new PropertyMetadata(null));


                public static Visibility GetRightPageVisibility(DependencyObject obj)
                {
                        return (Visibility)obj.GetValue(RightPageVisibilityProperty);
                }
                public static void SetRightPageVisibility(DependencyObject obj, Visibility value)
                {
                        obj.SetValue(RightPageVisibilityProperty, value);
                }
                public static readonly DependencyProperty RightPageVisibilityProperty = DependencyProperty.RegisterAttached("RightPageVisibility", typeof(Visibility), typeof(SmartBoxHelper), new PropertyMetadata(Visibility.Visible));



                public static int GetFontSizeGap(DependencyObject obj)
                {
                        return (int)obj.GetValue(FontSizeGapProperty);
                }
                public static void SetFontSizeGap(DependencyObject obj, int value)
                {
                        obj.SetValue(FontSizeGapProperty, value);
                }
                public static readonly DependencyProperty FontSizeGapProperty = DependencyProperty.RegisterAttached("FontSizeGap", typeof(int), typeof(SmartBoxHelper), new PropertyMetadata(0));


                public static string GetText(DependencyObject obj)
                {
                        return (string)obj.GetValue(TextProperty);
                }
                public static void SetText(DependencyObject obj, string value)
                {
                        obj.SetValue(TextProperty, value);
                }
                public static readonly DependencyProperty TextProperty = DependencyProperty.RegisterAttached("Text", typeof(string), typeof(SmartBoxHelper), new PropertyMetadata(string.Empty));

        }
}
