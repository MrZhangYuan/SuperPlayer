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
using UltimatePresentation.Presentation;

namespace SuperApp.Shell.Controls
{
        public class ListControlItem : ListBoxItem, INonClientArea
        {

                public bool IsMouseDown
                {
                        get
                        {
                                return (bool)GetValue(IsMouseDownProperty);
                        }
                        private set
                        {
                                SetValue(IsMouseDownProperty, value);
                        }
                }
                public static readonly DependencyProperty IsMouseDownProperty = DependencyProperty.Register("IsMouseDown", typeof(bool), typeof(ListControlItem), new PropertyMetadata(false));

                static ListControlItem()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(ListControlItem), new FrameworkPropertyMetadata(typeof(ListControlItem)));
                }

                public int HitTest(Point point)
                {
                        return 1;
                }

                protected override void OnMouseDown(MouseButtonEventArgs e)
                {
                        base.OnMouseDown(e);
                        this.CaptureMouse();
                        this.IsMouseDown = true;
                }

                protected override void OnMouseUp(MouseButtonEventArgs e)
                {
                        base.OnMouseUp(e);

                        //if (this.IsMouseCaptured)
                        //{
                        this.IsMouseDown = false;
                        //}
                }
        }
}
