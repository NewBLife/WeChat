using System.Configuration;
using Aurore.Framework.Core;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace WeChat.Portal
{
    public class UnityManager: IIocManager
    {
        private readonly IUnityContainer _container;
        public UnityManager(IUnityContainer container)
        {
            this._container = container;
        }


        public void FromConfig()
        {
            UnityConfigurationSection configuration = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            configuration.Configure(_container);
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public void RegisterInstance<T>(T instance)
        {
            _container.RegisterInstance(instance);
        }


        public void RegisterType<TFrom, TTo>() where TTo:TFrom
        {
            _container.RegisterType<TFrom, TTo>();
        }
    }
}