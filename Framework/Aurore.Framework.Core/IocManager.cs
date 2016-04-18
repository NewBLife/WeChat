namespace Aurore.Framework.Core
{
    public interface IIocManager
    {
        T Resolve<T>();
    }

    public static class IocManager
    {
        private static IIocManager _iocManager;
        static IocManager()
        {

        }

        public static void Initialization(IIocManager iocManager)
        {
            _iocManager = iocManager;
        }

        public static T Resolve<T>()
        {
            return _iocManager.Resolve<T>();
        }
    }
}