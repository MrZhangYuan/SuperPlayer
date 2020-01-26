using SuperPlayer.Business;
using SuperPlayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPlayer.Helper
{
        public static class PlayerHostHelper
        {
                public static FileType CurrentFileType(this IPlayerHost playerhost)
                {
                        string currentfile = playerhost.CurrentURL();
                        int va = currentfile.LastIndexOf('.');
                        if (va >= 0)
                        {
                                string ex = currentfile.Substring(va);

                                FileType type = DataUtil.CheckFileType(ex);

                                return type;
                        }

                        return FileType.UnKnow;
                }

                public static string CurrentURL(this IPlayerHost playerhost)
                {
                        return playerhost.GetConfig(ConfigID.CurrentURL, null) + "";
                }
        }
}
