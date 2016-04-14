using System.Xml.Serialization;

namespace WeChat.Core.XmlModels.Request
{
    [XmlRoot(ElementName = "xml")]
    public class RequestEvent : BaseMessage
    {
        public string Event { get; set; }
        public string EventKey { get; set; }

        public long Ticket { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Precision { get; set; }
    }
}