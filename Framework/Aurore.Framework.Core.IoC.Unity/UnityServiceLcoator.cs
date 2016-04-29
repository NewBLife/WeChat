using System;
using System.Collections.Generic;
using Aurore.Framework.Core.Asserts;
using Aurore.Framework.Core.Configuration;
using Aurore.Framework.Core.Ioc;
//using Aurore.Framework.Core.Ioc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Aurore.Framework.Core.IoC.Unity
{
    public class UnityServiceLcoator : IServiceLocator
    {
        readonly IUnityContainer container;

        public UnityServiceLcoator()
        {
            //Hubs1Configuration configuration = Hubs1Configuration.GetInstance("Hubs1.Infrastructure.IoC.Unity");
            //UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection("unity");

            UnityConfigurationSection section = new UnityConfigurationSection();
            section = AuroreConfiguration.GetSectionValue(section, "unity", "Hubs1.Infrastructure.IoC.Unity");

            container = new UnityContainer();
            section.Configure(container);
            container = new UnityContainer();
        }

        public TService GetService<TService>()
        {
            return default(TService);
            //return container.Resolve<TService>();
        }

        public TService GetService<TService>(string name)
        {
            name.NotNullOrWhiteSpace(nameof(name));

            return container.Resolve<TService>(name);
        }

        public IEnumerable<TService> GetAllServices<TService>()
        {
            return container.ResolveAll<TService>();
        }

        public IEnumerable<object> GetAllServices(Type serviceType)
        {
            serviceType.NotNull(nameof(serviceType));

            return container.ResolveAll(serviceType);
        }

        public object GetService(Type serviceType, string name)
        {
            serviceType.NotNull(nameof(serviceType));
            name.NotNullOrWhiteSpace(nameof(name));

            return container.Resolve(serviceType, name);
        }

        public object GetService(Type serviceType)
        {
            serviceType.NotNull(nameof(serviceType));

            return container.Resolve(serviceType);
        }

        public IServiceLocator Register<TService, TInstance>()
            where TInstance : TService
        {
            container.RegisterType<TService, TInstance>();
            return this;
        }

        public IServiceLocator Register<TService, TInstance>(string name)
            where TInstance : TService
        {
            name.NotNullOrWhiteSpace(nameof(name));

            container.RegisterType<TService, TInstance>(name);
            return this;
        }

        public IServiceLocator Register(Type serviceType, Type instanceType)
        {
            serviceType.NotNull(nameof(serviceType));
            instanceType.NotNull(nameof(instanceType));

            container.RegisterType(serviceType, instanceType);
            return this;
        }

        public IServiceLocator Register(Type serviceType, Type instanceType, string name)
        {
            serviceType.NotNull(nameof(serviceType));
            instanceType.NotNull(nameof(instanceType));
            name.NotNullOrWhiteSpace(nameof(name));

            container.RegisterType(serviceType, instanceType, name);
            return this;
        }

        public IServiceLocator Register<TService>(TService instance)
        {
            instance.NotNull(nameof(instance));

            container.RegisterInstance<TService>(instance);
            return this;
        }

        public IServiceLocator Register<TService>(TService instance, string name)
        {
            instance.NotNull(nameof(instance));
            name.NotNullOrWhiteSpace(nameof(name));

            container.RegisterInstance<TService>(name, instance);
            return this;
        }

        public IServiceLocator Register(Type serviceType, object instance)
        {
            serviceType.NotNull(nameof(serviceType));
            instance.NotNull(nameof(instance));

            container.RegisterInstance(serviceType, instance);
            return this;
        }

        public IServiceLocator Register(Type serviceType, object instance, string name)
        {
            serviceType.NotNull(nameof(serviceType));
            instance.NotNull(nameof(instance));
            name.NotNullOrWhiteSpace(nameof(name));

            container.RegisterInstance(serviceType, name, instance);
            return this;
        }
    }
}
