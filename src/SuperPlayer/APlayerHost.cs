using AxAPlayer3Lib;
using Microsoft.Win32;
using SuperPlayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.Integration;

namespace SuperPlayer
{
        public class APlayerHost : IPlayerHost
        {
                public FrameworkElement HostElement
                {
                        get;
                }

                public FrameworkElement DetailHostElement
                {
                        get;
                }

                public FrameworkElement PreviewHostElement
                {
                        get;
                }

                public AxPlayer Player
                {
                        get;
                }

                public double HostWidth
                {
                        get => this.HostElement.ActualWidth;
                }
                public double HostHeight
                {
                        get => this.HostElement.ActualHeight;
                }

                public event Action<int, object> Message;

                public void ShowAtHost()
                {
                        if (((WindowsFormsHost)this.HostElement).Child != this.Player)
                        {
                                this.PlayerInited(1);
                                ((WindowsFormsHost)this.PreviewHostElement).Child = null;
                                ((WindowsFormsHost)this.DetailHostElement).Child = null;
                                ((WindowsFormsHost)this.HostElement).Child = this.Player;
                        }
                }
                public void ShowAtDetail()
                {
                        if (((WindowsFormsHost)this.DetailHostElement).Child != this.Player)
                        {
                                this.PlayerInited(2);
                                ((WindowsFormsHost)this.HostElement).Child = null;
                                ((WindowsFormsHost)this.PreviewHostElement).Child = null;
                                ((WindowsFormsHost)this.DetailHostElement).Child = this.Player;
                        }
                }
                public void ShowAtPreview()
                {
                        if (((WindowsFormsHost)this.PreviewHostElement).Child != this.Player)
                        {
                                this.PlayerInited(3);
                                ((WindowsFormsHost)this.HostElement).Child = null;
                                ((WindowsFormsHost)this.DetailHostElement).Child = null;
                                ((WindowsFormsHost)this.PreviewHostElement).Child = this.Player;
                        }
                }

                public void Hide()
                {
                        ((WindowsFormsHost)this.HostElement).Child = null;
                        ((WindowsFormsHost)this.DetailHostElement).Child = null;
                        ((WindowsFormsHost)this.PreviewHostElement).Child = null;
                }

                private bool _isPlayerInited = false;
                private void PlayerInited(int host = 1)
                {
                        if (!this._isPlayerInited)
                        {
                                this._isPlayerInited = true;
                                this.Player.BeginInit();
                                if (host == 1)
                                {
                                        ((WindowsFormsHost)this.PreviewHostElement).Child = null;
                                        ((WindowsFormsHost)this.DetailHostElement).Child = null;
                                        ((WindowsFormsHost)this.HostElement).Child = this.Player;
                                }
                                else if (host == 2)
                                {
                                        ((WindowsFormsHost)this.HostElement).Child = null;
                                        ((WindowsFormsHost)this.PreviewHostElement).Child = null;
                                        ((WindowsFormsHost)this.DetailHostElement).Child = this.Player;
                                }
                                else
                                {
                                        ((WindowsFormsHost)this.HostElement).Child = null;
                                        ((WindowsFormsHost)this.DetailHostElement).Child = null;
                                        ((WindowsFormsHost)this.PreviewHostElement).Child = this.Player;
                                }
                                this.Player.EndInit();

                                //TODO 初始化播放器
                                //硬件加速
                                this.SendConfig(ConfigID.Speedupenable, "1");
                                this.SendConfig(ConfigID.Logofile, "S");
                                this.SendConfig(ConfigID.Logosettings, (0x000000).ToString());
                        }
                }
                public APlayerHost()
                {
                        HostElement = new WindowsFormsHost();
                        PreviewHostElement = new WindowsFormsHost();
                        this.DetailHostElement = new WindowsFormsHost();
                        this.Player = new AxPlayer();

                        this.ShowAtHost();


                        this.Player.OnVideoSizeChanged += Player_OnVideoSizeChanged;
                        this.Player.OnBuffer += Player_OnBuffer;
                        this.Player.OnSeekCompleted += Player_OnSeekCompleted;
                        this.Player.OnOpenSucceeded += Player_OnOpenSucceeded;
                        this.Player.OnMessage += Player_OnMessage;
                        this.Player.OnDownloadCodec += Player_OnDownloadCodec;
                        this.Player.OnEvent += Player_OnEvent;
                        this.Player.OnStateChanged += Player_OnStateChanged;
                }

                private void Player_OnStateChanged(object sender, _IPlayerEvents_OnStateChangedEvent e)
                {
                        //PLAY_STATE newstate = (PLAY_STATE)e.nNewState;

                        //if (newstate == PLAY_STATE.PS_READY
                        //        || newstate == PLAY_STATE.PS_OPENING)
                        //{
                        //        this.HostElement.Visibility = Visibility.Collapsed;
                        //}
                        //else
                        //{
                        //        this.HostElement.Visibility = Visibility.Visible;
                        //}
                }

