using SuperPlayer.Business;
using SuperPlayer.Core;
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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using UltimateCore;

namespace SuperPlayer.Views
{
        /// <summary>
        /// PlayerController.xaml 的交互逻辑
        /// </summary>
        public partial class PlayerController : UserControl
        {
                private Lazy<IPlayerHost> _playerHost = new Lazy<IPlayerHost>(() => ServiceProvider.Instance.GetService<IPlayerHost>());
                public IPlayerHost PlayerHost
                {
                        get
                        {
                                return _playerHost.Value;
                        }
                }

                public bool NotAtHostWindow
                {
                        get
                        {
                                return (bool)GetValue(NotAtHostWindowProperty);
                        }
                        set
                        {
                                SetValue(NotAtHostWindowProperty, value);
                        }
                }
                public static readonly DependencyProperty NotAtHostWindowProperty = DependencyProperty.Register("NotAtHostWindow", typeof(bool), typeof(PlayerController), new PropertyMetadata(false));

                public PlayerController()
                {
                        InitializeComponent();
                        this.LoopUpdate();
                }

                private void SendMessage(PlayerMessage msgid, object param)
                {
                        this.PlayerHost?.SendMessage(msgid, param);
                }

                private object GetMessage(PlayerMessage msgid, object param)
                {
                        return this.PlayerHost?.GetMessage(msgid, param);
                }

                private void UserControl_Drop(object sender, DragEventArgs e)
                {
                        string fileName = (e.Data.GetData(DataFormats.FileDrop) as Array)?.GetValue(0)?.ToString();
                        if (!string.IsNullOrEmpty(fileName))
                        {
                                string extension = string.Empty;
                                int index = fileName.LastIndexOf('.');
                                if (index >= 0)
                                {
                                        extension = fileName.Substring(index);

                                        FileType filetype = DataUtil.CheckFileType(extension);

                                        switch (filetype)
                                        {
                                                case FileType.Video:
                                                case FileType.Audio:
                                                        this.SendMessage(PlayerMessage.OpenFileName, fileName);
                                                        break;

                                                case FileType.Image:
                                                        break;

                                                case FileType.SubTitle:
                                                        this.PlayerHost?.SendConfig(ConfigID.Subtiltefilename, fileName);
                                                        this.PlayerHost?.SendConfig(ConfigID.Subtitleshow, "1");
                                                        break;
                                        }
                                }
                                else
                                {

                                }

                        }
                }

                private void Grid_Click(object sender, RoutedEventArgs e)
                {
                        ButtonBase bt = e.OriginalSource as ButtonBase;
                        if (bt != null)
                        {
                                switch (bt.Name + "")
                                {
                                        case "_openFile":
                                                this.SendMessage(PlayerMessage.Open, null);
                                                break;

                                        case "_openUrl":
                                                this.SendMessage(PlayerMessage.OpenURL, this._fileUrl.Text);
                                                break;

                                        case "_stopBt":
                                                this.SendMessage(PlayerMessage.Stop, null);
                                                break;

                                        case "_playPauseCheckBt":
                                                {
                                                        CheckBox checkbt = bt as CheckBox;
                                                        if (checkbt?.IsChecked == true)
                                                        {
                                                                this.SendMessage(PlayerMessage.Play, null);
                                                        }
                                                        else
                                                        {
                                                                this.SendMessage(PlayerMessage.Pause, null);
                                                        }
                                                }
                                                break;

                                        case "_volumeCheckBt":
                                                {
                                                        CheckBox checkbt = bt as CheckBox;
                                                        if (checkbt?.IsChecked == true)
                                                        {
                                                                this.PlayerHost?.SendConfig(ConfigID.Soundsilent, "1");
                                                        }
                                                        else
                                                        {
                                                                this.PlayerHost?.SendConfig(ConfigID.Soundsilent, "0");
                                                        }
                                                }
                                                break;
                                        default:
                                                break;
                                }
                        }
                }

                private bool _isUpdatingPosionValue = false;
                private void _videoPosition_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
                {
                        if (!this._isUpdatingPosionValue)
                        {
                                this._isUpdatingPosionValue = true;

                                if (this._videoPosition.Maximum > 0)
                                {
                                        var proportion = this._videoPosition.Value / this._videoPosition.Maximum;

                                        object duraobj = this.PlayerHost.GetMessage(PlayerMessage.Duration, this);

                                        if (duraobj != null
                                              && long.TryParse(duraobj + "", out long duration))
                                        {
                                                long posion = (long)(duration * proportion);

                                                this.PlayerHost.SendMessage(PlayerMessage.Position, posion);
                                        }
                                }

                                this._isUpdatingPosionValue = false;
                        }
                }


                private bool _isUpdatingVolume = false;
                private void _volumePosition_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
                {
                        if (!this._isUpdatingVolume)
                        {
                                this._isUpdatingVolume = true;
                                this.PlayerHost.SendMessage(PlayerMessage.Volume, (int)this._volumePosition.Value);
                                this._isUpdatingVolume = false;
                        }
                }
        }
}
