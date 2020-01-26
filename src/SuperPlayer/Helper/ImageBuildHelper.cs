using SuperPlayer.Core.Utilities;
using SuperPlayer.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using UltimateCore.Dispatcher;
using UltimateCore.Services;

namespace SuperPlayer.Helper
{
        public static class ImageBuildHelper
        {
                public static readonly Lazy<IBitmapCreater> _bitmapCreater = new Lazy<IBitmapCreater>(() => ServiceProvider.Instance.GetService<IBitmapCreater>());
                public static IBitmapCreater BitmapCreater
                {
                        get => _bitmapCreater.Value;
                }

                public static readonly Lazy<IDispatcherService> _dispatcherService = new Lazy<IDispatcherService>(() => ServiceProvider.Instance.GetService<IDispatcherService>());
                public static IDispatcherService DispatcherService
                {
                        get => _dispatcherService.Value;
                }

                public static object GetSourceURL(DependencyObject obj)
                {
                        return obj.GetValue(SourceURLProperty);
                }
                public static void SetSourceURL(DependencyObject obj, object value)
                {
                        obj.SetValue(SourceURLProperty, value);
                }

                public static readonly DependencyProperty SourceURLProperty = DependencyProperty.RegisterAttached("SourceURL", typeof(object), typeof(ImageBuildHelper), new PropertyMetadata(null, SourceURLPropertyChangedCallback));

                private static void SourceURLPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
                {
                        ImageBuildHelper.EnBuildQueue(d as Image);
                }

                public static string GetSourceFlag(DependencyObject obj)
                {
                        return (string)obj.GetValue(SourceFlagProperty);
                }
                public static void SetSourceFlag(DependencyObject obj, string value)
                {
                        obj.SetValue(SourceFlagProperty, value);
                }
                public static readonly DependencyProperty SourceFlagProperty = DependencyProperty.RegisterAttached("SourceFlag", typeof(string), typeof(ImageBuildHelper), new PropertyMetadata(string.Empty, SourceFlagPropertyChangedCallback));

                private static void SourceFlagPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
                {
                        ImageBuildHelper.EnBuildQueue(d as Image);
                }


                public static bool GetIsLoading(DependencyObject obj)
                {
                        return (bool)obj.GetValue(IsLoadingProperty);
                }
                private static void SetIsLoading(DependencyObject obj, bool value)
                {
                        obj.SetValue(IsLoadingProperty, value);
                }
                private static readonly DependencyProperty IsLoadingProperty = DependencyProperty.RegisterAttached("IsLoading", typeof(bool), typeof(ImageBuildHelper), new PropertyMetadata(false));



                public static string GetBuildPriority(DependencyObject obj)
                {
                        return (string)obj.GetValue(BuildPriorityProperty);
                }
                public static void SetBuildPriority(DependencyObject obj, string value)
                {
                        obj.SetValue(BuildPriorityProperty, value);
                }
                public static readonly DependencyProperty BuildPriorityProperty = DependencyProperty.RegisterAttached("BuildPriority", typeof(string), typeof(ImageBuildHelper), new PropertyMetadata(string.Empty, BuildPriorityPropertyChangedCallback));

                private static void BuildPriorityPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
                {

                }


                private class _CacheItem
                {
                        public WeakReference<Image> Image
                        {
                                get; set;
                        }
                        public FileThumbnailBitmapCreaterParameter Param
                        {
                                get; set;
                        }
                }

                readonly static BlockingCollection<_CacheItem> _caches = new BlockingCollection<_CacheItem>();
                readonly static BlockingCollection<_CacheItem> _highPriorityCaches = new BlockingCollection<_CacheItem>();

                private static void EnBuildQueue(Image image)
                {
                        if (image != null)
                        {
                                string sourceurl = image.GetValue(ImageBuildHelper.SourceURLProperty) + "";
                                string sourceflag = image.GetValue(ImageBuildHelper.SourceFlagProperty) + "";
                                if (!string.IsNullOrEmpty(sourceurl)
                                        && !string.IsNullOrEmpty(sourceflag))
                                {
                                        BitmapSize bitmapSize = BitmapSize.Small;
                                        switch (sourceflag.ToUpper())
                                        {
                                                case "SMALL":
                                                case "0":
                                                        bitmapSize = BitmapSize.Small;
                                                        break;

                                                case "NOMAL":
                                                case "1":
                                                        bitmapSize = BitmapSize.Nomal;
                                                        break;

                                                case "LARGE":
                                                case "2":
                                                        bitmapSize = BitmapSize.Large;
                                                        break;
                                        }


                                        string priority = image.GetValue(ImageBuildHelper.BuildPriorityProperty) + "";
                                        image.SetValue(ImageBuildHelper.IsLoadingProperty, true);

                                        if (!string.IsNullOrEmpty(priority))
                                        {
                                                _highPriorityCaches.Add(new _CacheItem
                                                {
                                                        Image = new WeakReference<Image>(image),
                                                        Param = new FileThumbnailBitmapCreaterParameter
                                                        {
                                                                BitmapSize = bitmapSize,
                                                                Path = sourceurl
                                                        }
                                                });
                                                ImageBuildHelper.StartHighPriorityBuild();
                                        }
                                        else
                                        {
                                                _caches.Add(new _CacheItem
                                                {
                                                        Image = new WeakReference<Image>(image),
                                                        Param = new FileThumbnailBitmapCreaterParameter
                                                        {
                                                                BitmapSize = bitmapSize,
                                                                Path = sourceurl
                                                        }
                                                });
                                                ImageBuildHelper.StartBuild();
                                        }

                                }
                        }
                }

