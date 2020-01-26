using SuperPlayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace System.Windows
{
    public static class WindowHelper
    {
        private static FullScreenInfo GetFullScreenInfo(DependencyObject obj)
        {
            return (FullScreenInfo)obj.GetValue(FullScreenInfoProperty);
        }
        private static void SetFullScreenInfo(DependencyObject obj, FullScreenInfo value)
        {
            obj.SetValue(FullScreenInfoProperty, value);
        }
        private static readonly DependencyProperty FullScreenInfoProperty = DependencyProperty.RegisterAttached("FullScreenInfo", typeof(FullScreenInfo), typeof(WindowHelper), new PropertyMetadata(null, FullScreenInfoPropertyChangedCallback));

        private static void FullScreenInfoPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        private class FullScreenInfo
        {
            public bool IsFullScreen { get; set; }
            public double Height { get; set; }
            public double Width { get; set; }
            public double Top { get; set; }
            public double Left { get; set; }
            public WindowState WindowState { get; set; }
            public WindowStyle WindowStyle { get; set; }
            public ResizeMode ResizeMode { get; set; }

            //public bool CheckIsFullScreen(Window window)
            //{
            //        return window.WindowState == WindowState.Normal
            //                && window.WindowStyle == WindowStyle.None
            //                && window.ResizeMode == ResizeMode.NoResize
            //                && window.Top == 0
            //                && window.Left == 0
            //                && window.Height == SystemParameters.PrimaryScreenHeight
            //                && window.Width == SystemParameters.PrimaryScreenWidth;
            //}
        }

        private static void FullScreenWindowCore(Window window)
        {
            //window.WindowStyle = WindowStyle.None;

            NativeMethods.SetWindowPos
            (
                new WindowInteropHelper(window).Handle,
                IntPtr.Zero,
                0,
                0,
                (int)SystemParameters.PrimaryScreenWidth,
                (int)SystemParameters.PrimaryScreenHeight,
                SWP.SHOWWINDOW
            );

            //window.WindowState = WindowState.Normal;
            //window.WindowStyle = WindowStyle.None;
            //window.ResizeMode = ResizeMode.NoResize;
        }
        public static void FullScreen(this Window window)
        {
            if (window != null)
            {
                FullScreenInfo fullScreenInfo = WindowHelper.GetFullScreenInfo(window);
                if (fullScreenInfo == null)
                {
                    fullScreenInfo = new FullScreenInfo
                    {
                        IsFullScreen = true,
                        Height = window.RestoreBounds.Height,
                        Width = window.RestoreBounds.Width,
                        Top = window.Top,
                        Left = window.Left,
                        ResizeMode = window.ResizeMode,
                        WindowState = window.WindowState,
                        WindowStyle = window.WindowStyle
                    };
                    WindowHelper.SetFullScreenInfo(window, fullScreenInfo);
                    FullScreenWindowCore(window);
                }
                else if (!fullScreenInfo.IsFullScreen)
                {
                    fullScreenInfo.IsFullScreen = true;
                    fullScreenInfo.ResizeMode = window.ResizeMode;
                    fullScreenInfo.WindowState = window.WindowState;
                    fullScreenInfo.WindowStyle = window.WindowStyle;
                    fullScreenInfo.Height = window.Height;
                    fullScreenInfo.Width = window.Width;
                    fullScreenInfo.Top = window.Top;
                    fullScreenInfo.Left = window.Left;
                    FullScreenWindowCore(window);
                }
            }
        }

        public static void FullScreenCancel(this Window window)
        {
            if (window != null)
            {
                FullScreenInfo fullScreenInfo = WindowHelper.GetFullScreenInfo(window);
                if (fullScreenInfo != null
                        && fullScreenInfo.IsFullScreen)
                {
                    fullScreenInfo.IsFullScreen = false;

                    //window.WindowStyle = fullScreenInfo.WindowStyle;

                    //window.WindowStyle = fullScreenInfo.WindowStyle;
                    //window.ResizeMode = fullScreenInfo.ResizeMode;
                    //window.WindowState = fullScreenInfo.WindowState;
                    NativeMethods.SetWindowPos
                    (
                        new WindowInteropHelper(window).Handle,
                        IntPtr.Zero,
                         (int)fullScreenInfo.Left,
                         (int)fullScreenInfo.Top,
                        (int)fullScreenInfo.Width,
                        (int)fullScreenInfo.Height,
                        SWP.SHOWWINDOW
                    );
                }
            }
        }

        public static bool CheckIsFullScreen(this Window window)
        {
            if (window != null)
            {
                FullScreenInfo fullScreenInfo = WindowHelper.GetFullScreenInfo(window);
                if (fullScreenInfo != null
                        && fullScreenInfo.IsFullScreen)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
