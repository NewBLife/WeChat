using System;

namespace Aurore.Framework.Utils
{
    public static class DateTimeExtension
    {
        public static long DateTimeToInt(this DateTime source)
        {
            return source.Ticks;
        }
    }
}