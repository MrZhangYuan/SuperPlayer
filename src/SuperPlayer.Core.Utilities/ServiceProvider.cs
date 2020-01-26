using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperPlayer.Core.Service;
using IServiceProvider = SuperPlayer.Core.Service.IServiceProvider;

namespace SuperPlayer.Core.Utilities
{
    public class ServiceProvider : IServiceProvider
    {
        private static readonly Lazy<ServiceProvider> instance = new Lazy<ServiceProvider>(() => new ServiceProvider());
        private readonly Dictionary<Type, object> serviceProviders = new Dictionary<Type, object>();

        public static IServiceProvider Instance
        {
            get
            {
                return (IServiceProvider)ServiceProvider.instance.Value;
            }
        }

        private ServiceProvider()
        {

        }

        public T GetService<T>()
        {
            if (serviceProviders.TryGetValue(typeof(T), out object provider))
            {
                return (T)provider;
            }
            throw new Exception("未注册服务：" + typeof(T));
        }

        public void RegisterService<T>(T instance)
        {
            lock (this.serviceProviders)
            {
                serviceProviders.Add(typeof(T), instance);
            }
        }

        public bool HasService<T>()
        {
            return serviceProviders.TryGetValue(typeof(T), out object instance);
        }
    }

}
