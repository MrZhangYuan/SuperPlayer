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

namespace SuperPlayer.Components
{
    /// <summary>
    /// SysCommandBar.xaml 的交互逻辑
    /// </summary>
    public partial class SysCommandBar : UserControl
    {
                public Visibility OptionBtVisibility
                {
                        get
                        {
                                return (Visibility)GetValue(OptionBtVisibilityProperty);
                        }
                        set
                        {
                                SetValue(OptionBtVisibilityProperty, value);
                        }
                }
                public static readonly DependencyProperty OptionBtVisibilityProperty = DependencyProperty.Register("OptionBtVisibility", typeof(Visibility), typeof(SysCommandBar), new PropertyMetadata(Visibility.Visible));


                public Visibility MinBtVisibility
                {
                        get
                        {
                                return (Visibility)GetValue(MinBtVisibilityProperty);
                        }
                        set
                        {
                                SetValue(MinBtVisibilityProperty, value);
                        }
                }
                public static readonly DependencyProperty MinBtVisibilityProperty = DependencyProperty.Register("MinBtVisibility", typeof(Visibility), typeof(SysCommandBar), new PropertyMetadata(Visibility.Visible));



                public Visibility NomalMaxBtVisibility
                {
                        get
                        {
                                return (Visibility)GetValue(NomalMaxBtVisibilityProperty);
                        }
                        set
                        {
                                SetValue(NomalMaxBtVisibilityProperty, value);
                        }
                }
                public static readonly DependencyProperty NomalMaxBtVisibilityProperty = DependencyProperty.Register("NomalMaxBtVisibility", typeof(Visibility), typeof(SysCommandBar), new PropertyMetadata(Visibility.Visible));


                public Visibility CloseBtVisibility
                {
                        get
                        {
                                return (Visibility)GetValue(CloseBtVisibilityProperty);
                        }
                        set
                        {
                                SetValue(CloseBtVisibilityProperty, value);
                        }
                }
                public static readonly DependencyProperty CloseBtVisibilityProperty = DependencyProperty.Register("CloseBtVisibility", typeof(Visibility), typeof(SysCommandBar), new PropertyMetadata(Visibility.Visible));

                public SysCommandBar()
        {
            InitializeComponent();
        }
    }
}
