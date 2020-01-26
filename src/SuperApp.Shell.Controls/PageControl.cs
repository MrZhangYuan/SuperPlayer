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
        public enum PageButtonVisibility
        {
                Auto,
                Hidden,
                Visible
        }

        public enum Location
        {
                Top,
                Bottom,
                TopBottom,
                Left,
                Right,
                LeftRight
        }

        public class PageControl : ContentControl
        {
                public Location Location
                {
                        get
                        {
                                return (Location)GetValue(LocationProperty);
                        }
                        set
                        {
                                SetValue(LocationProperty, value);
                        }
                }
                public static readonly DependencyProperty LocationProperty = DependencyProperty.Register("Location", typeof(Location), typeof(PageControl), new PropertyMetadata(Location.Bottom));

                public Orientation Orientation
                {
                        get
                        {
                                return (Orientation)GetValue(OrientationProperty);
                        }
                        set
                        {
                                SetValue(OrientationProperty, value);
                        }
                }
                public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(PageControl), new PropertyMetadata(Orientation.Vertical));


                public Style PageButtonStyle
                {
                        get
                        {
                                return (Style)GetValue(PageButtonStyleProperty);
                        }
                        set
                        {
                                SetValue(PageButtonStyleProperty, value);
                        }
                }
                public static readonly DependencyProperty PageButtonStyleProperty = DependencyProperty.Register("PageButtonStyle", typeof(Style), typeof(PageControl), new PropertyMetadata(null));


                public PageButtonVisibility PageButtonVisibility
                {
                        get
                        {
                                return (PageButtonVisibility)GetValue(PageButtonVisibilityProperty);
                        }
                        set
                        {
                                SetValue(PageButtonVisibilityProperty, value);
                        }
                }
                public static readonly DependencyProperty PageButtonVisibilityProperty = DependencyProperty.Register("PageButtonVisibility", typeof(PageButtonVisibility), typeof(PageControl), new PropertyMetadata(PageButtonVisibility.Auto));

                public ICommand LeftCommand
                {
                        get
                        {
                                return (ICommand)GetValue(LeftCommandProperty);
                        }
                        set
                        {
                                SetValue(LeftCommandProperty, value);
                        }
                }
                public static readonly DependencyProperty LeftCommandProperty = DependencyProperty.Register("LeftCommand", typeof(ICommand), typeof(PageControl), new PropertyMetadata(null));

                public ICommand RightCommand
                {
                        get
                        {
                                return (ICommand)GetValue(RightCommandProperty);
                        }
                        set
                        {
                                SetValue(RightCommandProperty, value);
                        }
                }
                public static readonly DependencyProperty RightCommandProperty = DependencyProperty.Register("RightCommand", typeof(ICommand), typeof(PageControl), new PropertyMetadata(null));


                public ICommand TopCommand
                {
                        get
                        {
                                return (ICommand)GetValue(TopCommandProperty);
                        }
                        set
                        {
                                SetValue(TopCommandProperty, value);
                        }
                }
                public static readonly DependencyProperty TopCommandProperty = DependencyProperty.Register("TopCommand", typeof(ICommand), typeof(PageControl), new PropertyMetadata(null));

                public ICommand BottomCommand
                {
                        get
                        {
                                return (ICommand)GetValue(BottomCommandProperty);
                        }
                        set
                        {
                                SetValue(BottomCommandProperty, value);
                        }
                }
                public static readonly DependencyProperty BottomCommandProperty = DependencyProperty.Register("BottomCommand", typeof(ICommand), typeof(PageControl), new PropertyMetadata(null));


                public object CommandParameter
                {
                        get
                        {
                                return (object)GetValue(CommandParameterProperty);
                        }
                        set
                        {
                                SetValue(CommandParameterProperty, value);
                        }
                }
                public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(PageControl), new PropertyMetadata(null));



                static PageControl()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(PageControl), new FrameworkPropertyMetadata(typeof(PageControl)));
                }
        }
}
