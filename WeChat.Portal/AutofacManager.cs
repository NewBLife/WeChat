using System.Configuration;
using Aurore.Framework.Core;
using Autofac;

namespace WeChat.Portal
{
    public class AutofacManager:IIocManager
    {
        private readonly IContainer _container;
        public AutofacManager(IContainer container)
        {
            this._container = container;
        }


        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}