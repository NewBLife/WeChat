using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml;
using Aurore.Framework.Core;
using Aurore.Framework.Utils;
using Aurore.Framework.Web.Mvc.Filters;
using WeChat.Core;
using WeChat.Core.XmlModels;
using WeChat.Utils;
using AppSetting = WeChat.Utils.AppSetting;

namespace WeChat.Portal.Controllers
{
    public class WeChatController : ApiController
    {
        private readonly ILogger _logger;

        public WeChatController(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="signature">微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数。</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">随机数</param>
        /// <param name="echostr">随机字符串</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(string signature, string timestamp, string nonce, string echostr)
        {

            var token = AppSetting.Token;
            var flag = Helper.CheckSignature(token, signature, timestamp, nonce);
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
            //string postString;
            //using (Stream stream = HttpContext.Current.Request.InputStream)
            //{
            //    Byte[] postBytes = new Byte[stream.Length];
            //    stream.Read(postBytes, 0, (Int32)stream.Length);
            //    postString = Encoding.UTF8.GetString(postBytes);
            //}
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Current.Request.InputStream);
            var document = WeChatXmlHelper.Execute(xmlDoc);
            _logger.WriteLog(document.ConvertToString());
            BaseMessage response= Execute(document);
            var responseMessage =
               new HttpResponseMessage { Content = new StringContent(response.ToXml(), Encoding.GetEncoding("UTF-8"), "application/xml") };
            return responseMessage;
        }

        private BaseMessage Execute(XmlDocument document)
        {
            WeixinApiDispatch dispatch = new WeixinApiDispatch();
            BaseMessage responseContent = dispatch.Execute(document);
            return responseContent;
        }

    }
}
