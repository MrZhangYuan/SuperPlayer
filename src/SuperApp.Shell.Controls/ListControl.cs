using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        [TemplatePart(Name = "PART_ScrollViewer", Type = typeof(ScrollViewer))]
        public class ListControl : ListBox, IPageNavigation
        {
                public bool AutoSelectLast
                {
                        get { return (bool)GetValue(AutoSelectLastProperty); }
                        set { SetValue(AutoSelectLastProperty, value); }
                }
                public static readonly DependencyProperty AutoSelectLastProperty = DependencyProperty.Register("AutoSelectLast", typeof(bool), typeof(ListControl), new PropertyMetadata(false));

                static ListControl()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(ListControl), new FrameworkPropertyMetadata(typeof(ListControl)));
                }

                public event RoutedEventHandler ItemsChanged
                {
                        add
                        {
                                base.AddHandler(ListControl.ItemsChangedEvent, value);
                        }
                        remove
                        {
                                base.RemoveHandler(ListControl.ItemsChangedEvent, value);
                        }
                }
                public static readonly RoutedEvent ItemsChangedEvent = EventManager.RegisterRoutedEvent("ItemsChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ListControl));
                private void OnItemsChanged()
                {
                        RoutedEventArgs e = new RoutedEventArgs(ListControl.ItemsChangedEvent, this);
                        base.RaiseEvent(e);
                }

                public ScrollViewer InnerScrollViewer
                {
                        get; protected set;
                }

                protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
                {
                        base.OnItemsChanged(e);
                        this.OnItemsChanged();
                        if (this.AutoSelectLast)
                        {
                                this.SelectedIndex = this.Items.Count - 1;
                                this.PageDown();
                        }
                }

                public override void OnApplyTemplate()
                {
                        base.OnApplyTemplate();
                        this.InnerScrollViewer = GetTemplateChild("PART_ScrollViewer") as ScrollViewer;
                }

                protected override DependencyObject GetContainerForItemOverride()
                {
                        return new ListControlItem();
                }

                protected override bool IsItemItsOwnContainerOverride(object item)
                {
                        return item is ListControlItem;
                }

                private PaginationWrapPanel _itemsHostPanel;

                public PaginationWrapPanel ItemsHostPanel
                {
                        get => this._itemsHostPanel ?? (this._itemsHostPanel = this.GetItemsHost<PaginationWrapPanel>());
                }

                public void PageDown()
                {
                        if (this.InnerScrollViewer != null)
                        {
                                this.InnerScrollViewer.PageDown();
                        }
                }

                public void PageLeft()
                {
                        if (this.InnerScrollViewer != null)
                        {
                                this.InnerScrollViewer.PageLeft();
                        }
                }

                public void PageRight()
                {
                        if (this.InnerScrollViewer != null)
                        {
                                this.InnerScrollViewer.PageRight();
                        }
                }

                public void PageUp()
                {
                        if (this.InnerScrollViewer != null)
                        {
                                this.InnerScrollViewer.PageUp();
                        }
                }

                public bool CanPageUp()
                {
                        return this.ItemsHostPanel == null
                                        || this.ItemsHostPanel.PageIndex > 0;
                }

                public bool CanPageDown()
                {
                        return this.ItemsHostPanel == null
                                        || this.ItemsHostPanel.PageIndex < this.ItemsHostPanel.PageCount - 1;
                }

                public bool CanPageLeft()
                {
                        return this.ItemsHostPanel == null
                                        || this.ItemsHostPanel.PageIndex > 0;
                }

                public bool CanPageRight()
                {
                        return this.ItemsHostPanel == null
                                        || this.ItemsHostPanel.PageIndex < this.ItemsHostPanel.PageCount - 1;
                }
        }
}
