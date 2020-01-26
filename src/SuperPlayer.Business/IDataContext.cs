using SuperPlayer.Business.Models;
using SuperPlayer.Core.Utilities;
using SuperPlayer.Models.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using UltimateCore.Dispatcher;

namespace SuperPlayer.Business
{
        public interface IDataContext
        {
                ObservableCollection<MediaDirectoryModel> MediaDirectories
                {
                        get;
                }

                void InitData(object param);

                void LoadMediaItems(MediaDirectoryModel mediaDirectory);

                void AddMediaDirectory(string folderpath);
        }

        public class DataContext : IDataContext
        {
                public readonly Lazy<IDispatcherService> _dispatcherService = new Lazy<IDispatcherService>(() => ServiceProvider.Instance.GetService<IDispatcherService>());
                public IDispatcherService DispatcherService
                {
                        get => this._dispatcherService.Value;
                }

                public ObservableCollection<MediaDirectoryModel> MediaDirectories
                {
                        get;
                        private set;
                }

                public DataContext()
                {
                        this.MediaDirectories = new ObservableCollection<MediaDirectoryModel>();
                }

                public void InitData(object param)
                {
                        this.DispatcherService.BeginInvokeAtUI(new Action(() =>
                        {
                                this.MediaDirectories.Add(new MediaDirectoryModel
                                {
                                        Entity = new MediaDirectory { Path = @"D:\MUSIC\DANCE", IsRecursive = 1 }
                                });
                                this.MediaDirectories.Add(new MediaDirectoryModel
                                {
                                        Entity = new MediaDirectory { Path = @"D:\MUSIC\QMUSIC", IsRecursive = 1 }
                                });

                                this.MediaDirectories.Add(new MediaDirectoryModel
                                {
                                        Entity = new MediaDirectory { Path = @"E:\Media", IsRecursive = 1 }
                                });
                                this.MediaDirectories.Add(new MediaDirectoryModel
                                {
                                        Entity = new MediaDirectory { Path = @"Z:\下载", IsRecursive = 1 }
                                });
                                this.MediaDirectories.Add(new MediaDirectoryModel
                                {
                                        Entity = new MediaDirectory { Path = @"Z:\共享\FILE\VIDEO\720P", IsRecursive = 1 }
                                });
                                this.MediaDirectories.Add(new MediaDirectoryModel
                                {
                                        Entity = new MediaDirectory { Path = @"Z:\共享\FILE\VIDEO", IsRecursive = 1 }
                                });
                                //this.MediaDirectories.Add(new MediaDirectoryModel
                                //{
                                //        Entity = new MediaDirectory { Path = @"E:\迅雷下载", IsRecursive = 1 }
                                //});
                                //this.MediaDirectories.Add(new MediaDirectoryModel
                                //{
                                //        Entity = new MediaDirectory { Path = @"E:\演示短片", IsRecursive = 1 }
                                //});
                                //this.MediaDirectories.Add(new MediaDirectoryModel
                                //{
                                //        Entity = new MediaDirectory { Path = @"D:\KuGou", IsRecursive = 1 }
                                //});
                                //this.MediaDirectories.Add(new MediaDirectoryModel
                                //{
                                //        Entity = new MediaDirectory { Path = @"E:\IMAGE\iPad 自带壁纸", IsRecursive = 1 }
                                //});
                                //this.MediaDirectories.Add(new MediaDirectoryModel
                                //{
                                //        Entity = new MediaDirectory { Path = @"E:\IMAGE\DCIM", IsRecursive = 1 }
                                //});
                        }));
                }

                public void LoadMediaItems(MediaDirectoryModel mediaDirectory)
                {
                        if (!string.IsNullOrEmpty(mediaDirectory?.Entity?.Path))
                        {

                        }
                }

                public void AddMediaDirectory(string folderpath)
                {
                        if (!string.IsNullOrEmpty(folderpath))
                        {
                                this.DispatcherService.BeginInvokeAtUI(() =>
                                {
                                        this.MediaDirectories.Add(new MediaDirectoryModel
                                        {
                                                Entity = new MediaDirectory
                                                {
                                                        Path = folderpath,
                                                        IsRecursive = 1
                                                }
                                        });
                                }, DispatcherPriority.Input);
                        }
                }
        }
}
