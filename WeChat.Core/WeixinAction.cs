using WeChat.Core.Entitys;
using WeChat.Core.XmlModels;
using WeChat.Core.XmlModels.Request;
using WeChat.Core.XmlModels.Response;

namespace WeChat.Core
{
    public class WeixinAction : IWeixinAction
    {
        public BaseMessage HandleText(RequestText info)
        {
            var msg = "你发送了文本【{0}】";
            var response = new ResponseText(info)
            {
                Content = string.Format(msg, info.Content)
            };
            return response;

        }

        public BaseMessage HandleImage(RequestImage info)
        {
            var response = new ResponseImage(info)
            {
                Image = new ImageEntity() { MediaId = info.MediaId }
            };
            return response;

        }
        public BaseMessage HandleVoice(RequestVoice info)
        {
            var response = new ResponseVoice(info)
            {
                Voice = new VoiceEntity() { MediaId = info.MediaId }
            };
            return response;

        }
        //public BaseMessage HandleEventSubscribe(RequestEventSubscribe info)
        //{
        //    var msg = "你发送了文本【{0}】";
        //    var response = new ResponseText(info)
        //    {
        //        Content = string.Format(msg, info.Content)
        //    };
        //    return response;
        //}

        //public BaseMessage HandleEventClick(RequestEventClick info)
        //{
        //    var msg = "你发送了文本【{0}】";
        //    var response = new ResponseText(info)
        //    {
        //        Content = string.Format(msg, info.Content)
        //    };
        //    return response;
        //}
    }
}