using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public class SwitchViewControlItem : ListBoxItem
        {
                public event RoutedEventHandler ViewSwitched
                {
                        add
                        {
                                base.AddHandler(SwitchViewControlItem.ViewSwitchedEvent, value);
                        }
                        remove
                        {
                                base.RemoveHandler(SwitchViewControlItem.ViewSwitchedEvent, value);
                        }
                }
                public static readonly RoutedEvent ViewSwitchedEvent = EventManager.RegisterRoutedEvent("ViewSwitched", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SwitchViewControlItem));
                protected internal virtual void OnViewSwitched()
                {
                        RoutedEventArgs e = new RoutedEventArgs(SwitchViewControlItem.ViewSwitchedEvent, this);
                        base.RaiseEvent(e);
                }

                static SwitchViewControlItem()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitchViewControlItem), new FrameworkPropertyMetadata(typeof(SwitchViewControlItem)));
                }
        }
}
