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
                            <CreateTime>1460546052</CreateTime>
                            <MsgType><![CDATA[voice]]></MsgType>
                            <MediaId><![CDATA[hYjZ7-XjECCUsowZt8osfmAg_cWkXSE5llTbnU2-pEZuFSKy_1GbC8haobE-9xaR]]></MediaId>
                            <Format><![CDATA[amr]]></Format>
                            <MsgId>6272997528045139950</MsgId>
                            <Recognition><![CDATA[]]></Recognition>
                            <Encrypt><![CDATA[kYqL02v78FZ9wIusOCz7xprS52pRKReMFlJSD2NNuYOWjwGk/K22W9HvAOwQ6tWLzTgH3s3kREmWnuctyKcyFFzXESggbFTIvU1FMcus9KRfNWYfp6raHk9v15kLb7llQ5MdLyoJTDz1SdUOrmjY7fF59kqLHXWoLIlY2OlzFqf1wwy0dFsy8DO2Kis3c+pFCy1GjjE0T3B+LbcKTL4N6Sx6PFokyMiPqGvx39bi6YVBYl9Ya2xe8fZTHDTGh5zmRxAq+ZXQUecRIX8mALQyWxvegtAuByBuTFeHWdp1L2kw4bNd4f6sspJcGesZGSbPSwmDFa6wOPR+Q7kBP3CVAAAkQezCBvul8+WRoHiXwmOJd92moDpDYgqyc+1uiQgZCfaGaWJTLnWdb2BiqijmyIJqIItVK74q6l/ZP6WeCZzXp5+owqCV86WmctBQztTvwYdLE4ATQ5jghLUrfCzYWAcyyvKM21X+iCAa80xiwTug6Ad0E75IiDgrmgdqplGRrpR21+MrrQ3SxTuRTRe7mN6P8D3bb9LuCaB0R3qVDb9ujVxhcnChna38Uz3f4WQxUjrpKSpBpPTDokAq1jTmVcA42AT3LC1MzrGBtZrCXWsG+lMP9rWKgGYeu5PLN/w0]]></Encrypt>
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
