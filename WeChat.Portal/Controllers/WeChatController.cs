using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WeChat.Portal.Filters;
using WeChat.Utils;

namespace WeChat.Portal.Controllers
{
    public class WeChatController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="signature">微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数。</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">随机数</param>
        /// <param name="echostr">随机字符串</param>
        /// <returns></returns>
        [HttpGet]
        [ApiActionFilter]
        public HttpResponseMessage Get(string signature, string timestamp, string nonce, string echostr)
        {

            var token = AppSetting.Token;
            var encodingAesKey = AppSetting.EncodingAESKey;
            var flag = Helper.CheckSignature(token, signature, timestamp, nonce);
            Log4NetHelper.WriteLog("response Validate :" + flag);
            var value = string.Empty;
            if (flag)
            {
                value = echostr;
            }
            HttpResponseMessage responseMessage =
               new HttpResponseMessage { Content = new StringContent(value, Encoding.GetEncoding("UTF-8"), "text/plain") };
            return responseMessage;

        }

        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

    }
}
