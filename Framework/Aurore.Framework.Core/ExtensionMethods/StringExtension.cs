using System;

namespace Aurore.Framework.Core.ExtensionMethods
{
    public static class StringExtension
    {
        public static bool Contains(this string s, string value, StringComparison comparsionType)
        {
            return s.IndexOf(s, comparsionType) >= 0;
        }
    }
}
