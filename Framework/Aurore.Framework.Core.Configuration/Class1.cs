using System;
using System.Configuration;
using System.IO;

namespace Aurore.Framework.Core.Configuration
{
    public class AuroreConfiguration
    {
        private static System.Configuration.Configuration _config = null;

        #region GetSection
        public ConfigurationSection GetSection(string key)
        {
            if (_config != null)
            {
                if (_config.Sections[key] != null)
                {
                    return _config.Sections[key];
                }
                else
                {
                    throw new Exception("找不到指定的Key。");
                }
            }
            else
            {
                throw new Exception("找不到Dll相应的Config文件。");
            }
        }

        public static T GetSectionValue<T>(T defaultValue, string key, string configFileName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, configFileName + ".config");
            if (File.Exists(filePath))
            {
                var fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = filePath;
                _config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            }

            var value = _config.Sections[key];
            if (_config != null)
            {
                if (value != null)
                {
                    try
                    {
                        defaultValue = (T)Convert.ChangeType(value, typeof(T));
                    }
                    catch
                    {
                        throw new Exception("找不到指定的Key。");
                    }
                }
            }
            else
            {
                throw new Exception("找不到Dll相应的Config文件。");
            }

            return defaultValue;
        }
        #endregion

        #region GetAppSetting
        public string GetAppSetting(string key)
        {
            if (_config != null)
            {
                if (_config.AppSettings.Settings[key] != null)
                {
                    return _config.AppSettings.Settings[key].ToString();
                }
                else
                {
                    throw new Exception("找不到指定的Key。");
                }
            }
            else
            {
                throw new Exception("找不到Dll相应的Config文件。");
            }
        }

        public static T GetAppSettingValue<T>(T defaultValue, string key)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    defaultValue = (T)Convert.ChangeType(value, typeof(T));
                }
                catch
                {
                }
            }
            return defaultValue;
        }

        public T GetAppSettingValue<T>(T defaultValue, string key, string configFileName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, configFileName + ".config");
            if (File.Exists(filePath))
            {
                var fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = filePath;
                _config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            }

            string value = _config.AppSettings.Settings[key].Value;
            if (_config != null)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    try
                    {
                        defaultValue = (T)Convert.ChangeType(value, typeof(T));
                    }
                    catch
                    {
                        throw new Exception("找不到指定的Key。");
                    }
                }
            }
            else
            {
                throw new Exception("找不到Dll相应的Config文件。");
            }

            return defaultValue;
        }

        #endregion

        #region GetConnString
        //private static object userObject = new object();
        //private AuroreConfiguration(string configFileName)
        //{
        //    var filePath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, configFileName + ".config");
        //    if (File.Exists(filePath))
        //    {
        //        var fileMap = new ExeConfigurationFileMap();
        //        fileMap.ExeConfigFilename = filePath;
        //        _config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        //    }
        //}

        //private static AuroreConfiguration _instance = null;
        //public static AuroreConfiguration GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        lock (userObject)
        //        {
        //            if (_instance == null)
        //                _instance = new AuroreConfiguration();
        //        }
        //    }

        //    return _instance;
        //}

        public string GetConnString(string key)
        {
            if (_config != null)
            {
                if (_config.ConnectionStrings.ConnectionStrings[key] != null)
                {
                    return _config.ConnectionStrings.ConnectionStrings[key].ToString();
                }
                else
                {
                    throw new Exception("找不到指定的Key。");
                }
            }
            else
            {
                throw new Exception("找不到Dll相应的Config文件。");
            }

        }
        #endregion
    }
}
