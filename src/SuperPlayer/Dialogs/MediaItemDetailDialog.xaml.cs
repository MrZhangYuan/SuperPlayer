using SuperPlayer.Business.Models;
using SuperPlayer.Core;
using SuperPlayer.Core.Utilities;
using SuperPlayer.Helper;
using SuperPlayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
using UltimateCore.Services;
using UltimatePresentation.Presentation;

namespace SuperPlayer.Dialogs
{
    public class MediaItemDetailDialogParameter
    {
        public MediaItemModel MediaItem
        {
            get;
            set;
        }
    }
    public class MediaItemDetailDialogResult
    {

    }

    /// <summary>
    /// MediaItemDetailDialog.xaml 的交互逻辑
    /// </summary>
    public partial class MediaItemDetailDialog
    {
        public readonly Lazy<IBitmapCreater> _bitmapCreater = new Lazy<IBitmapCreater>(() => ServiceProvider.Instance.GetService<IBitmapCreater>());
        public IBitmapCreater BitmapCreater
        {
            get => this._bitmapCreater.Value;
        }

        private Lazy<IPlayerHost> _playerHost = new Lazy<IPlayerHost>(() => ServiceProvider.Instance.GetService<IPlayerHost>());
        public IPlayerHost PlayerHost
        {
            get
            {
                return _playerHost.Value;
            }
        }

        private MediaItemDetailDialog()
        {
            InitializeComponent();
        }


        MediaItemModel _currentMediaItem = null;
        public bool PlayingIfSame()
        {
            if (this._currentMediaItem?.Entity.Path == this.PlayerHost.CurrentURL())
            {
                this._detailPlayerHostContainer.Content = this.PlayerHost.DetailHostElement;
                return true;
            }

            return false;
        }

        public static Task<MediaItemDetailDialogResult> ShowResult(MediaItemDetailDialogParameter param, IDialogContainer container)
        {
            TaskCompletionSource<MediaItemDetailDialogResult> tcs = new TaskCompletionSource<MediaItemDetailDialogResult>();

            MediaItemDetailDialog dialog = new MediaItemDetailDialog
            {
                DataContext = param.MediaItem
            };
            dialog._currentMediaItem = param?.MediaItem;
            dialog._mediaItemImage.SetValue(ImageBuildHelper.SourceURLProperty, param?.MediaItem?.Entity?.Path);

            dialog.DialogClosed += (sender, e) =>
            {
                dialog._detailPlayerHostContainer.Content = null;
                if (dialog._isPlayAtDetail)
                {
                                //dialog.PlayerHost.SendMessage(PlayerMessage.Stop, null);
                }
                if (dialog.IsCanceled)
                {
                    tcs.TrySetResult(null);
                }
            };

            container.ShowDialog(dialog);

            return tcs.Task;
        }

        private void _closeBt_Click(object sender, RoutedEventArgs e)
        {
            ControlCommands.CloseDialog.Execute(null, null);
        }

        private bool _isPlayAtDetail = false;
        private void _playBt_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentMediaItem?.Entity?.Path))
            {
                this._isPlayAtDetail = true;
                this.PlayerHost.SendMessage(PlayerMessage.OpenFileName, _currentMediaItem.Entity.Path);
            }
        }
    }
}
