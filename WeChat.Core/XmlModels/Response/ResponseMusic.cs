using System.Xml.Serialization;
using WeChat.Core.Constants;
using WeChat.Core.Entitys;

namespace WeChat.Core.XmlModels.Response
{
    [XmlRoot(ElementName = "xml")]
    public class ResponseMusic : BaseMessage
    {
        public ResponseMusic()
        {
            this.MsgType = Constants.MsgType.Music.ToString().ToLower();
        }

        public ResponseMusic(BaseMessage info) : this()
        {
            this.FromUserName = info.ToUserName;
            this.ToUserName = info.FromUserName;
        }

        public MusicEntity Music { get; set; }
    }
}