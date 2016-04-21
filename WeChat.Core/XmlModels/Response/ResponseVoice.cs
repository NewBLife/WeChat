﻿using System;
using System.Xml.Serialization;
using Aurore.Framework.Utils;
using WeChat.Core.Constants;
using WeChat.Core.Entitys;

namespace WeChat.Core.XmlModels.Response
{
    [XmlRoot(ElementName = "xml")]
    public class ResponseVoice:BaseMessage
    {
        public ResponseVoice()
        {
            MsgType = ResponseType.Voice.ToString().ToLower();
        }

        public ResponseVoice(BaseMessage info) : this()
        {
            this.FromUserName = info.ToUserName;
            this.ToUserName = info.FromUserName;
        }

        public VoiceEntity Voice { get; set; }

        public override string ToXml()
        {
            this.CreateTime = DateTime.Now.ConvertToInt();//重新更新
            return this.SerializerToXml();
        }
    }
}