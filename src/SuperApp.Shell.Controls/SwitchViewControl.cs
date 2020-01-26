using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperApp.Shell.Controls
{
        /// <summary>
        /// 快速切换的View，通过控制Visibility = Visibility.Hidden，利用布局缓存提高性能
        /// 和TabControl的区别是设置Visibility = Visibility.Hidden
        /// 搭配SimplePanel进行延迟化布局
        /// </summary>
        public sealed class SwitchViewControl : ListControl
        {
                private static bool GetIsMeasureOrArrangeProcessed(DependencyObject obj)
                {
                        return (bool)obj.GetValue(IsMeasureOrArrangeProcessedProperty);
                }
                private static void SetIsMeasureOrArrangeProcessed(DependencyObject obj, bool value)
                {
                        obj.SetValue(IsMeasureOrArrangeProcessedProperty, value);
                }
                private static readonly DependencyProperty IsMeasureOrArrangeProcessedProperty = DependencyProperty.RegisterAttached("IsMeasureOrArrangeProcessed", typeof(bool), typeof(SwitchViewControl), new PropertyMetadata(false, null));


                static SwitchViewControl()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitchViewControl), new FrameworkPropertyMetadata(typeof(SwitchViewControl)));
                }

                public SwitchViewControl()
                {
                        this.SizeChanged += SwitchViewControl_SizeChanged;
                }

                private void SwitchViewControl_SizeChanged(object sender, SizeChangedEventArgs e)
                {
                        if (this.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                        {
                                foreach (var item in this.Items)
                                {
                                        if (!object.ReferenceEquals(item, this.SelectedItem))
                                        {
                                                var container = this.ItemContainerGenerator.ContainerFromItem(item) as UIElement;
                                                if (container != null)
                                                {
                                                        container.SetValue(SwitchViewControl.IsMeasureOrArrangeProcessedProperty, false);
                                                }
                                        }
                                }
                        }
                }

                protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
                {
                        base.PrepareContainerForItemOverride(element, item);

                        UIElement uielement = (UIElement)element;

                        if (object.ReferenceEquals(this.SelectedItem, item))
                        {
                                uielement.Visibility = Visibility.Visible;
                                uielement.SetValue(SwitchViewControl.IsMeasureOrArrangeProcessedProperty, true);

                                if (element is SwitchViewControlItem)
                                {
                                        ((SwitchViewControlItem)element).OnViewSwitched();
                                }
                        }
                        else
                        {
                                uielement.Visibility = Visibility.Hidden;
                        }
                }

                protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
                {
                        base.OnItemsChanged(e);

                        this.RefreshViewVisible();
                }

                protected override void OnSelectionChanged(SelectionChangedEventArgs e)
                {
                        base.OnSelectionChanged(e);

                        this.RefreshViewVisible();
                }

                public void RefreshViewVisible()
                {
                        if (this.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                        {
                                if (this.SelectedItem == null)
                                {
                                        foreach (var item in this.Items)
                                        {
                                                var container = this.ItemContainerGenerator.ContainerFromItem(item) as UIElement;
                                                if (container != null)
                                                {
                                                        container.Visibility = Visibility.Hidden;
                                                }
                                        }
                                }

                                var current = this.ItemContainerGenerator.ContainerFromItem(this.SelectedItem) as UIElement;

                                bool iscurrentmeasured = false;

                                foreach (var item in this.Items)
                                {
                                        var container = this.ItemContainerGenerator.ContainerFromItem(item) as UIElement;

                                        if (object.ReferenceEquals(current, container)
                                                && current != null)
                                        {
                                                current.Visibility = Visibility.Visible;

                                                iscurrentmeasured = (bool)current.GetValue(SwitchViewControl.IsMeasureOrArrangeProcessedProperty);

                                                if (current is SwitchViewControlItem)
                                                {
                                                        ((SwitchViewControlItem)current).OnViewSwitched();
                                                }
                                        }
                                        else
                                        {
                                                container.Visibility = Visibility.Hidden;
                                        }
                                }

                                //若当前显示项没经过布局或者布局过期，重新布局
                                if (!iscurrentmeasured
                                        && this._itemsHost != null)
                                {
                                        this._itemsHost.InvalidateMeasure();
                                        current?.SetValue(SwitchViewControl.IsMeasureOrArrangeProcessedProperty, true);
                                }
                        }
                }

                SimplePanel _itemsHost = null;
                public override void OnApplyTemplate()
                {
                        base.OnApplyTemplate();
                        this._itemsHost = this.GetTemplateChild("Part_Host") as SimplePanel;
                }

                protected override DependencyObject GetContainerForItemOverride()
                {
                        return new SwitchViewControlItem();
                }

                protected override bool IsItemItsOwnContainerOverride(object item)
                {
                        return item is SwitchViewControlItem;
                }
        }
}
