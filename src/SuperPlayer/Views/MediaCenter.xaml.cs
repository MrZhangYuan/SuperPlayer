using SuperPlayer.Business;
using SuperPlayer.Business.Models;
using SuperPlayer.Components;
using SuperPlayer.Core;
using SuperPlayer.Core.Utilities;
using SuperPlayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TransitionEffects;
using UltimateCore.Commands;

namespace SuperPlayer.Views
{
        /// <summary>
        /// MediaCenter.xaml 的交互逻辑
        /// </summary>
        public partial class MediaCenter : UserControl
        {
                private static MediaCenter _instance = null;
                public static MediaCenter Instance
                {
                        get
                        {
                                if (_instance == null)
                                {
                                        _instance = new MediaCenter();
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
                private MediaCenter()
                {
                        InitializeComponent();
                        this.DataContext = MediaCenterViewModel.Instance;
                        this._musicBarContainer.Content = MusicBar.Instance;
                        //  this.AddHandler(PreviewMouseDownEvent, new MouseButtonEventHandler(this.MediaCenter_PreviewMouseDown), true);

                        //   this.PreviewMouseDown += MediaCenter_PreviewMouseDown;
                }


                private TransitionEffect _TransitionEffect = new RippleTransitionEffect();
                private readonly DoubleAnimation _Animation = new DoubleAnimation
                {
                        From = 1,
                        To = 0,
                        AutoReverse = true,
                        Duration = new Duration(TimeSpan.FromMilliseconds(500)),
                        FillBehavior = FillBehavior.HoldEnd,
                        AccelerationRatio = 0.5,
                        DecelerationRatio = 0.5
                };
                private void MediaCenter_PreviewMouseDown(object sender, MouseButtonEventArgs e)
                {
                        VisualBrush vbrush = new VisualBrush(this);

                        _TransitionEffect = _TransitionEffect.Clone() as TransitionEffect;

                        this.Effect = _TransitionEffect;

                        // _TransitionEffect.Input = vbrush.Clone();
                        _TransitionEffect.OldImage = vbrush.Clone();
                        _TransitionEffect.BeginAnimation(TransitionEffect.ProgressProperty, _Animation);
                }

                public void SystemCommandExecuteAction(SystemCommand key, UICommandParameter<SystemCommand> param)
                {
                        switch (key)
                        {
                                case SystemCommand.OpenMenu:
                                        break;
                                case SystemCommand.Minimized:
                                        break;
                                case SystemCommand.Normal:
                                        break;
                                case SystemCommand.Maximized:
                                        break;
                                case SystemCommand.Close:
                                        break;
                                case SystemCommand.FullScreen:
                                        break;
                                case SystemCommand.FullScreenCancel:
                                        break;
                                case SystemCommand.MediaCenter:
                                        break;
                                case SystemCommand.Player:
                                        break;
                                case SystemCommand.Recommend:
                                        break;
                                case SystemCommand.Collection:
                                        break;
                                case SystemCommand.SpecialTopic:
                                        break;
                                case SystemCommand.VideoLibrary:
                                        break;
                                case SystemCommand.ShowItemDetail:
                                        break;
                                case SystemCommand.ItemPlay:
                                        {
                                                MediaItemModel mediaItem = param.Parameter as MediaItemModel;

                                                if (mediaItem != null
                                                        && mediaItem.Entity != null)
                                                {
                                                        switch ((FileType)mediaItem.Entity.ItemType)
                                                        {
                                                                case FileType.Audio:
                                                                case FileType.Video:
                                                                        MusicBar.Instance.Play(mediaItem);
                                                                        break;

                                                                default:
                                                                        MusicBar.Instance.Stop();
                                                                        break;
                                                        }
                                                }
                                        }
                                        break;
                                case SystemCommand.Last:
                                        break;
                        }
                }
        }
}
