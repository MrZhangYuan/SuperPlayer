using SuperPlayer.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using UltimateCore;
using System.Windows.Controls;
using System.Windows;

namespace SuperPlayer.Views
{
        public partial class PlayerController
        {
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
                        if (this.PlayerHost != null)
                        {
                                Stopwatch sw = Stopwatch.StartNew();

                                string state = this.PlayerHost.GetMessage(PlayerMessage.State, this) + "";

                                if (Enum.TryParse<PLAY_STATE>(state, out PLAY_STATE paystate))
                                {
                                        switch (paystate)
                                        {
                                                case PLAY_STATE.PS_READY:
                                                        this._openPanel.Visibility = Visibility.Visible;
                                                        this._playPauseCheckBt.IsChecked = false;
                                                        break;

                                                case PLAY_STATE.PS_CLOSING:
                                                case PLAY_STATE.PS_PAUSING:
                                                case PLAY_STATE.PS_PAUSED:
                                                        this._openPanel.Visibility = Visibility.Collapsed;
                                                        this._playPauseCheckBt.IsChecked = false;
                                                        break;

                                                case PLAY_STATE.PS_OPENING:
                                                case PLAY_STATE.PS_PLAYING:
                                                case PLAY_STATE.PS_PLAY:
                                                        this._openPanel.Visibility = Visibility.Collapsed;
                                                        this._playPauseCheckBt.IsChecked = true;
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
                                                && !this._isUpdatingPosionValue)
                                        {
                                                this._isUpdatingPosionValue = true;
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

                                                this._isUpdatingPosionValue = false;
                                        }
                                }

                                string currentfile = this.PlayerHost.GetConfig(ConfigID.CurrentURL, this) + "";
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

                                if (!this._isUpdatingVolume)
                                {
                                        this._isUpdatingVolume = true;
                                        this._volumePosition.Value = (int)this.PlayerHost.GetMessage(PlayerMessage.Volume, null);
                                        this._isUpdatingVolume = false;
                                }

                                sw.Stop();
                        }
                }
        }
}
