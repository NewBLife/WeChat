using System;
using System.Collections.Generic;

namespace Aurore.Framework.Core.Ioc
{
    /// <summary>
    /// 服务定位器，IoC 容器。
    /// </summary>
    public interface IServiceLocator : IServiceProvider
    {
        /// <summary>
        /// 获取指定类型的服务。
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        TService GetService<TService>();

        /// <summary>
        /// 按名称获取指定类型的服务。
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="name">服务名。</param>
        /// <returns></returns>
        TService GetService<TService>(string name);

        /// <summary>
        /// 按名称获取指定类型的服务。
        /// </summary>
        /// <param name="serviceType">服务的类型。</param>
        /// <param name="name">服务名。</param>
        /// <returns></returns>
        object GetService(Type serviceType, string name);

        /// <summary>
        /// 获取指定类型的所有服务。
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        IEnumerable<TService> GetAllServices<TService>();

        /// <summary>
        /// 获取指定类型的所有服务。
        /// </summary>
        /// <param name="serviceType">服务的类型。</param>
        /// <returns></returns>
        IEnumerable<object> GetAllServices(Type serviceType);

        /// <summary>
        /// 注册指定类型的服务。
        /// </summary>
        /// <typeparam name="TService">服务的类型。</typeparam>
        /// <typeparam name="TInstance">服务实例的具体类型。</typeparam>
        /// <returns></returns>
        IServiceLocator Register<TService, TInstance>() where TInstance: TService;

        /// <summary>
        /// 注册指定类型的服务。
        /// </summary>
        /// <typeparam name="TService">服务的类型。</typeparam>
        /// <typeparam name="TInstance">服务实例的具体类型。</typeparam>
        /// <param name="name">服务名。</param>
        /// <returns></returns>
        IServiceLocator Register<TService, TInstance>(string name) where TInstance : TService;

        /// <summary>
        /// 注册指定类型的服务。
        /// </summary>
        /// <param name="serviceType">服务的类型。</param>
        /// <param name="instanceType">服务实例的具体类型。</param>
        /// <returns></returns>
        IServiceLocator Register(Type serviceType, Type instanceType);

        /// <summary>
        /// 注册指定类型的服务。
        /// </summary>
        /// <param name="serviceType">服务的类型。</param>
        /// <param name="instanceType">服务实例的具体类型。</param>
        /// <param name="name">服务名。</param>
        /// <returns></returns>
        IServiceLocator Register(Type serviceType, Type instanceType, string name);

        /// <summary>
        /// 注册指定类型的服务。
        /// </summary>
        /// <typeparam name="TService">服务的类型。</typeparam>
        /// <param name="instance">服务的实例。</param>
        /// <returns></returns>
        IServiceLocator Register<TService>(TService instance);

        /// <summary>
        /// 注册指定类型的服务。
        /// </summary>
        /// <typeparam name="TService">服务的类型。</typeparam>
        /// <param name="instance">服务的实例。</param>
        /// <param name="name">服务名。</param>
        /// <returns></returns>
        IServiceLocator Register<TService>(TService instance, string name);

        /// <summary>
        /// 注册指定类型的服务。
        /// </summary>
        /// <param name="serviceType">服务的类型。</param>
        /// <param name="instance">服务的实例。</param>
        /// <returns></returns>
        IServiceLocator Register(Type serviceType, object instance);

        /// <summary>
        /// 注册指定类型的服务。
        /// </summary>
        /// <param name="serviceType">服务的类型。</param>
        /// <param name="instance">服务的实例。</param>
        /// <param name="name">服务名。</param>
        /// <returns></returns>
        IServiceLocator Register(Type serviceType, object instance, string name);
    }
}
