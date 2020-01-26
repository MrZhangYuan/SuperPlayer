using SuperPlayer.Core.Utilities.System;
using System;
using System.IO;
using System.Linq;

namespace SuperPlayer.Business.Generates
{
        public sealed class FileItemProducer<T> : ItemProducer<FileInfo, T>
        {
                public FileItemProducer(Func<FileInfo, T> itemselector, Func<FileInfo, bool> filter)
                        : base(itemselector, filter)
                {

                }

                protected override void InitializationCore(object param)
                {
                        string dirpath = param + "";
                        if (!Directory.Exists(dirpath))
                        {
                                try
                                {
                                        dirpath = PathHelper.GetUNCPath(dirpath);

                                        if (!Directory.Exists(dirpath))
                                        {
                                                return;
                                        }
                                }
                                catch (Exception)
                                {
                                        return;
                                }
                        }

                        this.ItemEnumerator = new DirectoryInfo(dirpath)
                                       .EnumerateAllFiles()?
                                       .Where(this.ItemFilter)
                                       .Select(this.ItemSelector)
                                       .GetEnumerator();
                }
        }
}
