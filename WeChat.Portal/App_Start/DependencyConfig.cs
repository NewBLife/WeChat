using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Aurore.Framework.Core;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using WeChat.Portal.Controllers;
using WeChat.Utils;

namespace WeChat.Portal
{
    public class DependencyConfig
    {
        public static void RegisterDependency()
        {
            var builder = new ContainerBuilder();
            var Configuration = GlobalConfiguration.Configuration;
            RegisterService(builder); //注入
            var allAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterControllers(allAssembly); //注入所有Controller
            builder.RegisterApiControllers(allAssembly);
            var container = builder.Build();
            IocManager.Initialization(new AutofacManager(container));

            Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

        private static void RegisterService(ContainerBuilder builder)
        {
            builder.Register(c => new Log4NetHelper())
                .As<ILogger>();
            //// Scan an assembly for components
            //builder.RegisterAssemblyTypes(myAssembly)
            //       .Where(t => t.Name.EndsWith("Repository"))
            //       .AsImplementedInterfaces();
        }
    }
}