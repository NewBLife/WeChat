using System;
using System.Xml.Serialization;
using WeChat.Core.Constants;

namespace WeChat.Core.XmlModels.Response
{
    /// <summary>
    /// 回复文本消息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    public class ResponseText : BaseMessage
    {
        public ResponseText()
        {
            this.MsgType = Constants.MsgType.Text.ToString().ToLower();
        }

        public ResponseText(BaseMessage info) : this()
        {
            this.FromUserName = info.ToUserName;
            this.ToUserName = info.FromUserName;
        }

        /// <summary>
        /// 内容
        /// </summary>        
        public string Content { get; set; }
    }
}