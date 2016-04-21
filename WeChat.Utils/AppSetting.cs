using Aurore.Framework.Core;

namespace WeChat.Utils
{
    public class AppSetting: ConfigSetting
    {
        private const string TokenKey = "Token";
        private const string AppIdKey = "AppId";
        private const string AppSecretKey = "AppSecret";
        private const string EncodingAesKeyName = "EncodingAesKey";
        private const string EncryptKey = "Encrypt";

        #region Public Properties

        public static string AppId => GetString(AppIdKey, "");


        public static string AppSecret => GetString(AppSecretKey, "");
        public static string Token => GetString(TokenKey, "");

        public static string EncodingAesKey => GetString(EncodingAesKeyName, "");/// <summary>
        /// 是否加密
        /// </summary>
        public static bool Encrypt => GetBool(EncryptKey, false);

        #endregion

    }
}
