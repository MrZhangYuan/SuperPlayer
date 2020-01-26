using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPlayer.Business
{
        public static class DataUtil
        {
                public static HashSet<FileExtension> VideoFileExtensions { get; } = new HashSet<FileExtension>
                {
                        //Windows 媒体
                        new FileExtension(".ASF", FileType.Video,"WINDOWS"),
                        new FileExtension(".AVI", FileType.Video,"WINDOWS"),
                        new FileExtension(".WM", FileType.Video,"WINDOWS"),
                        new FileExtension(".WMP", FileType.Video,"WINDOWS"),
                        new FileExtension(".WMV", FileType.Video,"WINDOWS"),

                        //Real 媒体
                        new FileExtension(".RAM", FileType.Video,"Real"),
                        new FileExtension(".RM", FileType.Video,"Real"),
                        new FileExtension(".RMVB", FileType.Video,"Real"),
                        new FileExtension(".RP", FileType.Video,"Real"),
                        new FileExtension(".RPM", FileType.Video,"Real"),
                        new FileExtension(".RT", FileType.Video,"Real"),
                        new FileExtension(".SMIL", FileType.Video,"Real"),
                        new FileExtension(".SCM", FileType.Video,"Real"),

                        //MPEG1/2 媒体
                        new FileExtension(".DAT", FileType.Video,"MPEG1/2"),
                        new FileExtension(".M1V", FileType.Video,"MPEG1/2"),
                        new FileExtension(".M2V", FileType.Video,"MPEG1/2"),
                        new FileExtension(".M2P", FileType.Video,"MPEG1/2"),
                        new FileExtension(".M2TS", FileType.Video,"MPEG1/2"),
                        new FileExtension(".MP2V", FileType.Video,"MPEG1/2"),
                        new FileExtension(".MPE", FileType.Video,"MPEG1/2"),
                        new FileExtension(".MPEG", FileType.Video,"MPEG1/2"),
                        new FileExtension(".MPEG1", FileType.Video,"MPEG1/2"),
                        new FileExtension(".MPEG2", FileType.Video,"MPEG1/2"),
                        new FileExtension(".MPG", FileType.Video,"MPEG1/2"),
                        new FileExtension(".MPV2", FileType.Video,"MPEG1/2"),
                        new FileExtension(".PSS", FileType.Video,"MPEG1/2"),
                        new FileExtension(".PVA", FileType.Video,"MPEG1/2"),
                        new FileExtension(".TP", FileType.Video,"MPEG1/2"),
                        new FileExtension(".TPR", FileType.Video,"MPEG1/2"),
                        new FileExtension(".TS", FileType.Video,"MPEG1/2"),

                        //MPEG4 媒体
                        new FileExtension(".M4B", FileType.Video,"MPEG4"),
                        new FileExtension(".M4R", FileType.Video,"MPEG4"),
                        new FileExtension(".M4P", FileType.Video,"MPEG4"),
                        new FileExtension(".M4V", FileType.Video,"MPEG4"),
                        new FileExtension(".MP4", FileType.Video,"MPEG4"),
                        new FileExtension(".MPEG4", FileType.Video,"MPEG4"),

                        //3GPP 媒体
                        new FileExtension(".3G2", FileType.Video,"3GPP"),
                        new FileExtension(".3GP", FileType.Video,"3GPP"),
                        new FileExtension(".3GP2", FileType.Video,"3GPP"),
                        new FileExtension(".3GPP", FileType.Video,"3GPP"),

                        //APPLE 媒体
                        new FileExtension(".MOV", FileType.Video,"APPLE"),
                        new FileExtension(".QT", FileType.Video,"APPLE"),

                        //FLASH 媒体
                        new FileExtension(".FLV", FileType.Video,"FLASH"),
                        new FileExtension(".F4V", FileType.Video,"FLASH"),
                        new FileExtension(".SWF", FileType.Video,"FLASH"),
                        new FileExtension(".HLV", FileType.Video,"FLASH"),

                        //CD/DVD 媒体
                        new FileExtension(".IFO", FileType.Video,"CD/DVD"),
                        new FileExtension(".VOB", FileType.Video,"CD/DVD"),

                        //其他
                        new FileExtension(".AMV", FileType.Video,"OTHER"),
                        new FileExtension(".CSF", FileType.Video,"OTHER"),
                        new FileExtension(".DIVX", FileType.Video,"OTHER"),
                        new FileExtension(".EVO", FileType.Video,"OTHER"),
                        new FileExtension(".MKV", FileType.Video,"OTHER"),

                        new FileExtension(".MOD", FileType.Video,"OTHER"),
                        new FileExtension(".PMP", FileType.Video,"OTHER"),
                        new FileExtension(".VP6", FileType.Video,"OTHER"),
                        new FileExtension(".BIK", FileType.Video,"OTHER"),
                        new FileExtension(".MTS", FileType.Video,"OTHER"),

                        new FileExtension(".XLMV", FileType.Video,"OTHER"),
                        new FileExtension(".OGM", FileType.Video,"OTHER"),
                        new FileExtension(".OGV", FileType.Video,"OTHER"),
                        new FileExtension(".OGX", FileType.Video,"OTHER")
                 };

                public static HashSet<FileExtension> AudioFileExtensions { get; } = new HashSet<FileExtension>
                {
                        new FileExtension(".AAC", FileType.Audio,""),
                        new FileExtension(".AC3", FileType.Audio,""),
                        new FileExtension(".ACC", FileType.Audio,""),
                        new FileExtension(".AIFF", FileType.Audio,""),
                        new FileExtension(".AMR", FileType.Audio,""),
                        new FileExtension(".APE", FileType.Audio,""),
                        new FileExtension(".AU", FileType.Audio,""),

                        new FileExtension(".CDA", FileType.Audio,""),

                        new FileExtension(".DTS", FileType.Audio,""),

                        new FileExtension(".FLAC", FileType.Audio,""),

                        new FileExtension(".M1A", FileType.Audio,""),
                        new FileExtension(".M2A", FileType.Audio,""),
                        new FileExtension(".M4A", FileType.Audio,""),
                        new FileExtension(".MKA", FileType.Audio,""),
                        new FileExtension(".MP2", FileType.Audio,""),
                        new FileExtension(".MP3", FileType.Audio,""),
                        new FileExtension(".MPA", FileType.Audio,""),
                        new FileExtension(".MPC", FileType.Audio,""),
                        new FileExtension(".MID", FileType.Audio,""),
                        new FileExtension(".MIDI", FileType.Audio,""),

                        new FileExtension(".RA", FileType.Audio,""),

                        new FileExtension(".TTA", FileType.Audio,""),

                        new FileExtension(".WAV", FileType.Audio,""),
                        new FileExtension(".WMA", FileType.Audio,""),
                        new FileExtension(".WV", FileType.Audio,""),

                        new FileExtension(".OGG", FileType.Audio,""),
                        new FileExtension(".OGA", FileType.Audio,"")
                };

                public static HashSet<FileExtension> ImageFileExtensions { get; } = new HashSet<FileExtension>
                {
                        new FileExtension(".BMP", FileType.Image,""),
                        new FileExtension(".GIF", FileType.Image,""),
                        new FileExtension(".ICO", FileType.Image,""),
                        new FileExtension(".JPG", FileType.Image,""),
                        new FileExtension(".PNG", FileType.Image,""),
                        new FileExtension(".WDP", FileType.Image,""),
                        new FileExtension(".TIFF", FileType.Image,"")
                };

                public static HashSet<FileExtension> SubTitleFileExtensions { get; } = new HashSet<FileExtension>
                {
                        new FileExtension(".SRT", FileType.SubTitle,""),
                        new FileExtension(".ASS", FileType.SubTitle,""),
                        new FileExtension(".SSA", FileType.SubTitle,""),
                        new FileExtension(".SMI", FileType.SubTitle,""),
                        new FileExtension(".IDX", FileType.SubTitle,""),
                        new FileExtension(".SUB", FileType.SubTitle,""),
                        new FileExtension(".SUP", FileType.SubTitle,""),
                        new FileExtension(".PSB", FileType.SubTitle,""),
                        new FileExtension(".USF", FileType.SubTitle,""),
                        new FileExtension(".SSF", FileType.SubTitle,"")
                };

                public static FileType CheckFileType(string extension)
                {
                        if (!string.IsNullOrEmpty(extension))
                        {
                                FileExtension file = new FileExtension(extension.ToUpper(), FileType.UnKnow, "");

                                if (VideoFileExtensions.Contains(file))
                                {
                                        return FileType.Video;
                                }
                                else if (SubTitleFileExtensions.Contains(file))
                                {
                                        return FileType.SubTitle;
                                }
                                else if (AudioFileExtensions.Contains(file))
                                {
                                        return FileType.Audio;
                                }
                                else if (ImageFileExtensions.Contains(file))
                                {
                                        return FileType.Image;
                                }
                        }

                        return FileType.UnKnow;
                }
        }
}
