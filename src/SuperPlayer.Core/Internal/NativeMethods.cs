using System;
using System.Runtime.InteropServices;

namespace SuperPlayer.Core
{
    static class NativeMethods
    {
        // ---函数功能：该函数从当前线程中的窗口释放鼠标捕获，并恢复通常的鼠标输入处理。
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // ---发送消息
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);



        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_NOACTIVATE = 0x8000000;

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr window, int index, int value);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr window, int index);

        /// <summary>
        /// 设置窗口为无焦点
        /// </summary>
        /// <param name="hwnd"></param>
        public static void SetWindowNoFocus(IntPtr hwnd)
        {
            SetWindowLong(hwnd, GWL_EXSTYLE, GetWindowLong(hwnd, GWL_EXSTYLE) | WS_EX_NOACTIVATE);
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SWP flags);



        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsZoomed(IntPtr hWnd);
    }
}
