using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml;
using Aurore.Framework.Core;
using Aurore.Framework.Utils;
using Aurore.Framework.Web.Mvc;
using WeChat.Core;
using WeChat.Core.XmlModels;
using WeChat.Services.Interfaces;
using WeChat.Utils;

namespace WeChat.Portal.Controllers
{
    public class WeChatController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IWeChatService _chatService;

        public WeChatController(ILogger logger, IWeChatService chatService)
        {
            _logger = logger;
            _chatService = chatService;
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
            //var request = new RequesEntity {signature = signature,timestamp = timestamp,nonce =nonce,echostr = echostr};
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Current.Request.InputStream);
            var document = WeChatXmlHelper.Execute(xmlDoc,null);
            _logger.WriteLog("request:\r\n"+document.ConvertToString());
            BaseMessage response= _chatService.Execute(document);
            _logger.WriteLog("response：\r\n" + response.ToXml());
            return response.XmlResponse();
        }

    }
}
