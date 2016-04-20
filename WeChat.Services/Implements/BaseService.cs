using Aurore.Framework.Core.Caching;
using System;
using Aurore.Framework.Core.Exceptions;
using Aurore.Framework.Utils;
using Aurore.Framework.Web.Core.Caching;
using Aurore.Framework.Web.Utils.HttpUtility;
using WeChat.Data.Constants;
using WeChat.Data.Entitys;
using WeChat.Utils;
using WeChat.Utils.Constants;

namespace WeChat.Services.Implements
{
    public class BaseService
    {

        public virtual void RequestCallBack(string returnText)
        {
            //可能发生错误
            var errorResult = returnText.DeserializeJson<WxJsonResult>();
            if (errorResult.errcode == (int) ReturnCode.请求成功)
            {
                return;
            }
            else if (errorResult.errcode == (int) ReturnCode.不合法的凭证类型)
            {
                GetToken();
            }
            var msg = $"微信Post请求发生错误！错误代码：{errorResult.errcode}，说明：{errorResult.errmsg}";
            //发生错误
            throw new AuroreException(100000, msg);
        }

        protected T GetJson<T>(string url)
        {
            return Get.GetJson<T>(url, RequestCallBack);
        }
        protected T PostJson<T>(string url)
        {
            return Post.PostGetJson<T>(url, RequestCallBack);
        }
        protected static ICacheManager CacheManager;
        public BaseService(ICacheManager cacheManager)
        {
            CacheManager = cacheManager;
        }

        private void GetToken()
        {
            const string key = CacheKey.AccessToken;
            var url = RequestUrl.GetToken(AppSetting.AppId, AppSetting.AppSecret);
            var obj = GetJson<AccessTokenEntity>(url);
            var token = obj.access_token;
            CacheManager.Set(key, token, DateTime.Now.AddSeconds(obj.expires_in), TimeSpan.Zero);
        }

        protected string Token
        {
            get
            {
                const string key = CacheKey.AccessToken;
                if (!CacheManager.IsSet(key))
                    GetToken();
                return CacheManager.Get(key).ToString();

            }
        }


    }
}