using System;
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
        public class NumberBox : Control
        {
                public bool IsReadonly
                {
                        get
                        {
                                return (bool)GetValue(IsReadonlyProperty);
                        }
                        set
                        {
                                SetValue(IsReadonlyProperty, value);
                        }
                }
                public static readonly DependencyProperty IsReadonlyProperty = DependencyProperty.Register("IsReadonly", typeof(bool), typeof(NumberBox), new PropertyMetadata(false));

                public double MinValue
                {
                        get
                        {
                                return (double)GetValue(MinValueProperty);
                        }
                        set
                        {
                                SetValue(MinValueProperty, value);
                        }
                }
                public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register("MinValue", typeof(double), typeof(NumberBox), new PropertyMetadata(0d, null, ChangedCoerceValueCallBack));

                public double Value
                {
                        get
                        {
                                return (double)GetValue(ValueProperty);
                        }
                        set
                        {
                                SetValue(ValueProperty, value);
                        }
                }
                public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(NumberBox), new PropertyMetadata(0d, ValueChangedCallBack, ChangedCoerceValueCallBack));

                private static void ValueChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
                {
                        NumberBox box = (NumberBox)d;
                        box.OnValueChanged();
                }

                public double MaxValue
                {
                        get
                        {
                                return (double)GetValue(MaxValueProperty);
                        }
                        set
                        {
                                SetValue(MaxValueProperty, value);
                        }
                }
                public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(double), typeof(NumberBox), new PropertyMetadata(double.MaxValue, null, ChangedCoerceValueCallBack));

                private static object ChangedCoerceValueCallBack(DependencyObject d, object baseValue)
                {
                        return baseValue;
                }

                public Visibility ControlButtonVisibility
                {
                        get
                        {
                                return (Visibility)GetValue(ControlButtonVisibilityProperty);
                        }
                        set
                        {
                                SetValue(ControlButtonVisibilityProperty, value);
                        }
                }
                public static readonly DependencyProperty ControlButtonVisibilityProperty = DependencyProperty.Register("ControlButtonVisibility", typeof(Visibility), typeof(NumberBox), new PropertyMetadata(Visibility.Visible));


                public event RoutedEventHandler ValueChanged
                {
                        add
                        {
                                base.AddHandler(NumberBox.ValueChangedEvent, value);
                        }
                        remove
                        {
                                base.RemoveHandler(NumberBox.ValueChangedEvent, value);
                        }
                }
                public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NumberBox));
                protected virtual void OnValueChanged()
                {
                        RoutedEventArgs e = new RoutedEventArgs(NumberBox.ValueChangedEvent, this);
                        base.RaiseEvent(e);
                }

                static NumberBox()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberBox), new FrameworkPropertyMetadata(typeof(NumberBox)));
                }

                RepeatButton minus = null,
                        add = null;

                TextBox valuebox = null;
                public override void OnApplyTemplate()
                {
                        base.OnApplyTemplate();

                        minus = this.GetTemplateChild("minus") as RepeatButton;
                        add = this.GetTemplateChild("add") as RepeatButton;
                        valuebox = this.GetTemplateChild("valuebox") as TextBox;

                        if (minus != null)
                        {
                                this.minus.Click += Minus_Click;
                        }
                        if (add != null)
                        {
                                this.add.Click += Add_Click;
                        }

                        this.valuebox.LostFocus += Valuebox_LostFocus;
                        this.valuebox.TextChanged += Valuebox_TextChanged;
                        this.valuebox.PreviewTextInput += Valuebox_PreviewTextInput;
                }

                private void Valuebox_PreviewTextInput(object sender, TextCompositionEventArgs e)
                {
                        string text = e.Text;
                        e.Handled = !(text == "0"
                                || text == "1"
                                || text == "2"
                                || text == "3"
                                || text == "4"
                                || text == "5"
                                || text == "6"
                                || text == "7"
                                || text == "8"
                                || text == "9"
                                || (text == "." && !this.valuebox.Text.Contains(".")));
                }

                private void Valuebox_TextChanged(object sender, TextChangedEventArgs e)
                {
                        if (string.IsNullOrEmpty(this.valuebox.Text)
                                || (this.valuebox.Text + "").EndsWith(".")
                                || ((this.valuebox.Text + "").Contains(".") && (this.valuebox.Text + "").EndsWith("0")))
                        {
                                return;
                        }

                        this.UpdateValue();
                }
                private void Valuebox_LostFocus(object sender, RoutedEventArgs e)
                {
                        this.UpdateValue();
                }
                private void UpdateValue()
                {
                        if (double.TryParse(this.valuebox.Text, out double value))
                        {
                                this.SetValue(value);
                        }

                        BindingExpression be = this.valuebox.GetBindingExpression(TextBox.TextProperty);
                        if (be != null)
                        {
                                be.UpdateTarget();
                        }
                        else
                        {
                                //不知为何valuebox的Binding偶尔会自动消失
                                this.valuebox.SetBinding(TextBox.TextProperty, new Binding
                                {
                                        Source = this,
                                        Path = new PropertyPath(NumberBox.ValueProperty),
                                        Mode = BindingMode.OneWay,
                                        StringFormat = "g0"
                                });
                        }
                }

                private void SetValue(double value)
                {
                        if (value >= MinValue && value <= MaxValue)
                        {
                                this.Value = value;
                        }

                        if (this.valuebox != null)
                        {
                                this.valuebox.CaretIndex = Math.Max(0, (this.valuebox.Text + "").Length);
                        }
                }

                private void Add_Click(object sender, RoutedEventArgs e)
                {
                        this.SetValue(this.Value + 1);
                }

                private void Minus_Click(object sender, RoutedEventArgs e)
                {
                        this.SetValue(this.Value - 1);
                }

                protected override void OnGotFocus(RoutedEventArgs e)
                {
                        base.OnGotFocus(e);
                        this.valuebox?.Focus();
                }

                public void SelectAll()
                {
                        this.valuebox?.Focus();
                        this.valuebox?.SelectAll();
                }


        }

}
