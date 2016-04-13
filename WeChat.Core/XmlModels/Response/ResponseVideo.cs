using WeChat.Core.Constants;
using WeChat.Core.Entitys;

namespace WeChat.Core.XmlModels.Response
{
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
    }
}