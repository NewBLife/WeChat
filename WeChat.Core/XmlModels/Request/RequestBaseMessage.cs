using System.Xml.Serialization;

namespace WeChat.Core.XmlModels.Request
{
    [XmlRoot(ElementName = "xml")]
    public class RequestBaseMessage: BaseMessage
    {
        public long MsgId { get; set; }
    }
}