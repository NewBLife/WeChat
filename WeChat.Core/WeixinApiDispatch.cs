using System;
using System.Xml;
using Aurore.Framework.Utils;
using WeChat.Core.Constants;
using WeChat.Core.XmlModels;
using WeChat.Core.XmlModels.Request;

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
                    response = _weixinAction.HandleText(document.XmlDeserializer<RequestText>());
                    break;
                case MsgType.Image:
                    response = _weixinAction.HandleImage(document.XmlDeserializer<RequestImage>());
                    break;
                case MsgType.Voice:
                    response = _weixinAction.HandleVoice(document.XmlDeserializer<RequestVoice>());
                    break;
                case MsgType.Video:
                    response = _weixinAction.HandleVideo(document.XmlDeserializer<RequestVideo>());
                    break;
                case MsgType.ShortVideo:
                    response = _weixinAction.HandleShortVideo(document.XmlDeserializer<RequestVideo>());
                    break;
                case MsgType.Location:
                    response = _weixinAction.HandleLocation(document.XmlDeserializer<RequestLocation>());
                    break;
                case MsgType.Link:
                    response = _weixinAction.HandleLink(document.XmlDeserializer<RequestLink>());
                    break;
                case MsgType.Event:
                    response = _weixinAction.HandleEventClick(document.XmlDeserializer<RequestEvent>());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return response;
        }
    }
}