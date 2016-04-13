using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using WeChat.Core;
using WeChat.Core.XmlModels;
using WeChat.Core.XmlModels.Response;
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
        public HttpResponseMessage Post()
        {
            string postString = string.Empty;
            using (Stream stream = HttpContext.Current.Request.InputStream)
            {
                Byte[] postBytes = new Byte[stream.Length];
                stream.Read(postBytes, 0, (Int32)stream.Length);
                postString = Encoding.UTF8.GetString(postBytes);
            }

            if (postString == string.Empty)


                postString = @"<xml>
                                <ToUserName><![CDATA[gh_1769d357444d]]></ToUserName>
                                <FromUserName><![CDATA[opKrYwas6Lx4_qRK9s9-NHLV-izo]]></FromUserName>
                                <CreateTime>1460532091</CreateTime>
                                <MsgType><![CDATA[text]]></MsgType>
                                <Content><![CDATA[12]]></Content>
                                <MsgId>6272937566006716052</MsgId>
                                <Encrypt><![CDATA[xbbVQuLzMNOg8hqmnKcgvBdYt+Qd5B9fe41X/yXADjr3Ss2lklvOhOsKHXgPSz3oc8BBVc+qp7897DybO3k34r2c+nNO6QF1u9sH9pi1puOCyXotSni3rL2MsdH4uamNp0ghxeYb+LNJCFrGPEJadlAt6jqFLVpqknFHoUOA64AsYQJPA0D0htMmohz9Pj+JyN20nHu2IxhyNQjTrOMSNV6tF/n7SWzh5J6tD+oiH0pPpQSm62J/Gf57fbMUBu0tW62Z7aNM8sf3viD9ISiAB95y/fdH9p+9v2taUnDrPPwYJyu0NYlLwZUJQUc8qAZHBu29ZChN/aODUxrASSipWuJNjwT2NhmOWDAjRi99f41fykQyJUbIIYQSxY/DanKjTIGyz7RllN2ex78lW60WSku1hfruoWxvKhCzI+Vd/8U=]]></Encrypt>
                            </xml>";

            BaseMessage response;
            if (!string.IsNullOrEmpty(postString))
            {
                response= Execute(postString);
            }
            else response= new ResponseText() { Content = "请求异常" };
            //var abc = response.ToXml();
            //return response;

            HttpResponseMessage responseMessage =
               new HttpResponseMessage { Content = new StringContent(response.ToXml(), Encoding.GetEncoding("UTF-8"), "application/xml") };
            return responseMessage;
        }

        private BaseMessage Execute(string postStr)
        {
            Log4NetHelper.WriteLog(postStr);
            WeixinApiDispatch dispatch = new WeixinApiDispatch();
            BaseMessage responseContent = dispatch.Execute(postStr);
            return responseContent;
        }

    }
}
