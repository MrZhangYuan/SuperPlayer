using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCore.Commands;

namespace SuperPlayer.Core
{
        public enum SystemCommand
        {
                OpenMenu,
                Minimized,
                Normal,
                Maximized,
                Close,
                FullScreen,
                FullScreenCancel,
                MediaCenter,
                Player,

                /// <summary>
                /// 推荐
                /// </summary>
                Recommend,
                /// <summary>
                /// 收藏
                /// </summary>
                Collection,
                /// <summary>
                /// 专题
                /// </summary>
                SpecialTopic,
                /// <summary>
                /// 影库
                /// </summary>
                VideoLibrary,
                Magnetic,
                ShowItemDetail,
                ItemPlay,
                Last
        }
        public class SystemCommandManager : UICommandManager<SystemCommand>
        {
                public static SystemCommandManager Instance
                {
                        get;
                }

                static SystemCommandManager()
                {
                        Instance = new SystemCommandManager();
                }
                private SystemCommandManager()
                        : base((int)SystemCommand.Last)
                {

                }

                protected override int ConverterKeyToIndex(SystemCommand key)
                {
                        return (int)key;
                }

                protected override SystemCommand ConverterKeyFromName(string name)
                {
                        Enum.TryParse<SystemCommand>(name, out SystemCommand cmd);

                        return cmd;
                }
        }
}
