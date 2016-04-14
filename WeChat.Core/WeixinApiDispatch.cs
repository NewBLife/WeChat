using System;
using System.Xml;
using WeChat.Core.Constants;
using WeChat.Core.XmlModels;
using WeChat.Core.XmlModels.Request;
using WeChat.Utils;

namespace WeChat.Core
{
    public class WeixinApiDispatch
    {
        private readonly IWeixinAction _weixinAction;

        public WeixinApiDispatch(IWeixinAction weixinAction)
        {
            _weixinAction = weixinAction;
        }
        public WeixinApiDispatch()
        {
          _weixinAction = new WeixinAction();
        }
        public BaseMessage Execute(XmlDocument document)
        {
            
            BaseMessage response;
            MsgType msgType = document.GetMsgType();
            switch (msgType)
            {
                case MsgType.Text:
                    response = _weixinAction.HandleText(document.Deserializer<RequestText>());
                    break;
                case MsgType.Image:
                    response = _weixinAction.HandleImage(document.Deserializer<RequestImage>());
                    break;
                case MsgType.Voice:
                    response = _weixinAction.HandleVoice(document.Deserializer<RequestVoice>());
                    break;
                case MsgType.Video:
                    response = _weixinAction.HandleVideo(document.Deserializer<RequestVideo>());
                    break;
                case MsgType.ShortVideo:
                    response = _weixinAction.HandleShortVideo(document.Deserializer<RequestVideo>());
                    break;
                case MsgType.Location:
                    response = _weixinAction.HandleLocation(document.Deserializer<RequestLocation>());
                    break;
                case MsgType.Link:
                    response = _weixinAction.HandleLink(document.Deserializer<RequestLink>());
                    break;
                case MsgType.Event:
                    response = _weixinAction.HandleEventClick(document.Deserializer<RequestEvent>());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return response;
        }
    }
}