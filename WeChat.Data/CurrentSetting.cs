using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurore.Framework.Core;

namespace WeChat.Data
{
    public static class CurrentSetting
    {
        public static string DbConnection = ConfigSetting.ConnenctionString("WeChatDb");
    }
}
