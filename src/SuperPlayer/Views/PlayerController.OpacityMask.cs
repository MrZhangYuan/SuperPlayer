using SuperPlayer.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using UltimateCore;

namespace SuperPlayer.Views
{
        public partial class PlayerController
        {
                private TimerBuffer<object> _updateOpacityMaskTimer = null;
                protected TimerBuffer<object> UpdateOpacityMaskTimer
                {
                        get
                        {
                                if (this._updateOpacityMaskTimer == null)
                                {
                                        this._updateOpacityMaskTimer = new TimerBuffer<object>
                                        {
                                                DueTime = 5 * 1000
                                        };

                                        this._updateOpacityMaskTimer.Action = this.UpdateOpacityMask;
                                }

                                return this._updateOpacityMaskTimer;
                        }
                }

                private Storyboard _setOpacityMaskToZeroSb = null;

                private bool _isOpacityMaskOld = true;

                private void UpdateOpacityMask(object obj)
                {
                        //若是播放状态，控制面板透明，鼠标隐藏
                        string state = this.PlayerHost.GetMessage(PlayerMessage.State, this) + "";
                        if (Enum.TryParse<PLAY_STATE>(state, out PLAY_STATE paystate)
                                && paystate == PLAY_STATE.PS_PLAY)
                        {
                                if (_setOpacityMaskToZeroSb == null)
                                {
                                        _setOpacityMaskToZeroSb = this.TryFindResource("SetOpacityMaskToZeroSbKey") as Storyboard;
                                }
                                if (this._setOpacityMaskToZeroSb != null)
                                {
                                        this.BeginStoryboard(this._setOpacityMaskToZeroSb);
                                }

                                this._isOpacityMaskOld = true;
                        }

                        if (this.IsMouseOver)
                        {
                                this.Cursor = Cursors.None;
                        }
                }

                private void UserControl_MouseMove(object sender, MouseEventArgs e)
                {
                        if (this.Cursor != Cursors.Arrow)
                        {
                                this.Cursor = Cursors.Arrow;
                        }

                        Point point = e.GetPosition(this);

                        if (point.Y <= 100
                                || point.Y > this.ActualHeight - 100
                                || point.X < 100
                                || point.X > this.ActualWidth - 100)
                        {
                                if (this._isOpacityMaskOld)
                                {
                                        this._isOpacityMaskOld = false;
                                        this.OpacityMask = this.OpacityMask?.Clone();
                                }

                        }

                        this.UpdateOpacityMaskTimer.ReSet(null);
                }
        }
}
