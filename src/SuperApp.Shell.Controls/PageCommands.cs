using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SuperApp.Shell.Controls
{
        public static class PageCommands
        {
                public static RoutedCommand PageUpCommand { get; } = new RoutedCommand("PageUp", typeof(PageCommands));
                public static RoutedCommand PageDownCommand { get; } = new RoutedCommand("PageDown", typeof(PageCommands));
                public static RoutedCommand PageLeftCommand { get; } = new RoutedCommand("PageLeft", typeof(PageCommands));
                public static RoutedCommand PageRightCommand { get; } = new RoutedCommand("PageRight", typeof(PageCommands));

                static PageCommands()
                {
                        CommandManager.RegisterClassCommandBinding
                        (
                                typeof(UIElement),
                                new CommandBinding
                                (
                                        (ICommand)PageCommands.PageUpCommand,
                                       PageCommands.PageUpExecute,
                                       PageCommands.PageUpCanExecute
                                )
                        );

                        CommandManager.RegisterClassCommandBinding
                        (
                                typeof(UIElement),
                                new CommandBinding
                                (
                                        (ICommand)PageCommands.PageDownCommand,
                                        PageCommands.PageDownExecute,
                                        PageCommands.PageDownCanExecute
                                )
                        );

                        CommandManager.RegisterClassCommandBinding
                        (
                                typeof(UIElement),
                                new CommandBinding
                                (
                                        (ICommand)PageCommands.PageLeftCommand,
                                       PageCommands.PageLeftExecute,
                                       PageCommands.PageLeftCanExecute
                                )
                        );

                        CommandManager.RegisterClassCommandBinding
                        (
                                typeof(UIElement),
                                new CommandBinding
                                (
                                        (ICommand)PageCommands.PageRightCommand,
                                        PageCommands.PageRightExecute,
                                        PageCommands.PageRightCanExecute
                                )
                        );
                }

                private static void PageRightCanExecute(object sender, CanExecuteRoutedEventArgs e)
                {
                        e.Handled = true;
                        IPageNavigation navigation = e.Parameter as IPageNavigation;
                        if (navigation != null)
                        {
                                e.CanExecute = navigation.CanPageRight();
                        }
                }

                private static void PageRightExecute(object sender, ExecutedRoutedEventArgs e)
                {
                        IPageNavigation navigation = e.Parameter as IPageNavigation;
                        if (navigation != null)
                        {
                                navigation.PageRight();
                        }
                }

                private static void PageLeftCanExecute(object sender, CanExecuteRoutedEventArgs e)
                {
                        e.Handled = true;
                        IPageNavigation navigation = e.Parameter as IPageNavigation;
                        if (navigation != null)
                        {
                                e.CanExecute = navigation.CanPageLeft();
                        }
                }

                private static void PageLeftExecute(object sender, ExecutedRoutedEventArgs e)
                {
                        IPageNavigation navigation = e.Parameter as IPageNavigation;
                        if (navigation != null)
                        {
                                navigation.PageLeft();
                        }
                }

                private static void PageUpCanExecute(object sender, CanExecuteRoutedEventArgs e)
                {
                        e.Handled = true;
                        IPageNavigation navigation = e.Parameter as IPageNavigation;
                        if (navigation != null)
                        {
                                e.CanExecute = navigation.CanPageUp();
                        }
                }

                private static void PageDownCanExecute(object sender, CanExecuteRoutedEventArgs e)
                {
                        e.Handled = true;
                        IPageNavigation navigation = e.Parameter as IPageNavigation;
                        if (navigation != null)
                        {
                                e.CanExecute = navigation.CanPageDown();
                        }
                }

                private static void PageDownExecute(object sender, ExecutedRoutedEventArgs args)
                {
                        IPageNavigation navigation = args.Parameter as IPageNavigation;
                        if (navigation != null)
                        {
                                navigation.PageDown();
                        }
                }

                private static void PageUpExecute(object sender, ExecutedRoutedEventArgs args)
                {
                        IPageNavigation navigation = args.Parameter as IPageNavigation;
                        if (navigation != null)
                        {
                                navigation.PageUp();
                        }
                }
        }
}
