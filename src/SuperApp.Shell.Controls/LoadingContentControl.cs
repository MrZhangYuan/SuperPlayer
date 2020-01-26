using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperApp.Shell.Controls
{
        public class LoadingContentControl : ContentControl
        {
                public bool IsLoading
                {
                        get
                        {
                                return (bool)base.GetValue(LoadingContentControl.IsLoadingProperty);
                        }
                        set
                        {
                                base.SetValue(LoadingContentControl.IsLoadingProperty, value);
                        }
                }
                public static bool GetIsLoading(DependencyObject obj)
                {
                        return (bool)obj.GetValue(IsLoadingProperty);
                }
                public static void SetIsLoading(DependencyObject obj, bool value)
                {
                        obj.SetValue(IsLoadingProperty, value);
                }
                public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.RegisterAttached("IsLoading", typeof(bool), typeof(LoadingContentControl), new PropertyMetadata(false));


                public Brush LoadingBackground
                {
                        get
                        {
                                return (Brush)base.GetValue(LoadingContentControl.LoadingBackgroundProperty);
                        }
                        set
                        {
                                base.SetValue(LoadingContentControl.LoadingBackgroundProperty, value);
                        }
                }
                public static Brush GetLoadingBackground(DependencyObject obj)
                {
                        return (Brush)obj.GetValue(LoadingBackgroundProperty);
                }
                public static void SetLoadingBackground(DependencyObject obj, Brush value)
                {
                        obj.SetValue(LoadingBackgroundProperty, value);
                }
                public static readonly DependencyProperty LoadingBackgroundProperty = DependencyProperty.RegisterAttached("LoadingBackground", typeof(Brush), typeof(LoadingContentControl), new PropertyMetadata(null));




                public Brush LoadingForeground
                {
                        get
                        {
                                return (Brush)base.GetValue(LoadingContentControl.LoadingForegroundProperty);
                        }
                        set
                        {
                                base.SetValue(LoadingContentControl.LoadingForegroundProperty, value);
                        }
                }
                public static Brush GetLoadingForeground(DependencyObject obj)
                {
                        return (Brush)obj.GetValue(LoadingForegroundProperty);
                }
                public static void SetLoadingForeground(DependencyObject obj, Brush value)
                {
                        obj.SetValue(LoadingForegroundProperty, value);
                }
                public static readonly DependencyProperty LoadingForegroundProperty = DependencyProperty.RegisterAttached("LoadingForeground", typeof(Brush), typeof(LoadingContentControl), new PropertyMetadata(null));



                public double AnimationHeight
                {
                        get
                        {
                                return (double)base.GetValue(LoadingContentControl.AnimationHeightProperty);
                        }
                        set
                        {
                                base.SetValue(LoadingContentControl.AnimationHeightProperty, value);
                        }
                }
                public static double GetAnimationHeight(DependencyObject obj)
                {
                        return (double)obj.GetValue(AnimationHeightProperty);
                }
                public static void SetAnimationHeight(DependencyObject obj, double value)
                {
                        obj.SetValue(AnimationHeightProperty, value);
                }
                public static readonly DependencyProperty AnimationHeightProperty = DependencyProperty.RegisterAttached("AnimationHeight", typeof(double), typeof(LoadingContentControl), new PropertyMetadata(0d));


                public double AnimationWidth
                {
                        get
                        {
                                return (double)base.GetValue(LoadingContentControl.AnimationWidthProperty);
                        }
                        set
                        {
                                base.SetValue(LoadingContentControl.AnimationWidthProperty, value);
                        }
                }
                public static double GetAnimationWidth(DependencyObject obj)
                {
                        return (double)obj.GetValue(AnimationWidthProperty);
                }
                public static void SetAnimationWidth(DependencyObject obj, double value)
                {
                        obj.SetValue(AnimationWidthProperty, value);
                }
                public static readonly DependencyProperty AnimationWidthProperty = DependencyProperty.RegisterAttached("AnimationWidth", typeof(double), typeof(LoadingContentControl), new PropertyMetadata(0d));

                static LoadingContentControl()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(LoadingContentControl), new FrameworkPropertyMetadata(typeof(LoadingContentControl)));
                }
        }

}
