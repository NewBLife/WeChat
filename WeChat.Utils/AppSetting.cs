using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.Utils
{
    public class AppSetting
    {
        private const string _TokenKey = "Token";
        private const string _AppIdKey = "AppId";
        private const string _AppSecretKey = "AppSecret";
        private const string _EncodingAESKey = "EncodingAESKey";

        #region Private Methods

        public static string GetValue(string Key)
        {
            string Value = ConfigurationManager.AppSettings[Key];
            if (!string.IsNullOrEmpty(Value))
            {
                return Value;
            }
            return string.Empty;
        }

        public static string GetString(string Key, string DefaultValue = "")
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                return Setting;
            }
            return DefaultValue;
        }

        public static bool GetBool(string Key, bool DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                switch (Setting.ToLower())
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

        public static int GetInt(string Key, int DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                int i;
                if (int.TryParse(Setting, out i))
                {
                    return i;
                }
            }
            return DefaultValue;
        }

        public static double GetDouble(string Key, double DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                double d;
                if (double.TryParse(Setting, out d))
                {
                    return d;
                }
            }
            return DefaultValue;
        }

        public static byte GetByte(string Key, byte DefaultValue)
        {
            string Setting = GetValue(Key);
            if (!string.IsNullOrEmpty(Setting))
            {
                byte b;
                if (byte.TryParse(Setting, out b))
                {
                    return b;
                }
            }

            return DefaultValue;
        }

        public static string ConnenctionString(string Key)
        {
            if (ConfigurationManager.ConnectionStrings[Key] == null)
            {
                return null;
            }
            return ConfigurationManager.ConnectionStrings[Key].ConnectionString;
        }

        #endregion

        #region Public Properties

        public static string AppId
        {
            get { return GetString(_AppIdKey, ""); }
        }

        public static string AppSecret
        {
            get { return GetString(_AppSecretKey, ""); }
        }
        public static string Token
        {
            get { return GetString(_TokenKey, ""); }
        }

        public static string EncodingAESKey
        {
            get { return GetString(_EncodingAESKey, ""); }
        }

        #endregion

    }
}
