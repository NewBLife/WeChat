using System;
using System.Xml;
using System.Xml.Serialization;
using WeChat.Core.Constants;
using WeChat.Core.Extensions;

namespace WeChat.Core.XmlModels.Response
{
    /// <summary>
    /// 回复文本消息
    /// </summary>
    [XmlRoot(ElementName = "xml", Namespace = "")]
    [Serializable]
    public class ResponseText : BaseMessage
    {
        public ResponseText()
        {
            MsgType = ResponseType.Text.ToString().ToLower();
        }

        public ResponseText(BaseMessage info) : this()
        {
            this.FromUserName = info.ToUserName;
            this.ToUserName = info.FromUserName;
        }
        [XmlElement("Content")]
        public XmlCDataSection XmlContent
        {
            get { return new XmlDataDocument().CreateCDataSection(Content); }
            set { Content = value.Value; }
        }


        /// <summary>
        /// 内容
        /// </summary>    
        [XmlIgnore]
        public string Content { get; set; }
        public override string ToXml()
        {
            this.CreateTime = DateTime.Now.DateTimeToInt();//重新更新
            return this.Serializer();
        }
    }
}