using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        [TemplatePart(Name = "PART_ScrollViewer", Type = typeof(ScrollViewer))]
        public class SearchListControl : ListControl
        {
                public object SearchCondition1
                {
                        get
                        {
                                return (object)GetValue(SearchCondition1Property);
                        }
                        set
                        {
                                SetValue(SearchCondition1Property, value);
                        }
                }
                public static readonly DependencyProperty SearchCondition1Property = DependencyProperty.Register("SearchCondition1", typeof(object), typeof(SearchListControl), new PropertyMetadata(null, ExecuteFilterFunction));


                public object SearchCondition2
                {
                        get
                        {
                                return (object)GetValue(SearchCondition2Property);
                        }
                        set
                        {
                                SetValue(SearchCondition2Property, value);
                        }
                }
                public static readonly DependencyProperty SearchCondition2Property = DependencyProperty.Register("SearchCondition2", typeof(object), typeof(SearchListControl), new PropertyMetadata(null, ExecuteFilterFunction));


                public object SearchCondition3
                {
                        get
                        {
                                return (object)GetValue(SearchCondition3Property);
                        }
                        set
                        {
                                SetValue(SearchCondition3Property, value);
                        }
                }
                public static readonly DependencyProperty SearchCondition3Property = DependencyProperty.Register("SearchCondition3", typeof(object), typeof(SearchListControl), new PropertyMetadata(null, ExecuteFilterFunction));


                public object SearchCondition4
                {
                        get
                        {
                                return (object)GetValue(SearchCondition4Property);
                        }
                        set
                        {
                                SetValue(SearchCondition4Property, value);
                        }
                }
                public static readonly DependencyProperty SearchCondition4Property = DependencyProperty.Register("SearchCondition4", typeof(object), typeof(SearchListControl), new PropertyMetadata(null, ExecuteFilterFunction));


                public object SearchCondition5
                {
                        get
                        {
                                return (object)GetValue(SearchCondition5Property);
                        }
                        set
                        {
                                SetValue(SearchCondition5Property, value);
                        }
                }
                public static readonly DependencyProperty SearchCondition5Property = DependencyProperty.Register("SearchCondition5", typeof(object), typeof(SearchListControl), new PropertyMetadata(null, ExecuteFilterFunction));


                public object SearchCondition6
                {
                        get
                        {
                                return (object)GetValue(SearchCondition6Property);
                        }
                        set
                        {
                                SetValue(SearchCondition6Property, value);
                        }
                }
                public static readonly DependencyProperty SearchCondition6Property = DependencyProperty.Register("SearchCondition6", typeof(object), typeof(SearchListControl), new PropertyMetadata(null, ExecuteFilterFunction));


                public object SearchCondition7
                {
                        get
                        {
                                return (object)GetValue(SearchCondition7Property);
                        }
                        set
                        {
                                SetValue(SearchCondition7Property, value);
                        }
                }
                public static readonly DependencyProperty SearchCondition7Property = DependencyProperty.Register("SearchCondition7", typeof(object), typeof(SearchListControl), new PropertyMetadata(null, ExecuteFilterFunction));


                public object SearchCondition8
                {
                        get
                        {
                                return (object)GetValue(SearchCondition8Property);
                        }
                        set
                        {
                                SetValue(SearchCondition8Property, value);
                        }
                }
                public static readonly DependencyProperty SearchCondition8Property = DependencyProperty.Register("SearchCondition8", typeof(object), typeof(SearchListControl), new PropertyMetadata(null, ExecuteFilterFunction));


                public object SearchCondition9
                {
                        get
                        {
                                return (object)GetValue(SearchCondition9Property);
                        }
                        set
                        {
                                SetValue(SearchCondition9Property, value);
                        }
                }
                public static readonly DependencyProperty SearchCondition9Property = DependencyProperty.Register("SearchCondition9", typeof(object), typeof(SearchListControl), new PropertyMetadata(null, ExecuteFilterFunction));


                public Func<object, object, object, object, object, object, object, object, object, object, bool> FilterFunction
                {
                        get
                        {
                                return (Func<object, object, object, object, object, object, object, object, object, object, bool>)GetValue(FilterFunctionProperty);
                        }
                        set
                        {
                                SetValue(FilterFunctionProperty, value);
                        }
                }
                public static readonly DependencyProperty FilterFunctionProperty = DependencyProperty.Register("FilterFunction", typeof(Func<object, object, object, object, object, object, object, object, object, object, bool>), typeof(SearchListControl), new PropertyMetadata(null, ExecuteFilterFunction));

                static SearchListControl()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchListControl), new FrameworkPropertyMetadata(typeof(SearchListControl)));
                }
                public SearchListControl()
                {
                        this.ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
                }

                void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
                {
                        this.ExecuteFilterFunction();
                }
                protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
                {
                        base.OnItemsSourceChanged(oldValue, newValue);
                        this.ExecuteFilterFunction();
                }
                protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                        base.OnItemsChanged(e);
                        this.ExecuteFilterFunction();
                }

                protected override DependencyObject GetContainerForItemOverride()
                {
                        return new SearchListControlItem();
                }

                protected override bool IsItemItsOwnContainerOverride(object item)
                {
                        return item is SearchListControlItem;
                }

                private static void ExecuteFilterFunction(DependencyObject d, DependencyPropertyChangedEventArgs e)
                {
                        ((SearchListControl)d).ExecuteFilterFunction();
                }

                private void ExecuteFilterFunction()
                {
                        if (this.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                        {
                                for (int i = 0; i < this.Items.Count; i++)
                                {
                                        ListControlItem itemm = this.ItemContainerGenerator.ContainerFromIndex(i) as ListControlItem;

                                        if (this.FilterFunction != null
                                                && !this.FilterFunction(this.Items[i], this.SearchCondition1, this.SearchCondition2, this.SearchCondition3, this.SearchCondition4, this.SearchCondition5, this.SearchCondition6, this.SearchCondition7, this.SearchCondition8, this.SearchCondition9))
                                        {
                                                if (itemm != null)
                                                {
                                                        itemm.Visibility = Visibility.Collapsed;
                                                        //itemm.IsEnabled = false;
                                                }
                                        }
                                        else
                                        {
                                                if (itemm != null)
                                                {
                                                        itemm.Visibility = Visibility.Visible;
                                                        //itemm.IsEnabled = true;
                                                }
                                        }
                                }
                        }
                }
        }
}
