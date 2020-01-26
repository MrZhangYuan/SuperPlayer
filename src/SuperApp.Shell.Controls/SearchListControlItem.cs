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
        public class SearchListControlItem : ListControlItem
        {
                static SearchListControlItem()
                {
                        DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchListControlItem), new FrameworkPropertyMetadata(typeof(SearchListControlItem)));
                }
        }
}
