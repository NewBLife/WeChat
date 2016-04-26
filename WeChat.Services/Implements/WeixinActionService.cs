using WeChat.Core;
using WeChat.Core.Entitys;
using WeChat.Core.XmlModels;
using WeChat.Core.XmlModels.Request;
using WeChat.Core.XmlModels.Response;
using WeChat.Services.Interfaces;

namespace WeChat.Services.Implements
{
    public class WeixinActionService : IWeixinActionService
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

        public BaseMessage HandleVideo(RequestVideo info)
        {
            var msg = "你发送了 Video 【{0}】";
            var response = new ResponseText(info)
            {
                Content = string.Format(msg,info.MediaId)
            };
            return response;
        }

        public BaseMessage HandleShortVideo(RequestVideo info)
        {
            var msg = "你发送了 ShortVideo 【{0}】";
            var response = new ResponseText(info)
            {
                Content = string.Format(msg,info.MediaId)
            };
            return response;
        }

        public BaseMessage HandleLocation(RequestLocation info)
        {
            var msg = "你发送了 Location【{0}】";
            var response = new ResponseText(info)
            {
                Content = string.Format(msg, info.Label)
            }; return response;
        }

        public BaseMessage HandleLink(RequestLink info)
        {
            var msg = "你发送了 Link 【{0}】";
            var response = new ResponseText(info)
            {
                Content = string.Format(msg, info.Title+" "+info.Description+" "+info.Url)
            }; return response;
        }

        public BaseMessage HandleEventClick(RequestEvent info)
        {
            var msg = "你发送了 Event【{0}】";
            var response = new ResponseText(info)
            {
                Content = string.Format(msg, info.Event)
            }; return response;
        }
    }
}