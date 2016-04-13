using System.Xml.Serialization;

namespace WeChat.Core.XmlModels.Request
{
    [XmlRoot(ElementName = "xml")]
    public class RequestEventSubscribe : BaseEvent
    {
        public string EventKey { get; set; }

        public long Ticket { get; set; }
    }
}