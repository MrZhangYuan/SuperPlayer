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
        public class KeyChar : Control
        {
                public bool IsChecked
                {
                        get
                        {
                                return (bool)GetValue(IsCheckedProperty);
                        }
                        set
                        {
                                SetValue(IsCheckedProperty, value);
                        }
                }
                public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(KeyChar), new PropertyMetadata(false, IsCheckedChangedCallBack));

                private static void IsCheckedChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
                {

                }

                static KeyChar()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(KeyChar), new FrameworkPropertyMetadata(typeof(KeyChar)));
                }
        }

        public class PasswordControl : Control
        {
                public string Password
                {
                        get
                        {
                                return (string)GetValue(PasswordProperty);
                        }
                        set
                        {
                                SetValue(PasswordProperty, value);
                        }
                }
                public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(PasswordControl), new PropertyMetadata(string.Empty, PasswordChanged));

                private static void PasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
                {
                        ((PasswordControl)d).RefreshChar();
                }

                public int Length
                {
                        get
                        {
                                return (int)GetValue(LengthProperty);
                        }
                        set
                        {
                                SetValue(LengthProperty, value);
                        }
                }

                public static readonly DependencyProperty LengthProperty = DependencyProperty.Register("Length", typeof(int), typeof(PasswordControl), new PropertyMetadata(6, LengthChanged));

                private static void LengthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
                {
                        ((PasswordControl)d).RefreshChar();
                }

                public event RoutedEventHandler EnterComplated
                {
                        add
                        {
                                base.AddHandler(PasswordControl.EnterComplatedEvent, value);
                        }
                        remove
                        {
                                base.RemoveHandler(PasswordControl.EnterComplatedEvent, value);
                        }
                }
                public static readonly RoutedEvent EnterComplatedEvent = EventManager.RegisterRoutedEvent("EnterComplated", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PasswordControl));
                protected virtual void OnEnterComplated()
                {
                        RoutedEventArgs e = new RoutedEventArgs(PasswordControl.EnterComplatedEvent, this);
                        base.RaiseEvent(e);
                }

                static PasswordControl()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(PasswordControl), new FrameworkPropertyMetadata(typeof(PasswordControl)));
                }
                public PasswordControl()
                {
                        this.Loaded += PasswordControl_Loaded;
                }

                protected override void OnKeyDown(KeyEventArgs e)
                {
                        base.OnKeyDown(e);

                        return;

                        if ((this.Password + "").Length < this.Length)
                        {
                                switch (e.Key)
                                {
                                        case Key.D0:
                                        case Key.NumPad0:
                                                this.Password += "0";
                                                break;
                                        case Key.D1:
                                        case Key.NumPad1:
                                                this.Password += "1";
                                                break;
                                        case Key.D2:
                                        case Key.NumPad2:
                                                this.Password += "2";
                                                break;
                                        case Key.D3:
                                        case Key.NumPad3:
                                                this.Password += "3";
                                                break;
                                        case Key.D4:
                                        case Key.NumPad4:
                                                this.Password += "4";
                                                break;
                                        case Key.D5:
                                        case Key.NumPad5:
                                                this.Password += "5";
                                                break;
                                        case Key.D6:
                                        case Key.NumPad6:
                                                this.Password += "6";
                                                break;
                                        case Key.D7:
                                        case Key.NumPad7:
                                                this.Password += "7";
                                                break;
                                        case Key.D8:
                                        case Key.NumPad8:
                                                this.Password += "8";
                                                break;
                                        case Key.D9:
                                        case Key.NumPad9:
                                                this.Password += "9";
                                                break;

                                        case Key.Back:
                                                if (!string.IsNullOrEmpty(this.Password))
                                                {
                                                        this.Password = this.Password.Substring(0, this.Password.Length - 1);
                                                }
                                                break;

                                        case Key.Enter:
                                                this.OnEnterComplated();
                                                break;
                                }
                        }
                }

                private void PasswordControl_Loaded(object sender, RoutedEventArgs e)
                {
                        this.RefreshChar();
                }

                private void RefreshChar()
                {
                        if (this.Length < 1)
                        {
                                this.Length = 1;
                                return;
                        }

                        if (!string.IsNullOrEmpty(this.Password)
                                && this.Password.Length > this.Length)
                        {
                                this.Password = this.Password.Substring(0, this.Length);
                                return;
                        }

                        if (this._CharHost != null)
                        {
                                int charlength = this._CharHost.Children.Count;

                                int range = charlength - this.Length;

                                if (range > 0)
                                {
                                        this._CharHost.Children.RemoveRange(0, range);
                                }
                                else if (range < 0)
                                {
                                        for (int i = range; i < 0; i++)
                                        {
                                                this._CharHost.Children.Add(new KeyChar());
                                        }
                                }

                                int current = string.IsNullOrEmpty(this.Password) ? 0 : this.Password.Length;

                                for (int i = 0; i < this._CharHost.Children.Count; i++)
                                {
                                        KeyChar item = this._CharHost.Children[i] as KeyChar;

                                        item.IsChecked = i < current;

                                        //if (i == current)
                                        //{
                                        //        item.Flicking();
                                        //}
                                }
                        }

                        if (!string.IsNullOrEmpty(this.Password))
                        {
                                if (this.Password.Length >= this.Length)
                                {
                                        //this.Dispatcher.BeginInvoke(new Action(() =>
                                        //{
                                        //        this.OnEnterComplated();
                                        //}),
                                        //DispatcherPriority.Background);

                                        this.OnEnterComplated();
                                }
                        }
                }

                Grid _TemplateRoot = null;
                StackPanel _CharHost = null;
                public override void OnApplyTemplate()
                {
                        base.OnApplyTemplate();
                        _TemplateRoot = GetTemplateChild("PART_ROOT") as Grid;
                        _CharHost = GetTemplateChild("PART_CHARHOST") as StackPanel;

                        if (_TemplateRoot != null)
                        {
                                _TemplateRoot.AddHandler(Button.ClickEvent, new RoutedEventHandler(this.KeyClick), true);
                        }

                        this.RefreshChar();
                }

                public void ShowError()
                {
                        if (this._CharHost != null)
                        {
                                this._CharHost.Shaking();
                        }
                }

                private void KeyClick(object sender, RoutedEventArgs e)
                {
                        Control key = e.OriginalSource as Control;
                        if (key != null)
                        {
                                switch (key.Tag + "")
                                {
                                        case "←":
                                                if (!string.IsNullOrEmpty(this.Password))
                                                {
                                                        this.Password = this.Password.Substring(0, this.Password.Length - 1);
                                                }
                                                break;

                                        case "C":
                                                this.Password = string.Empty;
                                                break;

                                        default:
                                                if (!string.IsNullOrEmpty(this.Password))
                                                {
                                                        if (this.Password.Length >= this.Length)
                                                        {
                                                                return;
                                                        }
                                                }
                                                this.Password += key.Tag;
                                                break;
                                }
                        }
                }
        }
}
