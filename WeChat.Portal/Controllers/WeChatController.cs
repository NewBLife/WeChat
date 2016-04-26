using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml;
using Aurore.Framework.Core;
using Aurore.Framework.Utils;
using Aurore.Framework.Web.Mvc;
using Aurore.Framework.Web.Mvc.Filters;
using WeChat.Core;
using WeChat.Core.XmlModels;
using WeChat.Services.Interfaces;
using WeChat.Utils;
using AppSetting = WeChat.Utils.AppSetting;

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
        /// GET 验证
        /// </summary>
        /// <param name="request">请求对象</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(RequesEntity request)
        {

            var token = AppSetting.Token;
            var flag = Helper.CheckSignature(token, request.signature, request.timestamp, request.nonce);
            var value = string.Empty;
            if (flag)
            {
                value = request.echostr;
            }
            HttpResponseMessage responseMessage =
               new HttpResponseMessage { Content = new StringContent(value, Encoding.GetEncoding("UTF-8"), "text/plain") };
            return responseMessage;

        }

        [HttpPost]
        public HttpResponseMessage Post(RequesEntity request)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Current.Request.InputStream);
            var document = WeChatXmlHelper.Execute(xmlDoc, request);
            _logger.WriteLog(document.ConvertToString());
            BaseMessage response = _chatService.Execute(document);
            return response.XmlResponse();
            //var responseMessage =
            //   new HttpResponseMessage { Content = new StringContent(response.ToXml(), Encoding.GetEncoding("UTF-8"), "application/xml") };
            //return responseMessage;
        }

    }
}
