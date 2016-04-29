using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hubs1.Infrastructure.BootStrap
{
    /// <summary>
    /// 目录程序集供应器。
    /// </summary>
    public class DirectoryAssemblyLoader : IAssemblyLoader
    {
        public DirectoryAssemblyLoader()
            : this(null, false)
        { }

        public DirectoryAssemblyLoader(string path)
            : this(path, false)
        {
        }

        public DirectoryAssemblyLoader(bool recursive)
            : this(null, recursive)
        {
        }

        public DirectoryAssemblyLoader(string path, bool recursive)
        {
            this.RootDirectory = path;
            this.Recursive = recursive;
        }

        /// <summary>
        /// 根目录。
        /// </summary>
        public string RootDirectory { get; private set; }

        /// <summary>
        /// 是否遍历子目录。
        /// </summary>
        public bool Recursive { get; private set; }

        /// <summary>
        /// 载入所有可用的程序集到当前应用程序域中。
        /// </summary>
        public void Load()
        {
            var root = this.RootDirectory;
            if (string.IsNullOrEmpty(root))
                root = GetRootDirectory();

            var files = Directory.GetFiles(root, "*.dll", 
                Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                var name = AssemblyName.GetAssemblyName(file);
                AppDomain.CurrentDomain.Load(name);
            }
        }

        /// <summary>
        /// 获取默认根目录。
        /// </summary>
        /// <returns></returns>
        static string GetRootDirectory()
        {
            if (System.Web.Hosting.HostingEnvironment.IsHosted)
                return System.Web.HttpRuntime.BinDirectory;
            else
                return AppDomain.CurrentDomain.BaseDirectory;
        }

    }
}
