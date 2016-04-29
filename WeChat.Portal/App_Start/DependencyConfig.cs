using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Aurore.Framework.Core;
using Aurore.Framework.Core.Caching;
using Aurore.Framework.Web.Core.Caching;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using WeChat.Utils;

namespace WeChat.Portal
{
    public class DependencyConfig
    {
        public static void RegisterDependency()
        {
            var builder = new ContainerBuilder();
            var configuration = GlobalConfiguration.Configuration;
            RegisterService(builder); //注入
            var allAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterControllers(allAssembly); //注入所有Controller
            builder.RegisterApiControllers(allAssembly);
            var container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

        private static void RegisterService(ContainerBuilder builder)
        {
            var baseType = typeof(IDependency);
            var assemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();

            var allServices =
                assemblys.SelectMany(m => m.GetTypes()).Where(m => baseType.IsAssignableFrom(m) && m != baseType);
            //var allAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterInstance(new TextLogger()).As<ILogger>();
            builder.RegisterInstance<ICacheManager>(new CacheManager());
            //// Scan an assembly for components
            builder.RegisterAssemblyTypes(assemblys.ToArray())
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}