using WeChat.Core.Constants;
using WeChat.Core.Entitys;

namespace WeChat.Core.XmlModels.Response
{
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
    }
}