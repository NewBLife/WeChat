using System;
using Aurore.Framework.Core;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using WeChat.Utils;

namespace WeChat.Portal.App_Start
{
    /// <summary>
    /// Specifies the Unity Configuration for the main Container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity Container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity Container.</summary>
        /// <param name="container">The unity Container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // Container.LoadConfiguration();

            // TODO: Register your types here
            // Container.RegisterType<IProductRepository, ProductRepository>();
            IIocManager iocManager = new UnityManager(container);
            IocManager.Initialization(iocManager);
            container.RegisterInstance(iocManager);
            container.RegisterType<ILogger, Log4NetHelper>();

        }
    }
}
