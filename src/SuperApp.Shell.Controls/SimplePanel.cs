using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SuperApp.Shell.Controls
{
        internal class SimplePanel : Panel
        {
                private IEnumerable<UIElement> NonCollapsedChildren
                {
                        get
                        {
                                return this.InternalChildren.Cast<UIElement>().Where<UIElement>((Func<UIElement, bool>)(e =>
                                {
                                        if (e != null)
                                                return e.Visibility != Visibility.Collapsed;
                                        return false;
                                }));
                        }
                }

                private IEnumerable<UIElement> VisibleChildren
                {
                        get
                        {
                                return this.InternalChildren.Cast<UIElement>().Where<UIElement>((Func<UIElement, bool>)(e =>
                                {
                                        if (e != null)
                                                return e.Visibility == Visibility.Visible;
                                        return false;
                                }));
                        }
                }


                protected override Size MeasureOverride(Size availableSize)
                {
                        if (double.IsInfinity(availableSize.Width)
                               || double.IsInfinity(availableSize.Height))
                        {
                                throw new Exception("确保该Panel未包含在ScrollViewer中，或者禁用ScrollViewer的滚动特性。");
                        }
                        foreach (UIElement element in this.VisibleChildren)
                        {
                                element.Measure(availableSize);
                        }
                        return availableSize;
                }

                protected override Size ArrangeOverride(Size finalSize)
                {
                        Rect rect = new Rect(new Point(0, 0), finalSize);
                        foreach (UIElement element in this.VisibleChildren)
                        {
                                element.Arrange(rect);
                        }
                        return finalSize;
                }
        }

}
