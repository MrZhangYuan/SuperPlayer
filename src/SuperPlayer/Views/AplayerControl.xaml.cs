using AxAPlayer3Lib;
using SuperPlayer.Core;
using SuperPlayer.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperPlayer.Views
{
        /// <summary>
        /// AplayerControl.xaml 的交互逻辑
        /// </summary>
        public partial class AplayerControl : UserControl
        {
                private static AplayerControl _instance = null;
                public static AplayerControl Instance
                {
                        get
                        {
                                if (_instance == null)
                                {
                                        _instance = new AplayerControl();
                                }
                                return _instance;
                        }
                }

                private Lazy<IPlayerHost> _playerHost = new Lazy<IPlayerHost>(() => ServiceProvider.Instance.GetService<IPlayerHost>());
                public IPlayerHost PlayerHost
                {
                        get
                        {
                                return _playerHost.Value;
                        }
                }

                private PlayerControlHostWindow _playerControlHostWindow = null;

                private AplayerControl()
                {
                        InitializeComponent();
                }

                private bool _isInitedFlag = false;
                public void Inited()
                {
                        if (!this._isInitedFlag)
                        {
                                this._isInitedFlag = true;
                                Window window = Window.GetWindow(this);

                                if (window == null)
                                {
                                        throw new Exception("初始化错误，未发现主窗口");
                                }

                                this.Content = this.PlayerHost.HostElement;

                                this._playerControlHostWindow = PlayerControlHostWindow.Create(window);
                                this._playerControlHostWindow.Content = new PlayerController()
                                {
                                        NotAtHostWindow = false
                                };

                                ////TODO 初始化播放器
                                ////硬件加速
                                //this.PlayerHost.SendConfig(ConfigID.Speedupenable, "1");
                                //this.PlayerHost.SendConfig(ConfigID.Logofile, "S");
                                //this.PlayerHost.SendConfig(ConfigID.Logosettings, (0x000000).ToString());
                        }
                }

                public void Detach()
                {
                        this._playerControlHostWindow?.DisConnect();
                        this._playerControlHostWindow?.Hide();
                }

                public void Attach()
                {
                        this.Inited();
                        this._playerControlHostWindow?.Connect(Window.GetWindow(this));
                }
        }
}
