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
            if (errorResult.errcode != (int)ReturnCode.请求成功)
            {
                var msg = $"微信Post请求发生错误！错误代码：{errorResult.errcode}，说明：{errorResult.errmsg}";
                //发生错误
                throw new AuroreException(100000,msg);
            }
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

        protected string Token => CacheManager.Get(CacheKey.AccessToken, GetToken, DateTime.Now.AddSeconds(7200));

        private string GetToken()
        {
            var url = RequestUrl.GetToken(AppSetting.AppId, AppSetting.AppSecret);
            var token =GetJson<AccessTokenEntity>(url).access_token;
            return token;
        }


    }
}