using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Aurore.Framework.Core.Asserts;
using Aurore.Framework.Core.ExtensionMethods.Reflection;

namespace Aurore.Framework.Core.Bootstrap
{
    /// <summary>
    /// <see cref="IBootstrapService"/>的默认实现。
    /// </summary>
    internal sealed class DefaultBootstrapService : IBootstrapService
    {
        bool started = false;
        readonly List<IBootstrapPlugin> plugins = new List<IBootstrapPlugin>();
        readonly List<Predicate<Assembly>> filters = new List<Predicate<Assembly>>();

        void CheckNotStarted()
        {
            if (started)
                throw new InvalidOperationException("引导程序已启动。");
        }

        public IBootstrapService AddFilter(Predicate<Assembly> filter)
        {
            filter.NotNull(nameof(filter));
            this.CheckNotStarted();
            filters.Add(filter);

            return this;
        }

        public IBootstrapService AddFilters(params Predicate<Assembly>[] filters)
        {
            filters.NotNull(nameof(filters));
            this.CheckNotStarted();
            this.filters.AddRange(filters);

            return this;
        }

        public IBootstrapService AddPlugin(IBootstrapPlugin plugin)
        {
            plugin.NotNull(nameof(plugin));
            this.CheckNotStarted();
            plugins.Add(plugin);

            return this;
        }

        public IBootstrapService AddPlugins(params IBootstrapPlugin[] plugins)
        {
            plugins.NotNull(nameof(plugins));
            this.CheckNotStarted();
            this.plugins.AddRange(plugins);

            return this;
        }

        public void Start()
        {
            this.CheckNotStarted();

            var assemblies = this.GetBootstrapAssemblies();

            foreach (var assembly in assemblies)
            {
                this.StartModules(assembly);
            }

            foreach (var assembly in assemblies)
            {
                this.StartListeners(assembly);
            }
        }

        IEnumerable<Assembly> GetBootstrapAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.IsDefined(typeof(BootstrapAssemblyAttribute), false)
                    || filters.Any(predicate => predicate(a)))
                .ToArray();
        }

        void StartModules(Assembly assembly)
        {
            foreach (var plugin in plugins)
            {
                plugin.Start(this, assembly);
            }
        }

        void StartListeners(Assembly assembly)
        {
            var listeners = assembly.CreateDescendentInstances<IBootstrapListener>();
            foreach (var listener in listeners)
            {
                listener.Start(this);
            }
        }
    }
}
