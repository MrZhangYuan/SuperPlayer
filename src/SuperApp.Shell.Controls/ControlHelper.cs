using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SuperApp.Shell.Controls
{
        public static class ControlHelper
        {
                private static readonly ControlEffects controlEffects = new ControlEffects();


                private static Storyboard _shakingStoryboard = null;
                public static Storyboard ShakingStoryboard
                {
                        get
                        {
                                if (_shakingStoryboard == null)
                                {
                                        _shakingStoryboard = controlEffects["ControlShakingStoryboard"] as Storyboard;
                                }

                                return _shakingStoryboard;
                        }
                }

                public static void Shaking(this FrameworkElement control)
                {
                        if (control != null
                                && ShakingStoryboard != null)
                        {
                                if (control is PasswordControl)
                                {
                                        ((PasswordControl)control).ShowError();
                                }
                                else
                                {
                                        Transform tran = control.RenderTransform;
                                        //TransformGroup group = tran as TransformGroup;

                                        if (tran != null
                                                && !(tran is TranslateTransform)
                                                && tran != Transform.Identity)
                                        {
                                                throw new Exception("该控件的RenderTransform非TranslateTransform类型。");
                                        }

                                        if (tran == null
                                                || tran == Transform.Identity)
                                        {
                                                tran = new TranslateTransform();
                                                control.RenderTransform = tran;
                                        }

                                        control.BeginStoryboard(ShakingStoryboard);
                                }
                        }
                }






                /// <summary>
                /// 根据指定的类型找到父元素
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="element"></param>
                /// <returns></returns>
                public static T GetParentByType<T>(this FrameworkElement element) where T : FrameworkElement
                {
                        FrameworkElement parent =
                                element.Parent as FrameworkElement
                                ?? LogicalTreeHelper.GetParent(element) as FrameworkElement
                                ?? VisualTreeHelper.GetParent(element) as FrameworkElement;

                        while (parent != null)
                        {
                                if (parent is Window || parent is T)
                                {
                                        break;
                                }

                                parent = parent.Parent as FrameworkElement
                                ?? LogicalTreeHelper.GetParent(parent) as FrameworkElement
                                ?? VisualTreeHelper.GetParent(parent) as FrameworkElement;
                        }
                        return parent as T;
                }

                static readonly PropertyInfo ItemsHostProperty = typeof(ItemsControl).GetProperty("ItemsHost", BindingFlags.Instance | BindingFlags.NonPublic);
                public static T GetItemsHost<T>(this ItemsControl itemsControl) where T : Panel
                {
                        if (itemsControl == null)
                        {
                                return null;
                        }

                        return ItemsHostProperty.GetValue(itemsControl, null) as T;
                }
        }

}
