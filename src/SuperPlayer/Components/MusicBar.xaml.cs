using SuperPlayer.Business;
using SuperPlayer.Business.Models;
using SuperPlayer.Core;
using SuperPlayer.Core.Utilities;
using SuperPlayer.Helper;
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
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UltimateCore;

namespace SuperPlayer.Components
{
    /// <summary>
    /// MusicBar.xaml 的交互逻辑
    /// </summary>
    public partial class MusicBar : UserControl
    {
        private static MusicBar _instance = null;
        public static MusicBar Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MusicBar();
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

        private MusicBar()
        {
            InitializeComponent();
            this._videoPreview.Content = this.PlayerHost.PreviewHostElement;
            this.LoopUpdate();
        }
        private async void LoopUpdate()
        {
            while (true)
            {
                try
                {
                    this.UpdateCore();
                }
                catch (Exception)
                {
                }
                await Task.Delay(200);
            }
        }

        public void UpdateCore()
        {
            FileType type = this.PlayerHost.CurrentFileType();
            if (type == FileType.Video)
            {
                this._videoPreview.Visibility = Visibility.Visible;
            }
            else
            {
                this._videoPreview.Visibility = Visibility.Collapsed;
            }

            if (this.Visibility != Visibility.Visible)
            {
                return;
            }

            if (this.PlayerHost != null)
            {
                Stopwatch sw = Stopwatch.StartNew();

                string state = this.PlayerHost.GetMessage(PlayerMessage.State, this) + "";

                if (Enum.TryParse<PLAY_STATE>(state, out PLAY_STATE paystate))
                {
                    switch (paystate)
                    {
                        case PLAY_STATE.PS_READY:
                            this._playPauseCheckBt.IsChecked = false;

                            //this._stopBt.Visibility = Visibility.Hidden;
                            break;

                        case PLAY_STATE.PS_CLOSING:
                        case PLAY_STATE.PS_PAUSING:
                        case PLAY_STATE.PS_PAUSED:
                            this._playPauseCheckBt.IsChecked = false;

                            //this._stopBt.Visibility = Visibility.Visible;
                            break;

                        case PLAY_STATE.PS_OPENING:
                        case PLAY_STATE.PS_PLAYING:
                        case PLAY_STATE.PS_PLAY:
                            this._playPauseCheckBt.IsChecked = true;

                            //this._stopBt.Visibility = Visibility.Visible;
                            break;
                    }
                }

                if (state == ((int)PLAY_STATE.PS_PLAY).ToString()
                        || state == ((int)PLAY_STATE.PS_PAUSED).ToString())
                {
                    object duraobj = this.PlayerHost.GetMessage(PlayerMessage.Duration, this);
                    object posionobj = this.PlayerHost.GetMessage(PlayerMessage.Position, this);

                    if (duraobj != null
                            && posionobj != null
                            && long.TryParse(duraobj + "", out long duration)
                            && long.TryParse(posionobj + "", out long posion)
                            && !this._isUpdatingValue)
                    {
                        this._isUpdatingValue = true;
                        this._videoPosition.Maximum = duration;
                        this._videoPosition.Value = posion;

                        TimeSpan durationtime = TimeSpan.FromMilliseconds(duration);
                        if (durationtime > TimeSpan.FromHours(1))
                        {
                            this._posionCurrent.Text = TimeSpan.FromMilliseconds(posion).ToString(@"hh\:mm\:ss");
                            this._posionEnd.Text = TimeSpan.FromMilliseconds(duration).ToString(@"hh\:mm\:ss");
                        }
                        else
                        {
                            this._posionCurrent.Text = TimeSpan.FromMilliseconds(posion).ToString(@"mm\:ss");
                            this._posionEnd.Text = TimeSpan.FromMilliseconds(duration).ToString(@"mm\:ss");
                        }

                        this._isUpdatingValue = false;
                    }
                }

                string currentfile = this.PlayerHost.CurrentURL();
                if (!string.IsNullOrEmpty(currentfile))
                {
                    int lastindex = currentfile.LastIndexOf('\\');
                    if (lastindex < 0)
                    {
                        lastindex = currentfile.LastIndexOf('/');
                    }
                    if (lastindex >= 0)
                    {
                        this._titleText.Text = currentfile.Substring(lastindex).TrimStart('\\').TrimStart('/');
                    }
                }
                else
                {
                    this._titleText.Text = "I'M THE KING OF THE WORLD";
                }
                sw.Stop();
            }
        }

        private bool _isUpdatingValue = false;
        private void _videoPosition_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!this._isUpdatingValue)
            {
                this._isUpdatingValue = true;

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

                this._isUpdatingValue = false;
            }
        }

        public void Play(MediaItemModel mediaItem)
        {
            if (!string.IsNullOrEmpty(mediaItem?.Entity?.Path))
            {
                this.PlayerHost.SendMessage(PlayerMessage.OpenFileName, mediaItem.Entity.Path);
            }
        }

        public void Stop()
        {
            this.PlayerHost.SendMessage(PlayerMessage.Stop, null);
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            ButtonBase bt = e.OriginalSource as ButtonBase;
            if (bt != null)
            {
                switch (bt.Name + "")
                {
                    case "_openFile":
                        this.PlayerHost.SendMessage(PlayerMessage.Open, null);
                        break;

                    case "_openUrl":

                        break;

                    case "_playBt":
                        this.PlayerHost.SendMessage(PlayerMessage.Play, null);
                        break;

                    case "_pauseBt":
                        this.PlayerHost.SendMessage(PlayerMessage.Pause, null);
                        break;

                    case "_stopBt":
                        this.PlayerHost.SendMessage(PlayerMessage.Stop, null);
                        break;

                    case "_playPauseCheckBt":
                        {
                            CheckBox checkbt = bt as CheckBox;
                            if (checkbt?.IsChecked == true)
                            {
                                this.PlayerHost.SendMessage(PlayerMessage.Play, null);
                            }
                            else
                            {
                                this.PlayerHost.SendMessage(PlayerMessage.Pause, null);
                            }
                        }
                        break;

                    case "_listBt":
                        this._listPopup.IsOpen = true;
                        break;


                    default:
                        break;
                }
            }
        }
    }
}
