using AxAPlayer3Lib;
using Microsoft.Win32;
using SuperPlayer.Business;
using SuperPlayer.Business.Models;
using SuperPlayer.Components;
using SuperPlayer.Core;
using SuperPlayer.Core.Service;
using SuperPlayer.Core.Utilities;
using SuperPlayer.Dialogs;
using SuperPlayer.Helper;
using SuperPlayer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UltimateCore.Commands;
using UltimatePresentation.Presentation;

namespace SuperPlayer
{
        public enum HostPage
        {
                Host,
                Detail,
                Preview
        }
        /// <summary>
        /// MainWindow.xaml 的交互逻辑
        /// </summary>
        public partial class MainWindow
        {
                private Lazy<IPlayerHost> _playerHost = new Lazy<IPlayerHost>(() => ServiceProvider.Instance.GetService<IPlayerHost>());
                public IPlayerHost PlayerHost
                {
                        get
                        {
                                return _playerHost.Value;
                        }
                }

                public MainWindow()
                {
                        InitializeComponent();

                        SystemCommandManager.Instance.CommandExecuteAction = this.SystemCommandExecuteAction;
                        SystemCommandManager.Instance.CommandCanExecuteAction = this.SystemCommandCanExecuteAction;

                        this.ShowView(MediaCenter.Instance);

                        this.Loaded += MainWindow_Loaded;
                        this.PlayerHost.Message += PlayerHost_Message;

                        this.SourceInitialized += (sender, e) =>
                        {
                                this.LoopUpdateHost();
                        };
                }

                private async void LoopUpdateHost()
                {
                        while (true)
                        {
                                if (this.RichViewItems.Count > 0)
                                {
                                        if (this.RichViewItems[0] is MediaCenter)
                                        {
                                                if (this.TopDialog != null)
                                                {
                                                        if (this.TopDialog is MediaItemDetailDialog mediaItemDetail
                                                                && mediaItemDetail.PlayingIfSame())
                                                        {
                                                                this.PlayerHost.ShowAtDetail();
                                                        }
                                                        else
                                                        {
                                                                this.PlayerHost.Hide();
                                                        }
                                                }
                                                else
                                                {
                                                        FileType fileType = this.PlayerHost.CurrentFileType();

                                                        if (fileType == FileType.Video)
                                                        {
                                                                this.PlayerHost.ShowAtPreview();
                                                        }
                                                }
                                        }
                                        else if (this.RichViewItems[0] is AplayerControl)
                                        {
                                                this.PlayerHost.ShowAtHost();
                                        }
                                }
                                await Task.Delay(100);
                        }
                }

                private void PlayerHost_Message(int msgid, object arg2)
                {
                        //673 MouseEnter
                        //675 MouseLeve
                        //513 MouseDown
                        //514 MouseUp

                        if (msgid == 514)
                        {
                                this.Dispatcher.Invoke(new Action(() =>
                                {
                                        SystemCommandManager.Instance[SystemCommand.Player].Execute(null, this);
                                }));
                        }
                }

                private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
                {
                        try
                        {
                                this.RichViewControl.IsAnimationActive = true;
                                await Task.Factory.StartNew(ServiceProvider.Instance.GetService<IDataContext>().InitData, null);
                        }
                        catch (Exception ex)
                        {
                                this.Bubble("初始化数据异常");
                        }
                        finally
                        {
                                this.RichViewControl.IsAnimationActive = false;
                        }
                }

                protected override void OnClosing(CancelEventArgs e)
                {
                        base.OnClosing(e);

                        if (ServiceProvider.Instance.HasService<IPlayerHost>())
                        {
                                ServiceProvider.Instance.GetService<IPlayerHost>().Dispose();
                        }
                }

                private bool SystemCommandCanExecuteAction(SystemCommand key, UICommandParameter<SystemCommand> param)
                {
                        switch (key)
                        {
                                case SystemCommand.Normal:
                                        return this.WindowState == WindowState.Maximized;

                                case SystemCommand.Maximized:
                                        return this.WindowState == WindowState.Normal;

                                case SystemCommand.FullScreen:
                                        return !this.CheckIsFullScreen();

                                case SystemCommand.FullScreenCancel:
                                        return this.CheckIsFullScreen();
                        }

                        return true;
                }

                /// <summary>
                /// 3：最大化窗口
                /// 2：最小化窗口
                /// 1：正常大小窗口；
                /// </summary>
                [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
                public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
                private async void SystemCommandExecuteAction(SystemCommand key, UICommandParameter<SystemCommand> param)
                {
                        switch (key)
                        {
                                case SystemCommand.Minimized:
                                        this.WindowState = WindowState.Minimized;
                                        break;

                                case SystemCommand.Normal:
                                        this.WindowState = WindowState.Normal;
                                        break;

                                case SystemCommand.Maximized:
                                        this.WindowState = WindowState.Maximized;
                                        break;

                                case SystemCommand.Close:
                                        this.Close();
                                        break;

                                case SystemCommand.MediaCenter:
                                        {
                                                this.ShowView(MediaCenter.Instance);
                                                this.CloseView(AplayerControl.Instance);
                                                AplayerControl.Instance.Detach();
                                                //this.PlayerHost.ShowAtPreview();
                                        }
                                        break;

                                case SystemCommand.Player:
                                        {
                                                this.CloseView(MediaCenter.Instance);
                                                this.ShowView(AplayerControl.Instance);
                                                AplayerControl.Instance.Attach();
                                                //this.PlayerHost.ShowAtHost();
                                        }
                                        break;

                                case SystemCommand.FullScreen:
                                        this.FullScreen();
                                        break;

                                case SystemCommand.FullScreenCancel:
                                        this.FullScreenCancel();
                                        break;

                                case SystemCommand.Recommend:
                                case SystemCommand.Collection:
                                case SystemCommand.SpecialTopic:
                                case SystemCommand.VideoLibrary:
                                        MediaCenter.Instance.SystemCommandExecuteAction(key, param);
                                        break;

                                case SystemCommand.ShowItemDetail:
                                        {
                                                MediaItemDetailDialogResult result = await MediaItemDetailDialog.ShowResult(new MediaItemDetailDialogParameter
                                                {
                                                        MediaItem = param.Parameter as MediaItemModel
                                                }, this);
                                        }
                                        break;

                                case SystemCommand.ItemPlay:
                                        {
                                                MediaItemModel mediaItem = param.Parameter as MediaItemModel;

                                                if (mediaItem != null
                                                        && mediaItem.Entity != null)
                                                {
                                                        MediaCenter.Instance.SystemCommandExecuteAction(key, param);

                                                        //switch ((FileType)mediaItem.Entity.ItemType)
                                                        //{
                                                        //        case FileType.UnKnow:
                                                        //                break;

                                                        //        case FileType.Video:
                                                        //                SystemCommandManager.Instance[SystemCommand.Player].Execute(param.Parameter, null);
                                                        //                ServiceProvider.Instance.GetService<IPlayerHost>().SendMessage(PlayerMessage.OpenFileName, mediaItem.Entity.Path);
                                                        //                break;

                                                        //        case FileType.Audio:
                                                        //                break;

                                                        //        case FileType.Image:
                                                        //                break;

                                                        //        case FileType.SubTitle:
                                                        //                break;

                                                        //        default:
                                                        //                break;
                                                        //}
                                                }
                                        }
                                        break;
                        }
                }
        }
}
