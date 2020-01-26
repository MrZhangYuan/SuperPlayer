using SuperPlayer.Core.Utilities;
using SuperPlayer.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using UltimateCore.Dispatcher;
using UltimateCore.Services;
using System.Collections.Concurrent;

namespace SuperPlayer.Services
{
        public enum BitmapSize
        {
                Small,
                Nomal,
                Large
        }
        public class FileThumbnailBitmapCreaterParameter
        {
                public string Path
                {
                        get; set;
                }

                public BitmapSize BitmapSize
                {
                        get;
                        set;
                }
        }
        public class FileThumbnailBitmapCreater : IBitmapCreater
        {
                public readonly Lazy<IDispatcherService> _dispatcherService = new Lazy<IDispatcherService>(() => ServiceProvider.Instance.GetService<IDispatcherService>());
                public IDispatcherService DispatcherService
                {
                        get => this._dispatcherService.Value;
                }


                public string CacheDirectoryPath { get; } = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), "SuperPlayer", "Caches");

                private class BitmapCacheItem
                {
                        public ImageSource[] Bitmaps
                        {
                                get;
                        }
                        public BitmapCacheItem()
                        {
                                this.Bitmaps = new ImageSource[3];
                        }
                }

                private readonly ConcurrentDictionary<string, BitmapCacheItem> _caches = new ConcurrentDictionary<string, BitmapCacheItem>();

                public ImageSource CreateBitmap(object param)
                {
                        return this.CreateBitmap(param, true);
                }

                private readonly object _syncObj = new object();
                public ImageSource CreateBitmap(object param, bool iscache)
                {
                        FileThumbnailBitmapCreaterParameter parameter = param as FileThumbnailBitmapCreaterParameter;

                        if (!Directory.Exists(this.CacheDirectoryPath))
                        {
                                Directory.CreateDirectory(this.CacheDirectoryPath);
                        }
                        ImageSource bitmapImage = null;

                        if (!string.IsNullOrEmpty(parameter?.Path?.ToUpper()))
                        {
                                string filekey = FileIdentityHelper.GenerateFileIdentityRoughly(parameter.Path);

                                if (!this._caches.TryGetValue(filekey, out BitmapCacheItem bitmapCacheItem))
                                {
                                        bitmapCacheItem = new BitmapCacheItem();
                                        this._caches.TryAdd(filekey, bitmapCacheItem);
                                }

                                int index = 0;
                                int width = 0, height = 0;

                                switch (parameter.BitmapSize)
                                {
                                        case BitmapSize.Small:
                                                width = 100;
                                                height = 134;
                                                index = 0;
                                                break;

                                        case BitmapSize.Nomal:
                                                width = 300;
                                                height = 400;
                                                index = 1;
                                                break;

                                        case BitmapSize.Large:
                                                width = 900;
                                                height = 1200;
                                                index = 2;
                                                break;
                                }

                                if (bitmapCacheItem.Bitmaps[index] == null)
                                {
                                        string name = index + "_" + filekey + ".png";

                                        string filepath = Path.Combine(this.CacheDirectoryPath, name);

                                        if (File.Exists(filepath))
                                        {
                                                this.DispatcherService.InvokeAtUI(() =>
                                                {
                                                        bitmapImage = new BitmapImage(new Uri(filepath));

                                                }, System.Windows.Threading.DispatcherPriority.Background);
                                        }
                                        else
                                        {
                                                IntPtr hbitmap = IntPtr.Zero;

                                                lock (this._syncObj)
                                                {
                                                        hbitmap = WindowsThumbnailProvider.GetHBitmap(parameter.Path, width, height, ThumbnailOptions.None);

                                                        using (Bitmap bitmap = WindowsThumbnailProvider.GetBitmapFromHBitmap(hbitmap))
                                                        {
                                                                bitmap.Save(filepath, ImageFormat.Png);
                                                        }
                                                }

                                                if (hbitmap != IntPtr.Zero)
                                                {
                                                        this.DispatcherService.InvokeAtUI(() =>
                                                        {
                                                                try
                                                                {
                                                                        bitmapImage = Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                                                                }
                                                                finally
                                                                {
                                                                        WindowsThumbnailProvider.DeleteObject(hbitmap);
                                                                }

                                                        }, System.Windows.Threading.DispatcherPriority.Background);
                                                }
                                        }

                                        bitmapCacheItem.Bitmaps[index] = (ImageSource)bitmapImage;
                                }
                                else
                                {
                                        bitmapImage = bitmapCacheItem.Bitmaps[index];
                                }
                        }

                        return bitmapImage;
                }
        }
}
