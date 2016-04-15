namespace Aurore.Framework.Core
{
    public interface IIocManager
    {
        void FromConfig();

        T Resolve<T>();

        void RegisterInstance<T>(T instance);


        void RegisterType<TFrom, TTo>() where TTo : TFrom;
    }

    //public static class IocManager
    //{
    //    private static IIocManager _iocManager;
    //    static IocManager()
    //    {
           
    //    }

    //    //public static void Initialization(IIocManager iocManager)
    //    //{
    //    //    _iocManager = iocManager;
    //    //}

    //    //public static T Resolve<T>()
    //    //{
    //    //    return _iocManager.Resolve<T>();
    //    //}
    //}
}