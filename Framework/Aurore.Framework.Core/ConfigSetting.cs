using System.Configuration;

namespace Aurore.Framework.Core
{
    public class ConfigSetting
    {
        #region Private Methods

        public static string GetValue(string key)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
            return string.Empty;
        }

        public static string GetString(string key, string defaultValue = "")
        {
            string setting = GetValue(key);
            if (!string.IsNullOrEmpty(setting))
            {
                return setting;
            }
            return defaultValue;
        }

        public static bool GetBool(string Key, bool DefaultValue)
        {
            string setting = GetValue(Key);
            if (!string.IsNullOrEmpty(setting))
            {
                switch (setting.ToLower())
                {
                    case "false":
                    case "0":
                    case "n":
                        return false;
                    case "true":
                    case "1":
                    case "y":
                        return true;
                }
            }
            return DefaultValue;
        }

        public static int GetInt(string key, int defaultValue)
        {
            string setting = GetValue(key);
            if (!string.IsNullOrEmpty(setting))
            {
                int i;
                if (int.TryParse(setting, out i))
                {
                    return i;
                }
            }
            return defaultValue;
        }

        public static double GetDouble(string key, double defaultValue)
        {
            string setting = GetValue(key);
            if (!string.IsNullOrEmpty(setting))
            {
                double d;
                if (double.TryParse(setting, out d))
                {
                    return d;
                }
            }
            return defaultValue;
        }

        public static byte GetByte(string key, byte defaultValue)
        {
            string setting = GetValue(key);
            if (!string.IsNullOrEmpty(setting))
            {
                byte b;
                if (byte.TryParse(setting, out b))
                {
                    return b;
                }
            }

            return defaultValue;
        }

        public static string ConnenctionString(string key)
        {
            if (ConfigurationManager.ConnectionStrings[key] == null)
            {
                return null;
            }
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        #endregion
    }
}
