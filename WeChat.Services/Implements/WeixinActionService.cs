using System;
using WeChat.Core;
using WeChat.Core.Constants;
using WeChat.Core.Entitys;
using WeChat.Core.XmlModels;
using WeChat.Core.XmlModels.Request;
using WeChat.Core.XmlModels.Response;
using WeChat.Services.Interfaces;

namespace WeChat.Services.Implements
{
    public class WeixinActionService : IWeixinActionService
    {
        private readonly IEventService _eventService;
        private const string Msg = "我不明白您在做做什么.";
        public WeixinActionService(IEventService eventService)
        {
            _eventService = eventService;
        }

        public BaseMessage HandleText(RequestText info)
        {

            var response = new ResponseText(info)
            {
                Content = Msg
            };
            return response;

        }

        public BaseMessage HandleImage(RequestImage info)
        {

            var response = new ResponseText(info)
            {
                Content = Msg
            };
            return response;

        }
        public BaseMessage HandleVoice(RequestVoice info)
        {

            var response = new ResponseText(info)
            {
                Content = Msg
            };
            return response;

        }

        public BaseMessage HandleVideo(RequestVideo info)
        {

            var response = new ResponseText(info)
            {
                Content = Msg
            };
            return response;
        }

        public BaseMessage HandleShortVideo(RequestVideo info)
        {

            var response = new ResponseText(info)
            {
                Content = Msg
            };
            return response;
        }

        public BaseMessage HandleLocation(RequestLocation info)
        {

            var response = new ResponseText(info)
            {
                Content = Msg
            };
            return response;
        }

        public BaseMessage HandleLink(RequestLink info)
        {

            var response = new ResponseText(info)
            {
                Content = Msg
            };
            return response;
        }

        public BaseMessage HandleEventClick(RequestEvent info)
        {

            EventType eventType = (EventType)Enum.Parse(typeof(EventType), info.Event,true);
            switch (eventType)
            {
                case EventType.Subscribe:
                    break;
                case EventType.Unsubscribe:
                    break;
                case EventType.Scan:
                    break;
                case EventType.Location:
                    break;
                case EventType.Click:
                    return _eventService.ClickEvent(info);
                    break;
                case EventType.View:
                    break;
                default:
                    break;
            }
            var response = new ResponseText(info)
            {
                Content = Msg
            };

            return response;
        }
    }
}