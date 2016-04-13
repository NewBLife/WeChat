using System;
using System.Xml.Serialization;
using WeChat.Core.Constants;
using WeChat.Core.Entitys;
using WeChat.Core.Extensions;

namespace WeChat.Core.XmlModels.Response
{
    [XmlRoot(ElementName = "xml")]
    public class ResponseVideo : BaseMessage
    {
        public ResponseVideo()
        {
            MsgType = Constants.MsgType.Video.ToString().ToLower();
        }

        public ResponseVideo(BaseMessage info) : this()
        {
            this.FromUserName = info.ToUserName;
            this.ToUserName = info.FromUserName;
        }


        public VideoEntity Video { get; set; }

        public override string ToXml()
        {
            this.CreateTime = DateTime.Now.DateTimeToInt();//���¸���
            return XmlHelper.Instance().Serializer(this);
        }
    }
}