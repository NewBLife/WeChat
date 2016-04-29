using Hubs1.Infrastructure;
using Hubs1.Infrastructure.BootStrap;

namespace Aurore.Framework.Core.Bootstrap
{
    /// <summary>
    /// <see cref="IBootstrapService"/>扩展。
    /// </summary>
    public static class IBootstrapServiceExtension
    {
        public static IBootstrapService UseAssemblyLoader(this IBootstrapService bootstrap, IAssemblyLoader loader)
        {
            loader.Load();

            return bootstrap;
        }

        public static IBootstrapService UseAssemblyLoader<T>(this IBootstrapService bootstrap)
            where T : IAssemblyLoader, new()
        {
            return bootstrap.UseAssemblyLoader(new T());
        }

        public static IBootstrapService UseDirectoryAssemblyLoader(this IBootstrapService bootstrap)
        {
            return bootstrap.UseAssemblyLoader(new DirectoryAssemblyLoader());
        }

        public static IBootstrapService UseDirectoryAssemblyLoader(this IBootstrapService bootstrap, string path)
        {
            return bootstrap.UseAssemblyLoader(new DirectoryAssemblyLoader(path));
        }
    }
}
