using SuperPlayer.Core.Service;
using SuperPlayer.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using UltimateCore;

namespace SuperPlayer.Core
{
    /// <summary>
    /// PlayerControlHostWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PlayerControlHostWindow
    {
        private Lazy<IPlayerHost> _playerHost = new Lazy<IPlayerHost>(() => ServiceProvider.Instance.GetService<IPlayerHost>());
        public IPlayerHost PlayerHost
        {
            get
            {
                return _playerHost.Value;
            }
        }

        private Window _owner = null;
        private PlayerControlHostWindow()
        {
            InitializeComponent();

            //this.Background = new SolidColorBrush(new Color
            //{
            //    A = 1,
            //    R = 0,
            //    G = 0,
            //    B = 0
            //});
        }

        public static PlayerControlHostWindow Create(Window owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            PlayerControlHostWindow window = new PlayerControlHostWindow();
            window.Connect(owner);
            return window;
        }

        public void Connect(Window owner)
        {
            if (owner != null)
            {
                if (this._owner != null)
                {
                    this.DisConnect();
                }

                this._owner = owner;

                if (this._owner.IsLoaded)
                {
                    this._owner_Loaded(null, null);
                }
                else
                {
                    this._owner.Loaded += _owner_Loaded;
                }

                this._owner.IsVisibleChanged += _owner_IsVisibleChanged;
            }
            this.UpdateCore(IntPtr.Zero, 0);
        }

        private void _owner_Loaded(object sender, RoutedEventArgs e)
        {
            this._owner_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));

            this._ownerHwndSource = PresentationSource.FromVisual(this._owner) as HwndSource;
            this._ownerHwndSource.RemoveHook(WndProc);
            this._ownerHwndSource.AddHook(WndProc);
        }

        private HwndSource _ownerHwndSource = null;
        private IntPtr _handle = IntPtr.Zero;
        private IntPtr _ownerHandle = IntPtr.Zero;

        public IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            //Debug.WriteLine($"----------------------{msg}----------------------");

            switch ((WindowMessage)msg)
            {
                //case WindowMessage.WM_WINDOWPOSCHANGING:
                //case WindowMessage.WM_SETCURSOR:

                case WindowMessage.WM_EXITSIZEMOVE:
                case WindowMessage.WM_NCCALCSIZE:
                case WindowMessage.WM_GETMINMAXINFO:
                    this.UpdateCore(hwnd, msg);
                    handled = true;
                    break;
                default:
                    break;
            }
            return (System.IntPtr)0;
        }

        RECT _oldRect = default(RECT);
        public void UpdateCore(IntPtr hwnd, int msg)
        {
            if (this._handle == IntPtr.Zero)
            {
                this._handle = new WindowInteropHelper(this).Handle;
            }
            if (this._ownerHandle == IntPtr.Zero)
            {
                this._ownerHandle = new WindowInteropHelper(this._owner).Handle;
            }

            if (hwnd == IntPtr.Zero)
            {
                hwnd = this._ownerHandle;
            }

            NativeMethods.GetWindowRect(hwnd, out RECT rect);
            bool ismax = NativeMethods.IsZoomed(hwnd);
            if (ismax)
            {
                rect = new RECT(0, 0, (int)SystemParameters.WorkArea.Width, (int)SystemParameters.WorkArea.Height);
            }

            if (_oldRect.Left != rect.Left
                    || _oldRect.Top != rect.Top
                    || _oldRect.Bottom != rect.Bottom
                    || _oldRect.Right != rect.Right)
            {
                _oldRect = rect;

                //Debug.WriteLine($"----------------------{msg}----------------------");

                NativeMethods.SetWindowPos
                (
                    this._handle,
                    IntPtr.Zero,
                    rect.Left,
                    rect.Top,
                    rect.Width,
                    rect.Height,
                    SWP.SHOWWINDOW
                );
            }
        }


        private void _owner_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this._owner.IsVisible)
            {
                this.Owner = this._owner;
                this.Show();
            }
            else
            {
                this.Hide();
            }
        }

        public void DisConnect()
        {
            this._handle = IntPtr.Zero;
            this._ownerHandle = IntPtr.Zero;

            this.Owner = null;

            if (this._owner != null)
            {
                this._owner.Loaded -= _owner_Loaded;
                this._owner.IsVisibleChanged -= _owner_IsVisibleChanged;
                this._owner = null;
            }

            if (this._ownerHwndSource != null)
            {
                this._ownerHwndSource.RemoveHook(WndProc);
                this._ownerHwndSource = null;
            }
        }

        public void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this._owner.Activate();

            if (e.ClickCount == 2)
            {
                if (this.PlayerHost != null)
                {
                    bool isfull = WindowHelper.CheckIsFullScreen(this._owner);

                    if (isfull)
                    {
                        SystemCommandManager.Instance[SystemCommand.FullScreenCancel].Execute(null, null);
                    }
                    else
                    {
                        SystemCommandManager.Instance[SystemCommand.FullScreen].Execute(null, null);
                    }
                }
                else
                {
                    switch (this._owner.WindowState)
                    {
                        case WindowState.Normal:
                            SystemCommandManager.Instance[SystemCommand.Maximized].Execute(null, null);
                            break;

                        case WindowState.Maximized:
                            SystemCommandManager.Instance[SystemCommand.Normal].Execute(null, null);
                            break;
                    }
                }
            }
            else if (!this._owner.CheckIsFullScreen())
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(new WindowInteropHelper(this._owner).Handle, 0x0112, 0xF012, 0);
            }
        }
    }
}
