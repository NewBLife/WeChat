using System;
using System.Xml.Serialization;
using Aurore.Framework.Utils;
using WeChat.Core.Constants;
using WeChat.Core.Entitys;

namespace WeChat.Core.XmlModels.Response
{
    [XmlRoot(ElementName = "xml")]
    public class ResponseMusic : BaseMessage
    {
        public ResponseMusic()
        {
            this.MsgType = ResponseType.Music.ToString().ToLower();
        }

        public ResponseMusic(BaseMessage info) : this()
        {
            this.FromUserName = info.ToUserName;
            this.ToUserName = info.FromUserName;
        }

        public MusicEntity Music { get; set; }

        public override string ToXml()
        {
            this.CreateTime = DateTime.Now.DateTimeToInt();//重新更新
            return this.SerializerToXml();
        }
    }
}