                private void Player_OnEvent(object sender, _IPlayerEvents_OnEventEvent e)
                {
                }

                private void Player_OnDownloadCodec(object sender, _IPlayerEvents_OnDownloadCodecEvent e)
                {

                }

                private void Player_OnMessage(object sender, _IPlayerEvents_OnMessageEvent e)
                {
                        this.OnMessage(e.nMessage, null);
                }

                private void Player_OnOpenSucceeded(object sender, EventArgs e)
                {

                }

                private void Player_OnSeekCompleted(object sender, _IPlayerEvents_OnSeekCompletedEvent e)
                {

                }

                private void Player_OnBuffer(object sender, _IPlayerEvents_OnBufferEvent e)
                {

                }

                private void Player_OnVideoSizeChanged(object sender, EventArgs e)
                {

                }


                protected void OnMessage(int msgid, object param)
                {
                        this.Message?.Invoke(msgid, param);
                }

                public void SendMessage(PlayerMessage msgid, object param)
                {
                        if (!this._disposed)
                        {
                                switch (msgid)
                                {
                                        case PlayerMessage.OpenFileName:
                                                this.Player.Open(param + "");
                                                break;

                                        case PlayerMessage.OpenURL:
                                                this.Player.Open(param + "");
                                                break;

                                        case PlayerMessage.Open:
                                                OpenFileDialog dialog = new OpenFileDialog();
                                                if (dialog.ShowDialog() == true)
                                                {
                                                        this.Player.Open(dialog.FileName);
                                                }
                                                break;

                                        case PlayerMessage.Stop:
                                                this.Player.Close();
                                                break;

                                        case PlayerMessage.Play:
                                                this.Player.Play();
                                                break;

                                        case PlayerMessage.Pause:
                                                this.Player.Pause();
                                                break;

                                        case PlayerMessage.State:
                                                break;

                                        case PlayerMessage.Duration:
                                                break;

                                        case PlayerMessage.Position:
                                                if (param != null
                                                        && long.TryParse(param + "", out long posion))
                                                {
                                                        this.Player.SetPosition((int)posion);
                                                }
                                                break;

                                        case PlayerMessage.Volume:
                                                if (param != null
                                                        && int.TryParse(param + "", out int volume))
                                                {
                                                        this.Player.SetVolume(volume);
                                                }
                                                break;

                                        case PlayerMessage.VideoSize:
                                                break;

                                        case PlayerMessage.IsSeeking:
                                                break;

                                        case PlayerMessage.Version:
                                                break;
                                }
                        }
                }
                public object GetMessage(PlayerMessage msgid, object param)
                {
                        if (!this._disposed)
                        {
                                switch (msgid)
                                {
                                        case PlayerMessage.OpenFileName:
                                                break;
                                        case PlayerMessage.Play:
                                                break;
                                        case PlayerMessage.Pause:
                                                break;
                                        case PlayerMessage.State:
                                                return this.Player.GetState();

                                        case PlayerMessage.Duration:
                                                return this.Player.GetDuration();

                                        case PlayerMessage.Position:
                                                return this.Player.GetPosition();

                                        case PlayerMessage.Volume:
                                                return this.Player.GetVolume();

                                        case PlayerMessage.VideoSize:
                                                return new Size(this.Player.GetVideoWidth(), this.Player.GetVideoHeight());

                                        case PlayerMessage.IsSeeking:
                                                return this.Player.IsSeeking();

                                        case PlayerMessage.Version:
                                                return this.Player.GetVersion();
                                }
                        }
                        return null;
                }

                public void SendConfig(ConfigID cfgid, object param)
                {
                        if (!this._disposed)
                        {
                                this.Player.SetConfig((int)cfgid, param + "");
                        }
                }
                public object GetConfig(ConfigID cfgid, object param)
                {
                        if (!this._disposed)
                        {
                                return this.Player.GetConfig((int)cfgid);
                        }
                        return null;
                }

                #region Dispose

                private bool _disposed = false;
                public void Dispose()
                {
                        Dispose(true);
                        GC.SuppressFinalize(this);
                }

                protected virtual void Dispose(bool disposing)
                {
                        if (!this._disposed)
                        {
                                if (disposing)
                                {
                                        // Dispose managed resources.
                                        this.Player.Close();
                                        this.Player.Dispose();
                                }

                                // unmanaged resources here.

                                _disposed = true;
                        }
                }
                ~APlayerHost()
                {
                        Dispose(false);
                }

                #endregion
        }
}
