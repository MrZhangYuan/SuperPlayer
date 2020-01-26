using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO
{
        public static class DirectoryEx
        {
                public static IEnumerable<FileInfo> EnumerateAllFiles(this DirectoryInfo directory)
                {
                        if (directory != null)
                        {
                                foreach (FileSystemInfo item in directory.EnumerateFileSystemInfos())
                                {
                                        DirectoryInfo directoryInfo = item as DirectoryInfo;

                                        if (directoryInfo != null)
                                        {
                                                foreach (var fileinfo in directoryInfo.EnumerateAllFiles())
                                                {
                                                        yield return fileinfo;
                                                }
                                        }
                                        else if (item is FileInfo)
                                        {
                                                yield return item as FileInfo;
                                        }
                                }
                        }
                }

                public static IEnumerable<FileInfo> EnumerateAllFiles(this DirectoryInfo directory, string searchPattern)
                {
                        if (directory != null)
                        {
                                foreach (var item in directory.EnumerateFiles(searchPattern))
                                {
                                        yield return item;
                                }

                                foreach (var item in directory.EnumerateDirectories())
                                {
                                        foreach (var fileinfo in item.EnumerateAllFiles(searchPattern))
                                        {
                                                yield return fileinfo;
                                        }
                                }
                        }
                }

                public static void EnumFiles(this DirectoryInfo directory, Func<FileInfo, bool> action)
                {
                        if (directory != null)
                        {
                                foreach (FileSystemInfo item in directory.EnumerateFileSystemInfos())
                                {
                                        DirectoryInfo directoryInfo = item as DirectoryInfo;

                                        if (directoryInfo != null)
                                        {
                                                directoryInfo.EnumFiles(action);
                                        }
                                        else
                                        {
                                                bool? continu = action?.Invoke(item as FileInfo);
                                                if (continu != true)
                                                {
                                                        break;
                                                }
                                        }
                                }
                        }
                }
                public static void EnumFiles(this DirectoryInfo directory, Action<FileInfo> action, CancellationToken cancellation)
                {
                        if (directory != null)
                        {
                                if (cancellation.IsCancellationRequested)
                                {
                                        return;
                                }

                                foreach (FileSystemInfo item in directory.EnumerateFileSystemInfos())
                                {
                                        if (cancellation.IsCancellationRequested)
                                        {
                                                return;
                                        }

                                        DirectoryInfo directoryInfo = item as DirectoryInfo;

                                        if (directoryInfo != null)
                                        {
                                                directoryInfo.EnumFiles(action, cancellation);
                                        }
                                        else
                                        {
                                                action?.Invoke(item as FileInfo);
                                        }
                                }
                        }
                }
                public static void EnumFiles(this DirectoryInfo directory, ICollection<FileInfo> filecollect)
                {
                        directory.EnumFiles(_p =>
                        {
                                filecollect?.Add(_p);
                                return true;
                        });
                }
                public static void EnumFiles(this DirectoryInfo directory, ICollection<FileInfo> filecollect, CancellationToken cancellation)
                {
                        directory.EnumFiles(_p =>
                        {
                                filecollect?.Add(_p);

                        }, cancellation);
                }
        }
}
