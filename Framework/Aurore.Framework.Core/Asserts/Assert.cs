using System.Collections.Generic;
using System.Linq;

namespace Aurore.Framework.Core.Asserts
{
    public static partial class Assert
    {
        public static void Require(bool assertion, string message)
        {
            if (!assertion)
                throw new AssertException(message);
        }

        public static void NotNull(this object that, string name)
        {
            Require(that != null, string.Format("变量 \"{0}\" 为空引用。", name));
        }

        public static void NotNullOrWhiteSpace(this string that, string name)
        {
            Require(!string.IsNullOrWhiteSpace(that), string.Format("字符串 \"{0}\" 为空或空白。", name));
        }

        public static void NotNullOrEmpty(this string that, string name)
        {
            Require(!string.IsNullOrEmpty(that), string.Format("字符串 \"{0}\" 为空。", name));
        }

        public static void NotNullOrEmpty<T>(this IEnumerable<T> that, string name)
        {
            Require(that != null && that.Any(), string.Format("集合 \"{0}\" 为空。", name));
        }
    }
}
