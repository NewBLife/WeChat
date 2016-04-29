using Aurore.Framework.Core.Bootstrap;
using Aurore.Framework.Core.Ioc;

namespace Aurore.Framework.Core.IoC.Unity
{
    public static class IBootstrapServiceExtension
    {
        public static IBootstrapService UseUnityContainer(this IBootstrapService bootstrap)
        {
 	        ServiceLocator.Current = new UnityServiceLcoator();
            return bootstrap;
        }
    }
}
