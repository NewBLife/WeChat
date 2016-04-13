using System;
using System.Xml.Serialization;
using WeChat.Core.Constants;
using WeChat.Core.Entitys;
using WeChat.Core.Extensions;

namespace WeChat.Core.XmlModels.Response
{
    [XmlRoot(ElementName = "xml")]
    public class ResponseVoice:BaseMessage
    {
        public ResponseVoice()
        {
            this.MsgType = Constants.MsgType.Voice.ToString().ToLower();
        }

        public ResponseVoice(BaseMessage info) : this()
        {
            this.FromUserName = info.ToUserName;
            this.ToUserName = info.FromUserName;
        }

        public VoiceEntity Voice { get; set; }

        public override string ToXml()
        {
            this.CreateTime = DateTime.Now.DateTimeToInt();//重新更新
            return XmlHelper.Instance().Serializer(this);
        }
    }
}