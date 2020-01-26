using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using SuperApp.Shell.Controls;
using SuperPlayer.Business;
using SuperPlayer.Business.Generates;
using SuperPlayer.Business.Models;
using SuperPlayer.Core;
using SuperPlayer.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SuperPlayer.Views.MediaCenterComponents
{
    /// <summary>
    /// VideoLibraryView.xaml 的交互逻辑
    /// </summary>
    public partial class VideoLibraryView : UserControl
    {
        public readonly Lazy<IDataContext> _dataContext = new Lazy<IDataContext>(() => ServiceProvider.Instance.GetService<IDataContext>());
        public IDataContext BusinessDataContext
        {
            get => this._dataContext.Value;
        }

        public FileItemProducer<MediaItemModel> ItemGenerate
        {
            get;
            protected set;
        }
        public VideoLibraryView()
        {
            InitializeComponent();
        }

        public async void EnumMedias(MediaDirectoryModel mediaDirectory)
        {
            if (mediaDirectory != null)
            {
                if (mediaDirectory.ItemProducer == null)
                {
                    mediaDirectory.MediaItems.Clear();

                    mediaDirectory.ItemProducer = new FileItemProducer<MediaItemModel>
                    (
                            _p => new MediaItemModel
                            {
                                Entity = new Models.Entity.MediaItem
                                {
                                    Path = _p.FullName,
                                    Name = _p.Name,
                                    Size = _p.Length,
                                    ItemType = (int)DataUtil.CheckFileType(_p.Extension)
                                }
                            },
                            _p => DataUtil.CheckFileType(_p.Extension) != FileType.UnKnow
                    );

                    mediaDirectory.ItemProducer.Initialization(mediaDirectory.Entity.Path);

                    mediaDirectory.ItemProducer.Status = StatusFlag.Running;
                    await Task.Factory.StartNew(() =>
                    {
                        int count = 0;
                        while (mediaDirectory.ItemProducer.ItemEnumerator?.MoveNext() == true)
                        {
                            if (count > 30)
                            {
                                break;
                            }

                            this.Dispatcher.Invoke(new Action(() =>
                            {
                                mediaDirectory.MediaItems.Add(mediaDirectory.ItemProducer.ItemEnumerator.Current);

                            }), DispatcherPriority.Input);

                            count++;
                        }

                    });
                    mediaDirectory.ItemProducer.Status = StatusFlag.Complated;
                }
            }
        }

        private void _cateItem_Click(object sender, RoutedEventArgs e)
        {
            MediaDirectoryModel mediaDirectory = (sender as FrameworkElement)?.Tag as MediaDirectoryModel;
            this.EnumMedias(mediaDirectory);
        }

        private void _openFolderBt_Click(object sender, RoutedEventArgs e)
        {
            MediaDirectoryModel mediaDirectory = (sender as FrameworkElement)?.Tag as MediaDirectoryModel;
            if (!string.IsNullOrEmpty(mediaDirectory?.Entity?.Path))
            {
                try
                {
                    Process.Start(mediaDirectory.Entity.Path);
                }
                catch (Exception)
                {

                }
            }
        }
        private void _refreshBt_Click(object sender, RoutedEventArgs e)
        {
            MediaDirectoryModel mediaDirectory = (sender as FrameworkElement)?.Tag as MediaDirectoryModel;
            if (mediaDirectory != null)
            {
                mediaDirectory.ItemProducer?.Dispose();
                mediaDirectory.ItemProducer = null;
                this.EnumMedias(mediaDirectory);
            }
        }

        private void _showDetailBt_Click(object sender, RoutedEventArgs e)
        {
            MediaItemModel mediaItem = (sender as FrameworkElement)?.Tag as MediaItemModel;
            if (mediaItem != null)
            {
                SystemCommandManager.Instance[SystemCommand.ShowItemDetail].Execute(mediaItem, null);
            }
        }

        private void _playBt_Click(object sender, RoutedEventArgs e)
        {
            MediaItemModel mediaItem = (sender as FrameworkElement)?.Tag as MediaItemModel;
            if (mediaItem != null)
            {
                SystemCommandManager.Instance[SystemCommand.ItemPlay].Execute(mediaItem, null);
            }
        }

        private void _addDirBt_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog commonFileDialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true
            };
            if (commonFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                this.BusinessDataContext.AddMediaDirectory(commonFileDialog.FileName);
            }
        }


        private async void SpacingWrapPanel_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null
                    && e.Delta < 0)
            {
                ScrollViewer scrollViewer = panel.GetParentByType<ScrollViewer>();

                if (scrollViewer != null)
                {
                    double dVer = scrollViewer.VerticalOffset;
                    double dViewport = scrollViewer.ViewportHeight;
                    double dExtent = scrollViewer.ExtentHeight;

                    //滚动至最底部
                    if (dVer + dViewport >= dExtent)
                    {
                        ListControl listControl = scrollViewer.GetParentByType<ListControl>();

                        MediaDirectoryModel mediaDirectory = listControl?.Tag as MediaDirectoryModel;

                        if (mediaDirectory != null
                                && mediaDirectory.ItemProducer != null
                                && (mediaDirectory.ItemProducer.Status == StatusFlag.Complated || mediaDirectory.ItemProducer.Status == StatusFlag.WaitForStart))
                        {
                            mediaDirectory.ItemProducer.Status = StatusFlag.Running;

                            await Task.Factory.StartNew(() =>
                            {
                                int count = 0;
                                while (mediaDirectory.ItemProducer.ItemEnumerator?.MoveNext() == true)
                                {
                                    if (count > 30)
                                    {
                                        break;
                                    }

                                    this.Dispatcher.Invoke(new Action(() =>
                                                               {

                                                mediaDirectory.MediaItems.Add(mediaDirectory.ItemProducer.ItemEnumerator.Current);

                                            }), DispatcherPriority.Input);

                                    count++;
                                }
                            });

                            mediaDirectory.ItemProducer.Status = StatusFlag.Complated;
                        }
                    }
                }
            }
        }

        private void _hiddenPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                MediaItemModel mediaItem = (sender as FrameworkElement)?.Tag as MediaItemModel;
                if (mediaItem != null)
                {
                    SystemCommandManager.Instance[SystemCommand.ItemPlay].Execute(mediaItem, null);
                }
            }
        }
    }
}
