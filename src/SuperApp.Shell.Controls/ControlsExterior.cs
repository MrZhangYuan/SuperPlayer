using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace SuperApp.Shell.Controls
{
        public static class ControlsExterior
        {
                //控件的水印
                public static object GetWaterMark(DependencyObject obj)
                {
                        return (object)obj.GetValue(WaterMarkProperty);
                }
                public static void SetWaterMark(DependencyObject obj, object value)
                {
                        obj.SetValue(WaterMarkProperty, value);
                }
                public static readonly DependencyProperty WaterMarkProperty = DependencyProperty.RegisterAttached("WaterMark", typeof(object), typeof(ControlsExterior), new PropertyMetadata(null));


                //控件的圆角
                public static CornerRadius GetCornerRadius(DependencyObject obj)
                {
                        return (CornerRadius)obj.GetValue(CornerRadiusProperty);
                }
                public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
                {
                        obj.SetValue(CornerRadiusProperty, value);
                }
                public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ControlsExterior), new PropertyMetadata(new CornerRadius(0)));


                //一些带有选中属性的控件
                public static Brush GetSelectedBackground(DependencyObject obj)
                {
                        return (Brush)obj.GetValue(SelectedBackgroundProperty);
                }
                public static void SetSelectedBackground(DependencyObject obj, Brush value)
                {
                        obj.SetValue(SelectedBackgroundProperty, value);
                }
                public static readonly DependencyProperty SelectedBackgroundProperty = DependencyProperty.RegisterAttached("SelectedBackground", typeof(Brush), typeof(ControlsExterior), new PropertyMetadata(null));

                public static Thickness GetSelectedBorderThickness(DependencyObject obj)
                {
                        return (Thickness)obj.GetValue(SelectedBorderThicknessProperty);
                }
                public static void SetSelectedBorderThickness(DependencyObject obj, Thickness value)
                {
                        obj.SetValue(SelectedBorderThicknessProperty, value);
                }
                public static readonly DependencyProperty SelectedBorderThicknessProperty = DependencyProperty.RegisterAttached("SelectedBorderThickness", typeof(Thickness), typeof(ControlsExterior), new PropertyMetadata(new Thickness(0)));

                public static Brush GetSelectedBorderBrush(DependencyObject obj)
                {
                        return (Brush)obj.GetValue(SelectedBorderBrushProperty);
                }
                public static void SetSelectedBorderBrush(DependencyObject obj, Brush value)
                {
                        obj.SetValue(SelectedBorderBrushProperty, value);
                }
                public static readonly DependencyProperty SelectedBorderBrushProperty = DependencyProperty.RegisterAttached("SelectedBorderBrush", typeof(Brush), typeof(ControlsExterior), new PropertyMetadata(null));

                public static Brush GetSelectedForeground(DependencyObject obj)
                {
                        return (Brush)obj.GetValue(SelectedForegroundProperty);
                }
                public static void SetSelectedForeground(DependencyObject obj, Brush value)
                {
                        obj.SetValue(SelectedForegroundProperty, value);
                }
                public static readonly DependencyProperty SelectedForegroundProperty = DependencyProperty.RegisterAttached("SelectedForeground", typeof(Brush), typeof(ControlsExterior), new PropertyMetadata(null));


                //带有鼠标状态的控件

                public static Brush GetPressedBackground(DependencyObject obj)
                {
                        return (Brush)obj.GetValue(PressedBackgroundProperty);
                }
                public static void SetPressedBackground(DependencyObject obj, Brush value)
                {
                        obj.SetValue(PressedBackgroundProperty, value);
                }
                public static readonly DependencyProperty PressedBackgroundProperty = DependencyProperty.RegisterAttached("PressedBackground", typeof(Brush), typeof(ControlsExterior), new PropertyMetadata(null));

                public static Brush GetPressedForeground(DependencyObject obj)
                {
                        return (Brush)obj.GetValue(PressedForegroundProperty);
                }
                public static void SetPressedForeground(DependencyObject obj, Brush value)
                {
                        obj.SetValue(PressedForegroundProperty, value);
                }
                public static readonly DependencyProperty PressedForegroundProperty = DependencyProperty.RegisterAttached("PressedForeground", typeof(Brush), typeof(ControlsExterior), new PropertyMetadata(null));

                public static Brush GetPressedBorderBrush(DependencyObject obj)
                {
                        return (Brush)obj.GetValue(PressedBorderBrushProperty);
                }
                public static void SetPressedBorderBrush(DependencyObject obj, Brush value)
                {
                        obj.SetValue(PressedBorderBrushProperty, value);
                }
                public static readonly DependencyProperty PressedBorderBrushProperty = DependencyProperty.RegisterAttached("PressedBorderBrush", typeof(Brush), typeof(ControlsExterior), new PropertyMetadata(null));

                public static Thickness GetPressedBorderThickness(DependencyObject obj)
                {
                        return (Thickness)obj.GetValue(PressedBorderThicknessProperty);
                }
                public static void SetPressedBorderThickness(DependencyObject obj, Thickness value)
                {
                        obj.SetValue(PressedBorderThicknessProperty, value);
                }
                public static readonly DependencyProperty PressedBorderThicknessProperty = DependencyProperty.RegisterAttached("PressedBorderThickness", typeof(Thickness), typeof(ControlsExterior), new PropertyMetadata(new Thickness(0)));



                public static Brush GetHoverBackground(DependencyObject obj)
                {
                        return (Brush)obj.GetValue(HoverBackgroundProperty);
                }
                public static void SetHoverBackground(DependencyObject obj, Brush value)
                {
                        obj.SetValue(HoverBackgroundProperty, value);
                }
                public static readonly DependencyProperty HoverBackgroundProperty = DependencyProperty.RegisterAttached("HoverBackground", typeof(Brush), typeof(ControlsExterior), new PropertyMetadata(null));


                public static Brush GetHoverForeground(DependencyObject obj)
                {
                        return (Brush)obj.GetValue(HoverForegroundProperty);
                }
                public static void SetHoverForeground(DependencyObject obj, Brush value)
                {
                        obj.SetValue(HoverForegroundProperty, value);
                }
                public static readonly DependencyProperty HoverForegroundProperty = DependencyProperty.RegisterAttached("HoverForeground", typeof(Brush), typeof(ControlsExterior), new PropertyMetadata(null));

                public static Brush GetHoverBorderBrush(DependencyObject obj)
                {
                        return (Brush)obj.GetValue(HoverBorderBrushProperty);
                }
                public static void SetHoverBorderBrush(DependencyObject obj, Brush value)
                {
                        obj.SetValue(HoverBorderBrushProperty, value);
                }
                public static readonly DependencyProperty HoverBorderBrushProperty = DependencyProperty.RegisterAttached("HoverBorderBrush", typeof(Brush), typeof(ControlsExterior), new PropertyMetadata(null));

                public static Thickness GetHoverBorderThickness(DependencyObject obj)
                {
                        return (Thickness)obj.GetValue(HoverBorderThicknessProperty);
                }
                public static void SetHoverBorderThickness(DependencyObject obj, Thickness value)
                {
                        obj.SetValue(HoverBorderThicknessProperty, value);
                }
                public static readonly DependencyProperty HoverBorderThicknessProperty = DependencyProperty.RegisterAttached("HoverBorderThickness", typeof(Thickness), typeof(ControlsExterior), new PropertyMetadata(new Thickness(0)));

        }

}
