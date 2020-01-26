using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPlayer.Core.Service
{
    public interface IServiceProvider
    {
        T GetService<T>();
        void RegisterService<T>(T instance);
        bool HasService<T>();
    }
}
