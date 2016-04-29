using Aurore.Framework.Core.Ioc;

namespace Aurore.Framework.Core.IoC.Unity
{
    public static class IServiceLocatorExtension
    {
        public static IServiceLocator UseUnityContainer(this IServiceLocator service)
        {
 	        ServiceLocator.Current = new UnityServiceLcoator();
            return ServiceLocator.Current;
        }
    }
}
