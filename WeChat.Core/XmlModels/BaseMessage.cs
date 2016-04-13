using System;
using System.Xml.Serialization;
using WeChat.Core.Extensions;
using WeChat.Core.XmlModels.Response;

namespace WeChat.Core.XmlModels
{
    /// <summary>
    /// 基础消息内容
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    [XmlInclude(typeof(ResponseNews))]
    [XmlInclude(typeof(ResponseImage))]
    [XmlInclude(typeof(ResponseMusic))]
    [XmlInclude(typeof(ResponseText))]
    [XmlInclude(typeof(ResponseVideo))]
    [XmlInclude(typeof(ResponseVoice))]
    public class BaseMessage
    {
        /// <summary>
        /// 初始化一些内容，如创建时间为整形，
        /// </summary>
        public BaseMessage()
        {
            this.CreateTime = DateTime.Now.DateTimeToInt();
        }

        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; set; }
       
        public virtual string ToXml()
        {
            this.CreateTime = DateTime.Now.DateTimeToInt();//重新更新
            return XmlHelper.Instance().Serializer(this);
        }

    }
}