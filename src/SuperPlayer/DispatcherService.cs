using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using UltimateCore.Dispatcher;

namespace SuperPlayer
{
        public class DispatcherService : IDispatcherService
        {
                public void BeginInvokeAtUI(Action action, DispatcherPriority priority)
                {
                        App.Current?.Dispatcher?.BeginInvoke(action, priority);
                }

                public void BeginInvokeAtUI(Action action)
                {
                        App.Current?.Dispatcher?.BeginInvoke(action);
                }

                public void InvokeAtUI(Action action, DispatcherPriority priority)
                {
                        App.Current?.Dispatcher?.Invoke(action, priority);
                }

                public void InvokeAtUI(Action action)
                {
                        App.Current?.Dispatcher?.Invoke(action);
                }
        }
}
