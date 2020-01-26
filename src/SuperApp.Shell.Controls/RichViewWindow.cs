using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UltimatePresentation.Presentation;

namespace SuperApp.Shell.Controls
{
        [ContentProperty("RichViewItems")]
        [TemplatePart(Name = PART_RichViewControlContainer, Type = typeof(ContentPresenter))]
        public class RichViewWindow : CustomChromeWindow, IDialogContainer, IFlyoutContainer
        {
                private const string PART_RichViewControlContainer = "PART_RichViewControlContainer";

                private readonly RichViewControl _RichViewControl;
                public RichViewControl RichViewControl
                {
                        get
                        {
                                return this._RichViewControl;
                        }
                }

                public object TitleContent
                {
                        get
                        {
                                return (object)GetValue(TitleContentProperty);
                        }
                        set
                        {
                                SetValue(TitleContentProperty, value);
                        }
                }
                public static readonly DependencyProperty TitleContentProperty = DependencyProperty.Register("TitleContent", typeof(object), typeof(RichViewWindow), new PropertyMetadata(null));

                public IEnumerable RichViewItemsSource
                {
                        get
                        {
                                return (IEnumerable)GetValue(RichViewItemsSourceProperty);
                        }
                        set
                        {
                                SetValue(RichViewItemsSourceProperty, value);
                        }
                }
                public static readonly DependencyProperty RichViewItemsSourceProperty = DependencyProperty.Register("RichViewItemsSource", typeof(IEnumerable), typeof(RichViewWindow), new PropertyMetadata(null));


                public ObservableCollection<BubbleMsg> BubbleMsgs
                {
                        get
                        {
                                return (ObservableCollection<BubbleMsg>)GetValue(BubbleMsgsProperty);
                        }
                        private set
                        {
                                SetValue(BubbleMsgsProperty, value);
                        }
                }
                public static readonly DependencyProperty BubbleMsgsProperty = DependencyProperty.Register("BubbleMsgs", typeof(ObservableCollection<BubbleMsg>), typeof(RichViewWindow), new PropertyMetadata(null));

                public Dialog TopDialog => this._RichViewControl.TopDialog;

                public Flyout TopFlyout => this._RichViewControl.TopFlyout;

                static RichViewWindow()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(RichViewWindow), new FrameworkPropertyMetadata(typeof(RichViewWindow)));
                }
                public RichViewWindow()
                {
                        this._RichViewControl = new RichViewControl();
                        this._RichViewControl.SetBinding(RichViewControl.ItemsSourceProperty, new Binding
                        {
                                Mode = BindingMode.OneWay,
                                Source = this,
                                Path = new PropertyPath("RichViewItemsSource")
                        });
                        this.BubbleMsgs = new ObservableCollection<BubbleMsg>();
                }
                protected override void OnSourceInitialized(EventArgs e)
                {
                        base.OnSourceInitialized(e);
                        this.UpdateClipRegion();
                }
                public override void OnApplyTemplate()
                {
                        base.OnApplyTemplate();

                        ContentPresenter container = GetTemplateChild(PART_RichViewControlContainer) as ContentPresenter;
                        if (container == null)
                        {
                                throw new Exception("模板缺少元素 RichViewControl。");
                        }
                        container.Content = this._RichViewControl;
                }

                [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
                [Bindable(true)]
                public ItemCollection RichViewItems
                {
                        get
                        {
                                return this._RichViewControl?.Items;
                        }
                }

                public void ShowDialog(Dialog dialog) => this._RichViewControl.ShowDialog(dialog);

                public void CloseTopDialog() => this._RichViewControl.CloseTopDialog();

                public void ShowFlyout(Flyout flyout) => this._RichViewControl.ShowFlyout(flyout);

                public void CloseFlyout() => this._RichViewControl.CloseFlyout();

                public void ShowView(object content)
                {
                        UIElement element = this._RichViewControl.ItemContainerGenerator.ContainerFromItem(content) as UIElement;
                        if (element == null)
                        {
                                this.RichViewItems.Add(content);
                        }
                        else
                        {
                                element.Visibility = Visibility.Visible;
                                foreach (var item in this.RichViewItems)
                                {
                                        UIElement container = this._RichViewControl.ItemContainerGenerator.ContainerFromItem(item) as UIElement;
                                        if (element != container)
                                        {
                                                container.Visibility = Visibility.Collapsed;
                                        }
                                }
                        }
                }

                public void CloseView(object content)
                {
                        if (this.RichViewItems.Contains(content))
                        {
                                this.RichViewItems.Remove(content);
                        }
                        else
                        {
                                UIElement element = this._RichViewControl.ItemContainerGenerator.ContainerFromItem(content) as UIElement;
                                if (element != null)
                                {
                                        this.RichViewItems.Remove(element);
                                }
                        }
                }

                public void Bubble(string message)
                {
                        this.Bubble(message, 5);
                }

                public async void Bubble(string message, int seconds)
                {
                        if (!string.IsNullOrEmpty(message))
                        {
                                BubbleMsg msg = new BubbleMsg(message);
                                try
                                {
                                        this.Dispatcher.BeginInvoke(new Action(() =>
                                        {
                                                this.BubbleMsgs.Add(msg);
                                        }));
                                        await TaskEx.Delay(seconds * 1000);
                                }
                                finally
                                {
                                        this.Dispatcher.BeginInvoke(new Action(() =>
                                        {
                                                this.BubbleMsgs.Remove(msg);
                                        }));
                                }
                        }
                }

                public void CloseDialog(object content)
                {
                        this._RichViewControl.CloseDialog(content);
                }

                public void CloseFlyout(object content)
                {
                        this._RichViewControl.CloseFlyout(content);
                }
        }

        public class BubbleMsg
        {
                public string Text
                {
                        get;
                }

                public BubbleMsg(string text)
                {
                        Text = text;
                }

                public override string ToString()
                {
                        return this.Text;
                }
        }
}
