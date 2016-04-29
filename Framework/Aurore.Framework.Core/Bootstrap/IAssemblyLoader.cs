using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubs1.Infrastructure
{
    /// <summary>
    /// 程序集供应器。
    /// </summary>
    public interface IAssemblyLoader
    {
        /// <summary>
        /// 载程序集到当前应用程序域中。
        /// </summary>
        void Load();
    }
}
