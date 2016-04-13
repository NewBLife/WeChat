using System.Collections.Generic;
using System.Xml.Serialization;
using WeChat.Core.Constants;
using WeChat.Core.Entitys;

namespace WeChat.Core.XmlModels.Response
{
    [XmlRoot(ElementName = "xml")]
    public class ResponseImage : BaseMessage
    {
        public ResponseImage()
        {
            this.MsgType = Constants.MsgType.Image.ToString().ToLower();
        }
        public ResponseImage(BaseMessage info) : this()
        {
            this.FromUserName = info.ToUserName;
            this.ToUserName = info.FromUserName;
        }
        public ImageEntity Image { get; set; }

    }
}