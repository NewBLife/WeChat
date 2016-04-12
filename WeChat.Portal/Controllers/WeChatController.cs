using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public string Get(string signature, string timestamp, string nonce, string echostr)
        {

            var token = AppSetting.Token;
            var encodingAESKey = AppSetting.EncodingAESKey;
            var value = Helper.CheckSignature(token, encodingAESKey, signature, timestamp, nonce, echostr);
            return value;
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

    }
}
