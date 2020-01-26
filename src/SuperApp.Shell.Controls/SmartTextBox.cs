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
        class FontSizeGapMutiConverter : IMultiValueConverter
        {
                private static FontSizeGapMutiConverter _instance;
                public static FontSizeGapMutiConverter Instence
                {
                        get
                        {
                                if (_instance == null)
                                {
                                        _instance = new FontSizeGapMutiConverter();
                                }
                                return _instance;
                        }
                }

                private FontSizeGapMutiConverter()
                {

                }

                #region IMultiValueConverter 成员

                public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                        if (values != null && values.Length == 2)
                        {
                                if (values[0] is double && values[1] is int)
                                {
                                        double fontsize = (double)values[0];
                                        int gap = (int)values[1];
                                        return fontsize - gap;
                                }
                        }
                        return 13d;
                }

                public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
                {
                        throw new NotImplementedException();
                }

                #endregion
        }

        public class SmartTextBox : TextBox, INonClientArea
        {
                Button _commandButton = null;

                #region Propertys
                /// <summary>
                /// 左边子面板可见性
                /// </summary>
                public Visibility LeftPageVisibility
                {
                        get
                        {
                                return (Visibility)GetValue(LeftPageVisibilityProperty);
                        }
                        set
                        {
                                SetValue(LeftPageVisibilityProperty, value);
                        }
                }
                /// <summary>
                /// 左边子面板可见性
                /// </summary>
                public static readonly DependencyProperty LeftPageVisibilityProperty = DependencyProperty.Register(
                        "LeftPageVisibility",
                        typeof(Visibility),
                        typeof(SmartTextBox),
                        new PropertyMetadata(Visibility.Visible));

                /// <summary>
                /// 右边子面板可见性
                /// </summary>
                public Visibility RightPageVisibility
                {
                        get
                        {
                                return (Visibility)GetValue(RightPageVisibilityProperty);
                        }
                        set
                        {
                                SetValue(RightPageVisibilityProperty, value);
                        }
                }
                /// <summary>
                /// 右边子面板可见性
                /// </summary>
                public static readonly DependencyProperty RightPageVisibilityProperty = DependencyProperty.Register(
                        "RightPageVisibility",
                        typeof(Visibility),
                        typeof(SmartTextBox),
                        new PropertyMetadata(Visibility.Visible));

                /// <summary>
                /// 左部分内容
                /// </summary>
                public object LeftContent
                {
                        get
                        {
                                return (object)GetValue(LeftContentProperty);
                        }
                        set
                        {
                                SetValue(LeftContentProperty, value);
                        }
                }
                /// <summary>
                /// 左部分内容
                /// </summary>
                public static readonly DependencyProperty LeftContentProperty = DependencyProperty.Register(
                        "LeftContent",
                        typeof(object),
                        typeof(SmartTextBox),
                        new PropertyMetadata(null));

                /// <summary>
                /// 右部分内容
                /// </summary>
                public object RightContent
                {
                        get
                        {
                                return (object)GetValue(RightContentProperty);
                        }
                        set
                        {
                                SetValue(RightContentProperty, value);
                        }
                }
                /// <summary>
                /// 右部分内容
                /// </summary>
                public static readonly DependencyProperty RightContentProperty = DependencyProperty.Register(
                        "RightContent",
                        typeof(object),
                        typeof(SmartTextBox),
                        new PropertyMetadata(null));

                /// <summary>
                /// 命令按钮样式
                /// </summary>
                public Style CommandButtonStyle
                {
                        get
                        {
                                return (Style)GetValue(CommandButtonStyleProperty);
                        }
                        set
                        {
                                SetValue(CommandButtonStyleProperty, value);
                        }
                }
                /// <summary>
                /// 命令按钮样式
                /// </summary>
                public static readonly DependencyProperty CommandButtonStyleProperty = DependencyProperty.Register(
                        "CommandButtonStyle",
                        typeof(Style),
                        typeof(SmartTextBox),
                        new PropertyMetadata(null));

                /// <summary>
                /// 水印文本
                /// </summary>
                public string WaterMarkText
                {
                        get
                        {
                                return (string)GetValue(WaterMarkTextProperty);
                        }
                        set
                        {
                                SetValue(WaterMarkTextProperty, value);
                        }
                }
                /// <summary>
                /// 水印文本
                /// </summary>
                public static readonly DependencyProperty WaterMarkTextProperty = DependencyProperty.Register("WaterMarkText", typeof(string), typeof(SmartTextBox), new PropertyMetadata(string.Empty));

                /// <summary>
                /// Text和WaterMarkText的字体大小差距
                /// Text-WaterMarkText=FontSizeGap
                /// </summary>
                public int FontSizeGap
                {
                        get
                        {
                                return (int)GetValue(FontSizeGapProperty);
                        }
                        set
                        {
                                SetValue(FontSizeGapProperty, value);
                        }
                }
                /// <summary>
                /// Text和WaterMarkText的字体大小差距
                /// </summary>
                public static readonly DependencyProperty FontSizeGapProperty = DependencyProperty.Register("FontSizeGap", typeof(int), typeof(SmartTextBox), new PropertyMetadata(0));

                /// <summary>
                /// 边框圆角大小
                /// </summary>
                public CornerRadius CornerRadius
                {
                        get
                        {
                                return (CornerRadius)GetValue(CornerRadiusProperty);
                        }
                        set
                        {
                                SetValue(CornerRadiusProperty, value);
                        }
                }
                /// <summary>
                /// 边框圆角大小
                /// </summary>
                public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(SmartTextBox), new PropertyMetadata(new CornerRadius(0)));

                /// <summary>
                /// 右面的Button命令
                /// </summary>
                public ICommand RightButtonCommand
                {
                        get
                        {
                                return (ICommand)GetValue(RightButtonCommandProperty);
                        }
                        set
                        {
                                SetValue(RightButtonCommandProperty, value);
                        }
                }
                /// <summary>
                /// 右面的Button命令
                /// </summary>
                public static readonly DependencyProperty RightButtonCommandProperty = DependencyProperty.Register("RightButtonCommand", typeof(ICommand), typeof(SmartTextBox), new PropertyMetadata(null));

                #endregion

                /// <summary>
                /// 命令按钮单击事件
                /// </summary>
                public event RoutedEventHandler CommandButtonClick
                {
                        add
                        {
                                base.AddHandler(SmartTextBox.CommandButtonClickEvent, value);
                        }
                        remove
                        {
                                base.RemoveHandler(SmartTextBox.CommandButtonClickEvent, value);
                        }
                }
                /// <summary>
                /// 命令按钮单击事件
                /// </summary>
                public static readonly RoutedEvent CommandButtonClickEvent = EventManager.RegisterRoutedEvent(
                        "CommandButtonClick",
                        RoutingStrategy.Bubble,
                        typeof(RoutedEventHandler),
                        typeof(SmartTextBox));

                protected virtual void OnCommandButtonClick()
                {
                        RoutedEventArgs e = new RoutedEventArgs(SmartTextBox.CommandButtonClickEvent, this);
                        base.RaiseEvent(e);
                }

                static SmartTextBox()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(SmartTextBox), new FrameworkPropertyMetadata(typeof(SmartTextBox)));
                }
                public override void OnApplyTemplate()
                {
                        base.OnApplyTemplate();
                        _commandButton = this.GetTemplateChild("PART_CommandButton") as Button;
                        if (_commandButton != null)
                        {
                                _commandButton.Click += (sender, e) =>
                                {
                                        this.OnCommandButtonClick();
                                        e.Handled = true;
                                };
                        }
                }

                public int HitTest(Point point)
                {
                        return 1;
                }
        }

}
