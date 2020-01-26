using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperPlayer.Core
{
        public interface IPlayerHost : IDisposable
        {
                FrameworkElement HostElement
                {
                        get;
                }
                FrameworkElement DetailHostElement
                {
                        get;
                }
                FrameworkElement PreviewHostElement
                {
                        get;
                }

                double HostWidth
                {
                        get;
                }

                double HostHeight
                {
                        get;
                }
                void ShowAtHost();
                void ShowAtDetail();
                void ShowAtPreview();
                void Hide();

                event Action<int, object> Message;

                void SendMessage(PlayerMessage msgid, object param);
                object GetMessage(PlayerMessage msgid, object param);

                void SendConfig(ConfigID cfgid, object param);
                object GetConfig(ConfigID cfgid, object param);
        }
}
