using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SuperPlayer.Core.Utilities.System
{
        public class PathHelper
        {
                const int DRIVE_UNKNOWN = 0;
                const int DRIVE_ABSENT = 1;
                const int DRIVE_REMOVABLE = 2;
                const int DRIVE_FIXED = 3;
                const int DRIVE_REMOTE = 4;
                const int DRIVE_CDROM = 5;
                const int DRIVE_RAMDISK = 6;
                const int ERROR_BAD_DEVICE = 1200;
                const int ERROR_CONNECTION_UNAVAIL = 1201;
                const int ERROR_EXTENDED_ERROR = 1208;
                const int ERROR_MORE_DATA = 234;
                const int ERROR_NOT_SUPPORTED = 50;
                const int ERROR_NO_NET_OR_BAD_PATH = 1203;
                const int ERROR_NO_NETWORK = 1222;
                const int ERROR_NOT_CONNECTED = 2250;
                const int NO_ERROR = 0;

                [DllImport("mpr.dll", CharSet = CharSet.Unicode, SetLastError = true)]
                public static extern int WNetGetConnection([MarshalAs(UnmanagedType.LPTStr)] string localName, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder remoteName, ref int length);

                public static string GetUNCPath(string originalPath)
                {
                        StringBuilder sb = new StringBuilder(512);
                        int size = sb.Capacity;
                        if (originalPath.Length > 2 && originalPath[1] == ':')
                        {
                                char c = originalPath[0];
                                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                                {
                                        int error = WNetGetConnection(originalPath.Substring(0, 2), sb, ref size);

                                        if (error == 0
                                                 || sb.Length > 0)
                                        {
                                                DirectoryInfo dir = new DirectoryInfo(originalPath);
                                                string path = Path.GetFullPath(originalPath).Substring(Path.GetPathRoot(originalPath).Length);
                                                return Path.Combine(sb.ToString().TrimEnd(), path);
                                        }
                                }
                        }
                        return originalPath;
                }
        }
}