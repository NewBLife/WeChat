using System;

namespace WeChat.Core.Extensions
{
    public static class DateTimeExtension
    {
        public static long DateTimeToInt(this DateTime source)
        {
            return source.Ticks;
        }
    }
}