                private static bool _highFlag = false;
                private static void StartHighPriorityBuild()
                {
                        if (_highFlag)
                        {
                                return;
                        }
                        _highFlag = true;

                        Task.Factory.StartNew(() =>
                        {
                                while (_highPriorityCaches.TryTake(out _CacheItem item, TimeSpan.FromSeconds(10)))
                                {
                                        if (item.Image.TryGetTarget(out Image image))
                                        {
                                                ImageSource imageSource = null;
                                                try
                                                {
                                                        imageSource = BitmapCreater.CreateBitmap(item.Param);
                                                }
                                                catch (Exception)
                                                {
                                                }

                                                DispatcherService.BeginInvokeAtUI(() =>
                                                {
                                                        image.Source = imageSource;

                                                        image.SetValue(ImageBuildHelper.IsLoadingProperty, false);

                                                }, DispatcherPriority.Input);
                                        }
                                }

                                _highFlag = false;
                        });
                }

                private static bool _flag = false;
                private static int _taskCount = 0;
                private static void StartBuild()
                {
                        if (_flag)
                        {
                                return;
                        }
                        _flag = true;

                        //_taskCount = Environment.ProcessorCount;
                        _taskCount = Math.Max(2, Environment.ProcessorCount / 2);
                        //_taskCount = 2;
                        for (int i = 0; i < _taskCount; i++)
                        {
                                //Thread thread = new Thread(() =>
                                //{
                                //        while (_caches.TryTake(out _CacheItem item, TimeSpan.FromSeconds(10)))
                                //        {
                                //                if (item.Image.TryGetTarget(out Image image))
                                //                {
                                //                        ImageSource imageSource = null;
                                //                        try
                                //                        {
                                //                                imageSource = BitmapCreater.CreateBitmap(item.Param);
                                //                        }
                                //                        catch (Exception)
                                //                        {
                                //                        }

                                //                        DispatcherService.BeginInvokeAtUI(() =>
                                //                        {
                                //                                image.Source = imageSource;

                                //                                image.SetValue(ImageBuildHelper.IsLoadingProperty, false);

                                //                        }, DispatcherPriority.Background);
                                //                }
                                //        }

                                //        TaskDispose();
                                //})
                                //{
                                //        Priority = ThreadPriority.BelowNormal,
                                //        IsBackground = true
                                //};

                                //thread.Start();

                                Task.Factory.StartNew(() =>
                                {
                                        while (_caches.TryTake(out _CacheItem item, TimeSpan.FromSeconds(10)))
                                        {
                                                if (item.Image.TryGetTarget(out Image image))
                                                {
                                                        ImageSource imageSource = null;
                                                        try
                                                        {
                                                                imageSource = BitmapCreater.CreateBitmap(item.Param);
                                                        }
                                                        catch (Exception)
                                                        {
                                                        }

                                                        DispatcherService.BeginInvokeAtUI(() =>
                                                        {
                                                                image.Source = imageSource;
                                                            image.Stretch = Stretch.Uniform;

                                                                image.SetValue(ImageBuildHelper.IsLoadingProperty, false);

                                                        }, DispatcherPriority.Input);
                                                }
                                        }

                                        TaskDispose();
                                }, TaskCreationOptions.LongRunning);
                        }
                }

                //static class _BuildTaskManager
                //{
                //        private static int _taskCount = 0;

                //        public static IDisposable StartTask()
                //        {
                //                return new _TaskScope();
                //        }

                //        private class _TaskScope : IDisposable
                //        {
                //                public _TaskScope()
                //                {
                //                        Interlocked.Increment(ref _BuildTaskManager._taskCount);
                //                }

                //                public void Dispose()
                //                {
                //                        Interlocked.Decrement(ref _BuildTaskManager._taskCount);
                //                }
                //        }
                //}

                private static void TaskDispose()
                {
                        if (_taskCount == 0)
                        {
                                return;
                        }

                        Interlocked.Decrement(ref _taskCount);

                        if (_taskCount == 0)
                        {
                                _flag = false;
                        }
                }
        }
}
